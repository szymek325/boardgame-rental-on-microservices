using System;
using BoardGameRentalApp.Core.Models;

namespace BoardGameRentalApp.Core.Dto.GameRentals
{
    public class GameRentalDto
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int BoardGameId { get; set; }
        public Status Status { get; set; }
        public float PaymentAmount { get; set; }
        public DateTime CreationTime { get; set; }
    }
}