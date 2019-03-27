using System.Collections.Generic;

namespace BoardGameRentalApp.Core.Dto.GameRentals
{
    public class GetAllGameRentalsOutput
    {
        public IEnumerable<GameRentalDto> GameRentals { get; set; }
    }
}