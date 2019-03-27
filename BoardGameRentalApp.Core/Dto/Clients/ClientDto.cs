using System;

namespace BoardGameRentalApp.Core.Dto.Clients
{
    public class ClientDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNumber { get; set; }
        public DateTime CreationTime { get; set; }
    }
}