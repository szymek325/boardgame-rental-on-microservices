using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoardGameRentalApp.Core.Entities;
using BoardGameRentalApp.Core.Interfaces.DataAccess;
using BoardGameRentalApp.DataAccess.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;

namespace BoardGameRentalApp.DataAccess.EntityFramework.Repositories
{
    internal class ClientsRepository : IClientsRepository
    {
        private readonly BoardGamesShopContext _boardGamesShopContext;

        public ClientsRepository(BoardGamesShopContext boardGamesShopContext)
        {
            _boardGamesShopContext = boardGamesShopContext;
        }

        public IEnumerable<Client> GetAll()
        {
            return _boardGamesShopContext.Clients.ToList();
        }

        public async Task AddAsync(Client entity)
        {
            await _boardGamesShopContext.Clients.AddAsync(entity);
        }

        public void Remove(Client entity)
        {
            _boardGamesShopContext.Clients.Remove(entity);
        }

        public void Update(Client entity)
        {
            _boardGamesShopContext.Clients.Update(entity);
        }

        public Client GetWithGameRentals(int? id)
        {
            return _boardGamesShopContext.Clients
                .Include(x => x.GameRentals)
                .FirstOrDefault(x => x.Id == id);
        }
    }
}