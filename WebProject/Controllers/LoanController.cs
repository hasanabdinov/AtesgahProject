using AutoMapper;
using Bogus;
using Core.Dtos;
using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace WebProject.Controllers
{
    public class LoanController : Controller
    {
        private readonly IClientService _clientService;
        private readonly ILoanService _loanService;
        private readonly IMapper _mapper;
        private readonly IInvoiceService _invoiceService;
        private readonly ILogger<LoanController> _logger;
        public LoanController(IClientService clientService,
                              ILoanService loanService,
                              IMapper mapper,
                              IInvoiceService invoiceService,
                              ILogger<LoanController> logger)
        {
            _clientService = clientService;
            _loanService = loanService;
            _invoiceService = invoiceService;
            _mapper = mapper;
            _logger = logger;
        }

        private static Faker<Client> FakeData()
        {
            var fakeClient = new Faker<Client>()
                .RuleFor(c => c.Name, f => f.Name.FirstName())
                .RuleFor(c => c.Surname, f => f.Name.LastName())
                .RuleFor(c => c.ClientUniqueID, f => Guid.NewGuid().ToString())
                .RuleFor(c => c.TelephoneNr, f => "+994513848887")
                .RuleFor(c => c.Created_at, f => DateTime.Now)
                .RuleFor(c => c.Create_by, f => "System");
            return fakeClient;
        }

        public async Task<IActionResult> Index()
        {
            var clients = await _clientService.GetAllClients();
            
            if (clients.Count() < 20)
            {
                var user = FakeData().Generate(30);

                await _clientService.AddAsync(user);

            }
            var dbclients = await _clientService.GetAllClients();
            var loanDetails = await _loanService.GetLoanDetails();
            var loans = _mapper.Map<IEnumerable<LoanDetailDto>>(loanDetails);
            LoanDto viewModel = new LoanDto
            {
                Loans = loans,
                Clients = dbclients,
                MinPayPeriod = 3,
                MaxPayPeriod = 24
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Post(CalculateDto calculateDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError(ModelState.ValidationState.ToString());
                return RedirectToAction("ErrorResultPage","Invoice");
            }
            var invoices = await _invoiceService.GetCalculatedInvoices(calculateDto);
            calculateDto.Invoices = invoices;
            Message result = new Message();
            if (invoices.Count() > 2)
            {
                var model = _mapper.Map<CalculateDto, Loan>(calculateDto);

                result = await _loanService.AddAsync(model);
            }
            return PartialView("_PartialViewAlert", result);
        }
    }
}