using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoardGameRentalApp.Core.Entities;
using BoardGameRentalApp.Core.Interfaces.DataAccess;
using BoardGameRentalApp.DataAccess.SqlServer.Context;

namespace BoardGameRentalApp.DataAccess.SqlServer.Repositories
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

        public void Add(Client entity)
        {
            _context.Clients.Add(entity);
        }

        public async Task AddAsync(Client entity)
        {
            await _context.Clients.AddAsync(entity);
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