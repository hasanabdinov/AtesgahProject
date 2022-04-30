using Core;
using Core.Dtos;
using Core.Models;
using Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Data
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IUnitOfWork _unitOfWork;
        public InvoiceService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<IEnumerable<Invoice>> GetAllInvoicesByLoandId(int loanId)
        {
            return await _unitOfWork.Invoice.GetAllAsync(x => x.LoanId == loanId);
        }

        public async Task<IEnumerable<Invoice>> GetCalculatedInvoices(CalculateDto calculateDto)
        {
            return await _unitOfWork.Invoice.GetCalculatedInvoices(calculateDto);
        }
    }
}
