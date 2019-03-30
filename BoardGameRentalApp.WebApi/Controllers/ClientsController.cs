using System.Threading.Tasks;
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

        [HttpGet]
        public ActionResult<GetAllClientsOutput> GetAll()
        {
            return _service.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<ClientDto> Get(int id)
        {
            return _service.Get(id);
        }

        [HttpPost]
        public async Task<ClientDto> CreateAsync([FromBody]
            CreateClientInput clientInput)
        {
            return await _service.CreateAsync(clientInput);
        }

        [HttpPut]
        public async Task<ClientDto> UpdateAsync([FromBody]
            ClientDto clientInput)
        {
            return await _service.UpdateAsync(clientInput);
        }

        [HttpDelete]
        public async Task<ClientDto> RemoveAsync([FromBody]
            ClientDto clientInput)
        {
            return await _service.RemoveAsync(clientInput);
        }
    }
}