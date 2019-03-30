using System.Threading.Tasks;
using BoardGameRentalApp.Core.Interfaces.DataAccess;
using BoardGameRentalApp.DataAccess.SqLite.Context;

namespace BoardGameRentalApp.DataAccess.SqLite.Repositories
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly BoardGameRentalSqLiteContext _sqLiteContext;
        private IBoardGamesRepository _boardGamesRepository;
        private IClientsRepository _clientsRepository;
        private IGameRentalsRepository _gameRentalsRepository;

        public UnitOfWork(BoardGameRentalSqLiteContext sqLiteContext)
        {
            _sqLiteContext = sqLiteContext;
        }

        public IBoardGamesRepository BoardGamesRepository
        {
            get { return _boardGamesRepository = _boardGamesRepository ?? new BoardGamesRepository(_sqLiteContext); }
        }

        public IClientsRepository ClientsRepository
        {
            get { return _clientsRepository = _clientsRepository ?? new ClientsRepository(_sqLiteContext); }
        }

        public IGameRentalsRepository GameRentalsRepository
        {
            get { return _gameRentalsRepository = _gameRentalsRepository ?? new GameRentalsRepository(_sqLiteContext); }
        }

        public void SaveChanges()
        {
            _sqLiteContext.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _sqLiteContext.SaveChangesAsync();
        }
    }
}