using Core.Models;
using Core.Repositories;


namespace DataAccess.Repositories
{
    public class LoanRepository : Repository<Loan>, ILoanRepository
    {
        private DataContext _context => Context as DataContext;
        public LoanRepository(DataContext context) : base(context)
        {

        }
    }
}
