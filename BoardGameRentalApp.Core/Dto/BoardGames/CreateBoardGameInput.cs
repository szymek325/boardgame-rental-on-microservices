using System.ComponentModel.DataAnnotations;

namespace BoardGameRentalApp.Core.Dto.BoardGames
{
    public class CreateBoardGameInput
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public float PricePerDay { get; set; }

        [Required]
        public float Bail { get; set; }
    }
}