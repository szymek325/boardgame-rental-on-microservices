using System;
using System.Collections.Generic;
using BoardGameRentalApp.Core.DataAccess;
using BoardGameRentalApp.Core.Entities;
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
            throw new NotImplementedException();
        }

        public Client Get(int? id)
        {
            throw new NotImplementedException();
        }

        public void Create(Client entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Client entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Client entity)
        {
            throw new NotImplementedException();
        }
    }
}