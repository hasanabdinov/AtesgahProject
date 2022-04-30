using Core.Models;
using Core.Repositories;


namespace DataAccess.Repositories
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        private DataContext _context => Context as DataContext;
        public ClientRepository(DataContext context) : base(context)
        {

        }
    }
}
