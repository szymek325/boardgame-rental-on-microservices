using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoardGameRentalApp.Core.Entities;
using BoardGameRentalApp.Core.Interfaces.DataAccess;
using BoardGameRentalApp.Core.Models;
using BoardGameRentalApp.DataAccess.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;

namespace BoardGameRentalApp.DataAccess.EntityFramework.Repositories
{
    internal class BoardGamesRepository : IBoardGamesRepository
    {
        private readonly BoardGamesShopContext _gameRentalContext;

        public BoardGamesRepository(BoardGamesShopContext gameRentalContext)
        {
            _gameRentalContext = gameRentalContext;
        }

        public IEnumerable<BoardGame> GetAll()
        {
            return _gameRentalContext.BoardGames.ToList();
        }

        public IEnumerable<BoardGame> GetAllAvailableForRental()
        {
            return _gameRentalContext.BoardGames
                .Include(x => x.GameRentals)
                .Where(x => x.GameRentals.All(g => g.Status != Status.InProgress))
                .ToList();
        }

        public BoardGame GetWithGameRentals(int? id)
        {
            return _gameRentalContext.BoardGames
                .Include(x => x.GameRentals)
                .FirstOrDefault(x => x.Id == id);
        }

        public async Task AddAsync(BoardGame entity)
        {
            await _gameRentalContext.BoardGames.AddAsync(entity);
        }

        public void Remove(BoardGame entity)
        {
            _gameRentalContext.BoardGames.Remove(entity);
        }

        public void Update(BoardGame entity)
        {
            _gameRentalContext.BoardGames.Update(entity);
        }
    }
}