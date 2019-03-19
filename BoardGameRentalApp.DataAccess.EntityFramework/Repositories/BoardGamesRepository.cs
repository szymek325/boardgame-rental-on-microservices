using System;
using System.Collections.Generic;
using BoardGameRentalApp.Core.DataAccess;
using BoardGameRentalApp.Core.Entities;
using BoardGameRentalApp.DataAccess.EntityFramework.Context;

namespace BoardGameRentalApp.DataAccess.EntityFramework.Repositories
{
    internal class BoardGamesRepository : IBoardGamesRepository
    {
        private readonly BoardGameRentalContext _context;

        public BoardGamesRepository(BoardGameRentalContext context)
        {
            _context = context;
        }

        public IEnumerable<BoardGame> GetAll()
        {
            throw new NotImplementedException();
        }

        public BoardGame Get(int? id)
        {
            throw new NotImplementedException();
        }

        public void Create(BoardGame entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(BoardGame entity)
        {
            throw new NotImplementedException();
        }

        public void Update(BoardGame entity)
        {
            throw new NotImplementedException();
        }
    }
}