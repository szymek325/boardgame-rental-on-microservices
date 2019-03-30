using System.Threading.Tasks;
using BoardGameRentalApp.Core.Interfaces.DataAccess;
using BoardGameRentalApp.DataAccess.SqlServer.Context;

namespace BoardGameRentalApp.DataAccess.SqlServer.Repositories
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly BoardGameRentalMsSqlContext _msSqlContext;
        private IBoardGamesRepository _boardGamesRepository;
        private IClientsRepository _clientsRepository;
        private IGameRentalsRepository _gameRentalsRepository;

        public UnitOfWork(BoardGameRentalMsSqlContext msSqlContext)
        {
            _msSqlContext = msSqlContext;
        }

        public IBoardGamesRepository BoardGamesRepository
        {
            get { return _boardGamesRepository = _boardGamesRepository ?? new BoardGamesRepository(_msSqlContext); }
        }

        public IClientsRepository ClientsRepository
        {
            get { return _clientsRepository = _clientsRepository ?? new ClientsRepository(_msSqlContext); }
        }

        public IGameRentalsRepository GameRentalsRepository
        {
            get { return _gameRentalsRepository = _gameRentalsRepository ?? new GameRentalsRepository(_msSqlContext); }
        }

        public void SaveChanges()
        {
            _msSqlContext.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _msSqlContext.SaveChangesAsync();
        }
    }
}