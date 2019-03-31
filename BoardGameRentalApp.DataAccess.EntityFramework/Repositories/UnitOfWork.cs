using System.Threading.Tasks;
using BoardGameRentalApp.Core.Interfaces.DataAccess;
using BoardGameRentalApp.DataAccess.SqlServer.Context;

namespace BoardGameRentalApp.DataAccess.SqlServer.Repositories
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly SqlServerContext _msSqlServerContext;
        private IBoardGamesRepository _boardGamesRepository;
        private IClientsRepository _clientsRepository;
        private IGameRentalsRepository _gameRentalsRepository;

        public UnitOfWork(SqlServerContext msSqlServerContext)
        {
            _msSqlServerContext = msSqlServerContext;
        }

        public IBoardGamesRepository BoardGamesRepository
        {
            get { return _boardGamesRepository = _boardGamesRepository ?? new BoardGamesRepository(_msSqlServerContext); }
        }

        public IClientsRepository ClientsRepository
        {
            get { return _clientsRepository = _clientsRepository ?? new ClientsRepository(_msSqlServerContext); }
        }

        public IGameRentalsRepository GameRentalsRepository
        {
            get { return _gameRentalsRepository = _gameRentalsRepository ?? new GameRentalsRepository(_msSqlServerContext); }
        }

        public void SaveChanges()
        {
            _msSqlServerContext.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _msSqlServerContext.SaveChangesAsync();
        }
    }
}