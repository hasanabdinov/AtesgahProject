using Core.Dtos;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface ILoanService
    {
        Task<IEnumerable<Loan>> GetLoanDetails();
        Task<Message> AddAsync(Loan model);
    }
}
