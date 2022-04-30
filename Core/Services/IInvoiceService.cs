using Core.Dtos;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IInvoiceService
    {
        Task<IEnumerable<Invoice>> GetCalculatedInvoices(CalculateDto calculateDto);
        Task<IEnumerable<Invoice>> GetAllInvoicesByLoandId(int loanId);
    }
}
