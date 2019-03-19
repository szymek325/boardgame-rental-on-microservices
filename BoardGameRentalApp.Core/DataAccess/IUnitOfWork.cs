namespace BoardGameRentalApp.Core.DataAccess
{
    public interface IUnitOfWork
    {
        IBoardGamesRepository BoardGamesRepository { get; }
        IClientsRepository ClientsRepository { get; }
        IGameRentalsRepository GameRentalsRepository { get; }
    }
}