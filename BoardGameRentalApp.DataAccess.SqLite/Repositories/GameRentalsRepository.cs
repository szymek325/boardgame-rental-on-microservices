using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoardGameRentalApp.Core.Entities;
using BoardGameRentalApp.Core.Interfaces.DataAccess;
using BoardGameRentalApp.DataAccess.SqLite.Context;
using Microsoft.EntityFrameworkCore;

namespace BoardGameRentalApp.DataAccess.SqLite.Repositories
{
    internal class GameRentalsRepository : IGameRentalsRepository
    {
        private readonly SqLiteContext _sqLiteContext;

        public GameRentalsRepository(SqLiteContext sqLiteContext)
        {
            _sqLiteContext = sqLiteContext;
        }

        public void Add(GameRental entity)
        {
            _sqLiteContext.GameRentals.Add(entity);
        }

        public async Task AddAsync(GameRental entity)
        {
            await _sqLiteContext.GameRentals.AddAsync(entity);
        }

        public void Remove(GameRental entity)
        {
            _sqLiteContext.GameRentals.Remove(entity);
        }

        public GameRental Get(int? id)
        {
            return _sqLiteContext.GameRentals.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<GameRental> GetAll()
        {
            return _sqLiteContext.GameRentals.Include(x => x.BoardGame).Include(x => x.Client).ToList();
        }

        public void Update(GameRental entity)
        {
            _sqLiteContext.GameRentals.Update(entity);
        }
    }
}