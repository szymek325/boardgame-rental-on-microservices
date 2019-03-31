using System.Collections.Generic;
using System.Threading.Tasks;
using BoardGameRentalApp.Core.Entities;

namespace BoardGameRentalApp.Core.Interfaces.DataAccess
{
    public interface IGameRentalsRepository
    {
        IEnumerable<GameRental> GetAll();
        GameRental GetWithDetails(int? id);
        Task AddAsync(GameRental entity);
        void Update(GameRental entity);
    }
}