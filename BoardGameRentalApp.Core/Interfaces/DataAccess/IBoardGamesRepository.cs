using System.Collections.Generic;
using System.Threading.Tasks;
using BoardGameRentalApp.Core.Entities;

namespace BoardGameRentalApp.Core.Interfaces.DataAccess
{
    public interface IBoardGamesRepository
    {
        IEnumerable<BoardGame> GetAll();
        IEnumerable<BoardGame> GetAllAvailableForRental();
        BoardGame GetWithGameRentals(int? id);
        Task AddAsync(BoardGame entity);
        void Remove(BoardGame entity);
        void Update(BoardGame entity);
    }
}

