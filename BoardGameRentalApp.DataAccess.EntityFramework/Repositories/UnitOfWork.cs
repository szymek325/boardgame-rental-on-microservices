using System.Threading.Tasks;
using BoardGameRentalApp.Core.Interfaces.DataAccess;
using BoardGameRentalApp.DataAccess.EntityFramework.Context;

namespace BoardGameRentalApp.DataAccess.EntityFramework.Repositories
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly BoardGameRentalContext _context;
        private IBoardGamesRepository _boardGamesRepository;
        private IClientsRepository _clientsRepository;
        private IGameRentalsRepository _gameRentalsRepository;

        public UnitOfWork(BoardGameRentalContext context)
        {
            _context = context;
        }

        public IBoardGamesRepository BoardGamesRepository
        {
            get { return _boardGamesRepository = _boardGamesRepository ?? new BoardGamesRepository(_context); }
        }

        public IClientsRepository ClientsRepository
        {
            get { return _clientsRepository = _clientsRepository ?? new ClientsRepository(_context); }
        }

        public IGameRentalsRepository GameRentalsRepository
        {
            get { return _gameRentalsRepository = _gameRentalsRepository ?? new GameRentalsRepository(_context); }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}