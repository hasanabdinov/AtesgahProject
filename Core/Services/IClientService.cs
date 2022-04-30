using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IClientService
    {
        Task<IEnumerable<Client>> GetAllClients();
        Task AddAsync(List<Client> clients);
    }
}
