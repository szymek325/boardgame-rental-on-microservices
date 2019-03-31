using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoardGameRentalApp.Core.Entities;
using BoardGameRentalApp.Core.Interfaces.DataAccess;
using BoardGameRentalApp.DataAccess.SqlServer.Context;
using Microsoft.EntityFrameworkCore;

namespace BoardGameRentalApp.DataAccess.SqlServer.Repositories
{
    internal class GameRentalsRepository : IGameRentalsRepository
    {
        private readonly SqlServerContext _msSqlServerContext;

        public GameRentalsRepository(SqlServerContext msSqlServerContext)
        {
            _msSqlServerContext = msSqlServerContext;
        }

        public void Add(GameRental entity)
        {
            _msSqlServerContext.GameRentals.Add(entity);
        }

        public async Task AddAsync(GameRental entity)
        {
            await _msSqlServerContext.GameRentals.AddAsync(entity);
        }

        public void Remove(GameRental entity)
        {
            _msSqlServerContext.GameRentals.Remove(entity);
        }

        public GameRental Get(int? id)
        {
            return _msSqlServerContext.GameRentals.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<GameRental> GetAll()
        {
            return _msSqlServerContext.GameRentals.Include(x => x.BoardGame).Include(x => x.Client).ToList();
        }

        public void Update(GameRental entity)
        {
            _msSqlServerContext.GameRentals.Update(entity);
        }
    }
}