using System;
using System.Collections.Generic;
using BoardGameRentalApp.Core.Dto.GameRentals;

namespace BoardGameRentalApp.Core.Dto.BoardGames
{
    public class BoardGameDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float PricePerDay { get; set; }
        public float Bail { get; set; }
        public ICollection<GameRentalDto> GameRentals { get; set; }
        public DateTime CreationTime { get; set; }
    }
}