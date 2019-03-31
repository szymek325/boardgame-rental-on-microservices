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
        private readonly SqlServerContext _msSqlServerContext;

        public ClientsRepository(SqlServerContext msSqlServerContext)
        {
            _msSqlServerContext = msSqlServerContext;
        }

        public IEnumerable<Client> GetAll()
        {
            return _msSqlServerContext.Clients.ToList();
        }

        public Client Get(int? id)
        {
            return _msSqlServerContext.Clients.FirstOrDefault(x => x.Id == id);
        }

        public void Add(Client entity)
        {
            _msSqlServerContext.Clients.Add(entity);
        }

        public async Task AddAsync(Client entity)
        {
            await _msSqlServerContext.Clients.AddAsync(entity);
        }

        public void Remove(Client entity)
        {
            _msSqlServerContext.Clients.Remove(entity);
        }

        public void Update(Client entity)
        {
            _msSqlServerContext.Clients.Update(entity);
        }
    }
}