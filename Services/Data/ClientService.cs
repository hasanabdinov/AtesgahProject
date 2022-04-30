using Core;
using Core.Models;
using Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Data
{
    public class ClientService : IClientService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ClientService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(List<Client> clients)
        {
            try
            {
                await _unitOfWork.Client.AddRangeAsync(clients);
                await _unitOfWork.CommitAsync();
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Client>> GetAllClients()
        {
            return await _unitOfWork.Client.GetAllAsync();
        }

    }
}
