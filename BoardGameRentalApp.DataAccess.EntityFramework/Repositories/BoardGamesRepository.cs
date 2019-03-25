using System.Collections.Generic;
using System.Linq;
using BoardGameRentalApp.Core.Entities;
using BoardGameRentalApp.Core.Interfaces.DataAccess;
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
            return _context.BoardGames.ToList();
        }

        public BoardGame Get(int? id)
        {
            return _context.BoardGames.FirstOrDefault(x => x.Id == id);
        }

        public void Add(BoardGame entity)
        {
            _context.BoardGames.Add(entity);
        }

        public void Remove(BoardGame entity)
        {
            _context.BoardGames.Remove(entity);
        }

        public void Update(BoardGame entity)
        {
            _context.BoardGames.Update(entity);
        }
    }
}