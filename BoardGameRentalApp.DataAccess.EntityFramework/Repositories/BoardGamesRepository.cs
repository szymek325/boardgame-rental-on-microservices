using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoardGameRentalApp.Core.Entities;
using BoardGameRentalApp.Core.Interfaces.DataAccess;
using BoardGameRentalApp.DataAccess.SqlServer.Context;

namespace BoardGameRentalApp.DataAccess.SqlServer.Repositories
{
    internal class BoardGamesRepository : IBoardGamesRepository
    {
        private readonly SqlServerContext _msSqlServerContext;

        public BoardGamesRepository(SqlServerContext msSqlServerContext)
        {
            _msSqlServerContext = msSqlServerContext;
        }

        public IEnumerable<BoardGame> GetAll()
        {
            return _msSqlServerContext.BoardGames.ToList();
        }

        public BoardGame GetWithDetails(int? id)
        {
            return _msSqlServerContext.BoardGames.FirstOrDefault(x => x.Id == id);
        }

        public void Add(BoardGame entity)
        {
            _msSqlServerContext.BoardGames.Add(entity);
        }

        public async Task AddAsync(BoardGame entity)
        {
            await _msSqlServerContext.BoardGames.AddAsync(entity);
        }

        public void Remove(BoardGame entity)
        {
            _msSqlServerContext.BoardGames.Remove(entity);
        }

        public void Update(BoardGame entity)
        {
            _msSqlServerContext.BoardGames.Update(entity);
        }
    }
}