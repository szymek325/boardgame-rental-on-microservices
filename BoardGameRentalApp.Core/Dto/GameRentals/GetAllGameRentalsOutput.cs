using System.Collections.Generic;

namespace BoardGameRentalApp.Core.Dto.GameRentals
{
    internal class GetAllGameRentalsOutput
    {
        public IEnumerable<GameRentalDto> GameRentals { get; set; }
    }
}