using System.Collections.Generic;
using System.Threading.Tasks;
using BoardGameRentalApp.Core.Entities;

namespace BoardGameRentalApp.Core.Interfaces.DataAccess
{
    public interface IBoardGamesRepository
    {
        IEnumerable<BoardGame> GetAll();
        BoardGame GetWithDetails(int? id);
        void Add(BoardGame entity);
        Task AddAsync(BoardGame entity);
        void Remove(BoardGame entity);
        void Update(BoardGame entity);
    }
}

