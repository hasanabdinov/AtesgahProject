using Core;
using Core.Dtos;
using Core.Models;
using Core.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Data
{
    public class LoanService : ILoanService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<LoanService> _logger;
        public LoanService(IUnitOfWork unitOfWork,
                           ILogger<LoanService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<IEnumerable<Loan>> GetLoanDetails()
        {
            return await _unitOfWork.Loan.GetAllAsync();
        }

        public async Task<Message> AddAsync(Loan model)
        {
            try
            {
                await _unitOfWork.Loan.AddAsync(model);
                await _unitOfWork.CommitAsync();
                return new Message { AlertColor = "success", ResultMessages = new List<string> { "Created" } };
            }
            catch (Exception exception)
            {
                _logger.LogError(exception.Message);
                return new Message { AlertColor = "danger", ResultMessages = new List<string> { "Not Created" } };
            }
        }
    }
}
