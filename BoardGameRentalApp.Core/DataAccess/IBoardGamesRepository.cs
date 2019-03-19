using System.Collections.Generic;
using BoardGameRentalApp.Core.Entities;

namespace BoardGameRentalApp.Core.DataAccess
{
    public interface IBoardGamesRepository
    {
        IEnumerable<BoardGame> GetAll();
        BoardGame Get(int? id);
        void Create(BoardGame entity);
        void Delete(BoardGame entity);
        void Update(BoardGame entity);
    }
}

