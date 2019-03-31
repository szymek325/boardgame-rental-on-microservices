using System.Collections.Generic;
using System.Threading.Tasks;
using BoardGameRentalApp.Core.Entities;

namespace BoardGameRentalApp.Core.Interfaces.DataAccess
{
    public interface IClientsRepository
    {
        IEnumerable<Client> GetAll();
        Client GetWithDetails(int? id);
        void Add(Client entity);
        Task AddAsync(Client entity);
        void Remove(Client entity);
        void Update(Client entity);
    }
}