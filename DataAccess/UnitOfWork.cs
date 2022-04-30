using Core;
using Core.Repositories;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        private readonly DataContext _context;

        public ILoanRepository _loanRepository;

        public IClientRepository _clientRepository;

        public IInvoiceRepository _invoiceRepository;

        public ILoanRepository Loan => _loanRepository ?? new LoanRepository(_context);


        public IClientRepository Client => _clientRepository ?? new ClientRepository(_context);

        public IInvoiceRepository Invoice => _invoiceRepository ?? new InvoiceRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task DisposeAsync()
        {
            await _context.DisposeAsync();
        }
    }
}
