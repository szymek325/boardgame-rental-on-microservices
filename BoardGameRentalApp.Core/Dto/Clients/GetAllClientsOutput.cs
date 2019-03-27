using System.Collections.Generic;

namespace BoardGameRentalApp.Core.Dto.Clients
{
    public class GetAllClientsOutput
    {
        public IEnumerable<ClientDto> Clients { get; set; }
    }
}