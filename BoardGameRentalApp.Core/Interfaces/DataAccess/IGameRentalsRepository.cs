using System.Collections.Generic;
using System.Threading.Tasks;
using BoardGameRentalApp.Core.Entities;

namespace BoardGameRentalApp.Core.Interfaces.DataAccess
{
    public interface IGameRentalsRepository
    {
        IEnumerable<GameRental> GetAll();
        GameRental Get(int? id);    
        void Add(GameRental entity);
        Task AddAsync(GameRental entity);
        void Remove(GameRental entity);
        void Update(GameRental entity);
    }
}