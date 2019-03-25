using System.Collections.Generic;
using System.Linq;
using BoardGameRentalApp.Core.Entities;
using BoardGameRentalApp.Core.Interfaces.DataAccess;
using BoardGameRentalApp.DataAccess.EntityFramework.Context;

namespace BoardGameRentalApp.DataAccess.EntityFramework.Repositories
{
    internal class ClientsRepository : IClientsRepository
    {
        private readonly BoardGameRentalContext _context;

        public ClientsRepository(BoardGameRentalContext context)
        {
            _context = context;
        }

        public IEnumerable<Client> GetAll()
        {
            return _context.Clients.ToList();
        }

        public Client Get(int? id)
        {
            return _context.Clients.FirstOrDefault(x => x.Id == id);
        }

        public void Create(Client entity)
        {
            _context.Clients.Add(entity);
        }

        public void Remove(Client entity)
        {
            _context.Clients.Remove(entity);
        }

        public void Update(Client entity)
        {
            _context.Clients.Update(entity);
        }
    }
}