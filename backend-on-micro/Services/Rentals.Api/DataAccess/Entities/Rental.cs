using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Rentals.Api.Models;

namespace Rentals.Api.DataAccess.Entities
{
    public class Rental
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public int ClientId { get; set; }
        public string RentedGames { get; set; }
        public RentalStatus Status { get; set; }
        public DateTime CreationTimeUtc { get; set; }
        public DateTime ReturnTimeUtc { get; set; }
    }
}