using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoardGameRentalApp.Core.Entities;
using BoardGameRentalApp.Core.Interfaces.DataAccess;
using BoardGameRentalApp.DataAccess.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;

namespace BoardGameRentalApp.DataAccess.EntityFramework.Repositories
{
    internal class GameRentalsRepository : IGameRentalsRepository
    {
        private readonly BoardGameRentalContext _context;

        public GameRentalsRepository(BoardGameRentalContext context)
        {
            _context = context;
        }

        public void Add(GameRental entity)
        {
            _context.GameRentals.Add(entity);
        }

        public async Task AddAsync(GameRental entity)
        {
            await _context.GameRentals.AddAsync(entity);
        }

        public void Remove(GameRental entity)
        {
            _context.GameRentals.Remove(entity);
        }

        public GameRental Get(int? id)
        {
            return _context.GameRentals.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<GameRental> GetAll()
        {
            return _context.GameRentals.Include(x => x.BoardGame).Include(x => x.Client).ToList();
        }

        public void Update(GameRental entity)
        {
            _context.GameRentals.Update(entity);
        }
    }
}