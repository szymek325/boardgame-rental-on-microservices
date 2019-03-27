using System.ComponentModel.DataAnnotations;

namespace BoardGameRentalApp.Core.Dto.Clients
{
    public class CreateClientInput
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string ContactNumber { get; set; }
    }
}