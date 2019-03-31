using System;
using System.Collections.Generic;
using BoardGameRentalApp.Core.Dto.GameRentals;

namespace BoardGameRentalApp.Core.Dto.Clients
{
    public class ClientDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNumber { get; set; }
        public ICollection<GameRentalDto> GameRentals { get; set; }
        public DateTime CreationTime { get; set; }
    }
}