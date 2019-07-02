using System.Collections.Generic;

namespace BoardGameRentalApp.Core.Entities
{
    public class BoardGame : BaseEntity
    {
        public string Name { get; set; }
        public float PricePerDay { get; set; }
        public float SuggestedDeposit { get; set; }
        public ICollection<GameRental> GameRentals { get; set; }
    }
}