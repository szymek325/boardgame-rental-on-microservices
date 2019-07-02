using System.ComponentModel.DataAnnotations;

namespace BoardGameRentalApp.Core.Dto.GameRentals
{
    public class CreateGameRentalInput
    {
        [Required]
        public int ClientId { get; set; }

        [Required]
        public int BoardGameId { get; set; }

        [Required]
        public float ChargedDeposit { get; set; }
    }
}