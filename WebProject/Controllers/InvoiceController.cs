using Core.Dtos;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProject.Models;

namespace WebProject.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly IInvoiceService _invoiceService;
        private readonly ILogger<InvoiceController> _logger;
        public InvoiceController(IInvoiceService invoiceService,
                                 ILogger<InvoiceController> logger)
        {
            _invoiceService = invoiceService;
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet()]
        public async Task<IActionResult> GetInvoiceByLoanId(int id)
        {
            var invoices = await _invoiceService.GetAllInvoicesByLoandId(id);
            return PartialView("_PartialViewInvoicesOfLoan", invoices);
        }
        [HttpPost]
        public async Task<IActionResult> CalculatedInvoice(CalculateDto calculateDto)
        {
            if(!ModelState.IsValid)
            {
                _logger.LogError(ModelState.ValidationState.ToString());
                return RedirectToAction("ErrorResultPage");
            }
            var invoices = await _invoiceService.GetCalculatedInvoices(calculateDto);
            decimal totalinterest = ((invoices.Sum(x => x.Amount)/calculateDto.LoanAmount) - 1) * 100;
            InvoiceDto invoiceDto = new InvoiceDto
            {
                Invoices = invoices,
                CalculateDto = calculateDto,
                TotalInterest = totalinterest
            };

            return PartialView("_PartialViewCalculateInvoice", invoiceDto);
        }

        [HttpGet]
        public async Task<IActionResult> ErrorResultPage()
        {
            return View("Error");
        }

    }
}
