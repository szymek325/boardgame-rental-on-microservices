using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoardGameRentalApp.Core.Entities;
using BoardGameRentalApp.Core.Interfaces.DataAccess;
using BoardGameRentalApp.DataAccess.SqLite.Context;
using Microsoft.EntityFrameworkCore;

namespace BoardGameRentalApp.DataAccess.SqLite.Repositories
{
    internal class BoardGamesRepository : IBoardGamesRepository
    {
        private readonly SqLiteContext _sqLiteContext;

        public BoardGamesRepository(SqLiteContext sqLiteContext)
        {
            _sqLiteContext = sqLiteContext;
        }

        public IEnumerable<BoardGame> GetAll()
        {
            return _sqLiteContext.BoardGames.ToList();
        }

        public BoardGame GetWithDetails(int? id)
        {
            return _sqLiteContext.BoardGames
                .Include(x => x.GameRentals)
                .FirstOrDefault(x => x.Id == id);
        }

        public void Add(BoardGame entity)
        {
            _sqLiteContext.BoardGames.Add(entity);
        }

        public async Task AddAsync(BoardGame entity)
        {
            await _sqLiteContext.BoardGames.AddAsync(entity);
        }

        public void Remove(BoardGame entity)
        {
            _sqLiteContext.BoardGames.Remove(entity);
        }

        public void Update(BoardGame entity)
        {
            _sqLiteContext.BoardGames.Update(entity);
        }
    }
}