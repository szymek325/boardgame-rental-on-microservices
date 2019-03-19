using System;
using System.Collections.Generic;
using BoardGameRentalApp.Core.DataAccess;
using BoardGameRentalApp.Core.Entities;
using BoardGameRentalApp.DataAccess.EntityFramework.Context;

namespace BoardGameRentalApp.DataAccess.EntityFramework.Repositories
{
    internal class GameRentalsRepository : IGameRentalsRepository
    {
        private readonly BoardGameRentalContext _context;

        public GameRentalsRepository(BoardGameRentalContext context)
        {
            _context = context;
        }

        public void Create(GameRental entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(GameRental entity)
        {
            throw new NotImplementedException();
        }

        public GameRental Get(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GameRental> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(GameRental entity)
        {
            throw new NotImplementedException();
        }
    }
}