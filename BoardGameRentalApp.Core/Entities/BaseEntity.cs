using System;

namespace BoardGameRentalApp.Core.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreationTime { get; set; }
    }
}