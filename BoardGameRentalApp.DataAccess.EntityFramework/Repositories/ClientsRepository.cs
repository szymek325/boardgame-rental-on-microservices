﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoardGameRentalApp.Core.Entities;
using BoardGameRentalApp.Core.Interfaces.DataAccess;
using BoardGameRentalApp.DataAccess.SqlServer.Context;

namespace BoardGameRentalApp.DataAccess.SqlServer.Repositories
{
    internal class ClientsRepository : IClientsRepository
    {
        private readonly BoardGameRentalMsSqlContext _msSqlContext;

        public ClientsRepository(BoardGameRentalMsSqlContext msSqlContext)
        {
            _msSqlContext = msSqlContext;
        }

        public IEnumerable<Client> GetAll()
        {
            return _msSqlContext.Clients.ToList();
        }

        public Client Get(int? id)
        {
            return _msSqlContext.Clients.FirstOrDefault(x => x.Id == id);
        }

        public void Add(Client entity)
        {
            _msSqlContext.Clients.Add(entity);
        }

        public async Task AddAsync(Client entity)
        {
            await _msSqlContext.Clients.AddAsync(entity);
        }

        public void Remove(Client entity)
        {
            _msSqlContext.Clients.Remove(entity);
        }

        public void Update(Client entity)
        {
            _msSqlContext.Clients.Update(entity);
        }
    }
}