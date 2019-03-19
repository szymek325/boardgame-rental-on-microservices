using BoardGameRentalApp.Core.Models;

namespace BoardGameRentalApp.Core.Entities
{
    public class GameRental : BaseEntity
    {
        public int ClientId { get; set; }
        public int BoardGameId { get; set; }
        public BoardGame BoardGame { get; set; }
        public Client Client { get; set; }
        public Status Status { get; set; }
    }
}