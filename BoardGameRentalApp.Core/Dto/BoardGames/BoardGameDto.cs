using System;

namespace BoardGameRentalApp.Core.Dto.BoardGames
{
    public class BoardGameDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float PricePerDay { get; set; }
        public float SuggestedDeposit { get; set; }
        public DateTime CreationTime { get; set; }
    }
}