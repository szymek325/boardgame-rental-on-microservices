using System.Collections.Generic;
using BoardGameRentalApp.Core.Entities;

namespace BoardGameRentalApp.Core.Interfaces.DataAccess
{
    public interface IGameRentalsRepository
    {
        IEnumerable<GameRental> GetAll();
        GameRental Get(int? id);
        void Create(GameRental entity);
        void Delete(GameRental entity);
        void Update(GameRental entity);
    }
}