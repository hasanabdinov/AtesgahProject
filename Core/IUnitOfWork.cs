using Core.Repositories;
using System;
using System.Threading.Tasks;

namespace Core
{
    public interface IUnitOfWork : IDisposable
    {
        ILoanRepository Loan { get; }
        IClientRepository Client { get; }
        IInvoiceRepository Invoice { get; }


        Task<int> CommitAsync();
        Task DisposeAsync();
    }
}
