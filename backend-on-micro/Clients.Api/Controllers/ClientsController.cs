using System.Collections.Generic;
using Clients.Api.DataAccess.Context;
using Clients.Api.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Clients.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly ClientsContext _clientsContext;

        public ClientsController(ClientsContext clientsContext)
        {
            _clientsContext = clientsContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Client>> GetAll()
        {
            return new List<Client>();
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]
            string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]
            string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}