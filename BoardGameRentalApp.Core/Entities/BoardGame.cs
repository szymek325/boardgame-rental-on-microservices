namespace BoardGameRentalApp.Core.Entities
{
    public class BoardGame : BaseEntity
    {
        public string Name { get; set; }
        public float PricePerDay { get; set; }
        public float Bail { get; set; }
    }
}