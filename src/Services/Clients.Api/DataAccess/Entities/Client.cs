using System;

namespace Clients.Api.DataAccess.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNumber { get; set; }
        public DateTime CreationTimeUtc { get; set; }
    }
}