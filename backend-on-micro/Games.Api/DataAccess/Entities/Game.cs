using System;

namespace Games.Api.DataAccess.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime CreationTimeUtc { get; set; }
    }
}