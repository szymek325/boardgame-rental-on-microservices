using System.Collections.Generic;
using BoardGameRentalApp.Core.Entities;

namespace BoardGameRentalApp.Core.Interfaces.DataAccess
{
    public interface IBoardGamesRepository
    {
        IEnumerable<BoardGame> GetAll();
        BoardGame Get(int? id);
        void Add(BoardGame entity);
        void Remove(BoardGame entity);
        void Update(BoardGame entity);
    }
}

