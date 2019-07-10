using System.Collections.Generic;

namespace Rentals.Api.Dto
{
    public class CreateRentalInput
    {
        public int ClientId { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }

    public class Product
    {
        public int Id { get; set; }
    }
}