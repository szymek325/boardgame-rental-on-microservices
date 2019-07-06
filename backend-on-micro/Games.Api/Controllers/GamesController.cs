using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Games.Api.DataAccess.Context;
using Games.Api.DataAccess.Entities;
using Games.Api.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Games.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly GamesDbContext _gamesDbContext;
        private readonly IMapper _mapper;

        public GamesController(GamesDbContext gamesDbContext, IMapper mapper)
        {
            _gamesDbContext = gamesDbContext ?? throw new ArgumentNullException(nameof(gamesDbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _gamesDbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<Game>>> GetAll()
        {
            return await _gamesDbContext.Games.ToListAsync();
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<Game>> GetById(int id)
        {
            return await _gamesDbContext.Games.SingleOrDefaultAsync(x => x.Id.Equals(id));
        }

        [HttpPost("[action]")]
        public async Task Create([FromBody]
            CreateGameInput input)
        {
            var entity = _mapper.Map<Game>(input);
            await _gamesDbContext.Games.AddAsync(entity);
            await _gamesDbContext.SaveChangesAsync();
        }
    }
}