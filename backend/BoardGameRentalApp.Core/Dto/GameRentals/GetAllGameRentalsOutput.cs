using System.Collections.Generic;

namespace BoardGameRentalApp.Core.Dto.GameRentals
{
    public class GetAllGameRentalsOutput
    {
        public GetAllGameRentalsOutput(IEnumerable<GameRentalDto> gameRentals)
        {
            GameRentals = gameRentals;
        }

        public IEnumerable<GameRentalDto> GameRentals { get; set; }
    }
}