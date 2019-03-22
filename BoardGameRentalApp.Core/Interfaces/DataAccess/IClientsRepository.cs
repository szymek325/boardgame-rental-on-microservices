using System.Collections.Generic;
using BoardGameRentalApp.Core.Entities;

namespace BoardGameRentalApp.Core.Interfaces.DataAccess
{
    public interface IClientsRepository
    {
        IEnumerable<Client> GetAll();
        Client Get(int? id);
        void Create(Client entity);
        void Delete(Client entity);
        void Update(Client entity);
    }
}