using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Rentals.Api.DataAccess.Entities
{
    public class Rental
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public int ClientId { get; set; }
        public string RentedGames { get; set; }
        public int Status { get; set; }
    }
}