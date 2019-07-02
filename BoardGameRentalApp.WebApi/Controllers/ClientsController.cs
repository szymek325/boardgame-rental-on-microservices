using System.Threading.Tasks;
using BoardGameRentalApp.Core.Dto;
using BoardGameRentalApp.Core.Dto.Clients;
using BoardGameRentalApp.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace BoardGameRentalApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientsService _service;

        public ClientsController(IClientsService service)
        {
            _service = service;
        }

        [HttpGet("[action]")]
        public ActionResult<GetAllClientsOutput> GetAllClients()
        {
            return _service.GetAll();
        }

        [HttpGet("[action]/{id}")]
        public ActionResult<ClientDto> GetClient(int id)
        {
            return _service.Get(id);
        }

        [HttpPost("[action]")]
        public async Task<ClientDto> AddClientAsync([FromBody]
            CreateClientInput clientInput)
        {
            return await _service.CreateAsync(clientInput);
        }

        [HttpDelete("[action]/{id}")]
        public async Task<Result> RemoveClientAsync(int id)
        {
            return await _service.RemoveAsync(id);
        }

        //[HttpPut("[action]")]
        //public async Task<ClientDto> UpdateClientAsync([FromBody]
        //    ClientDto clientInput)
        //{
        //    return await _service.UpdateAsync(clientInput);
        //}
    }
}