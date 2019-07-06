using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Clients.Api.DataAccess.Context;
using Clients.Api.DataAccess.Entities;
using Clients.Api.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clients.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly ClientsContext _clientsContext;
        private readonly IMapper _mapper;

        public ClientsController(ClientsContext clientsContext, IMapper mapper)
        {
            _clientsContext = clientsContext ?? throw new ArgumentNullException(nameof(clientsContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _clientsContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<Client>>> GetAll()
        {
            return await _clientsContext.Clients.ToListAsync();
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<Client>> GetById(int id)
        {
            return await _clientsContext.Clients.SingleOrDefaultAsync(x => x.Id.Equals(id));
        }

        [HttpPost("[action]")]
        public async Task Create([FromBody]
            CreateClientInput input)
        {
            var entity = _mapper.Map<Client>(input);
            await _clientsContext.Clients.AddAsync(entity);
            await _clientsContext.SaveChangesAsync();
        }
    }
}