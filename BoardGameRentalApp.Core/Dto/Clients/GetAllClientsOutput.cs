using System.Collections.Generic;

namespace BoardGameRentalApp.Core.Dto.Clients
{
    public class GetAllClientsOutput
    {
        public GetAllClientsOutput(IEnumerable<ClientDto> clients)
        {
            Clients = clients;
        }

        public IEnumerable<ClientDto> Clients { get; set; }
    }
}