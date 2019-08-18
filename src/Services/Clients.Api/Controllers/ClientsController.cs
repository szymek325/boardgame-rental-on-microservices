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
        private readonly ClientsDbContext _clientsDbContext;
        private readonly IMapper _mapper;

        public ClientsController(ClientsDbContext clientsDbContext, IMapper mapper)
        {
            _clientsDbContext = clientsDbContext ?? throw new ArgumentNullException(nameof(clientsDbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _clientsDbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<Client>>> GetAll()
        {
            return await _clientsDbContext.Clients.ToListAsync();
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<Client>> GetById(int id)
        {
            return await _clientsDbContext.Clients.SingleOrDefaultAsync(x => x.Id.Equals(id));
        }

        [HttpPost("[action]")]
        public async Task Create([FromBody]
            CreateClientInput input)
        {
            var entity = _mapper.Map<Client>(input);
            await _clientsDbContext.Clients.AddAsync(entity);
            await _clientsDbContext.SaveChangesAsync();
        }
    }
}