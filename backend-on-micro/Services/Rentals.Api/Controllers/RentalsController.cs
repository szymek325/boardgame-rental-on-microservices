using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Rentals.Api.DataAccess;
using Rentals.Api.DataAccess.Entities;
using Rentals.Api.Dto;

namespace Rentals.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRentalsRepository _rentalsRepo;

        public RentalsController(IMapper mapper, IRentalsRepository rentalsRepo)
        {
            _mapper = mapper;
            _rentalsRepo = rentalsRepo;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_rentalsRepo.GetAll());
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<Rental>> GetById(string id)
        {
            return Ok(_rentalsRepo.Get(id));
        }

        [HttpPost("[action]")]
        public async Task Create([FromBody]
            CreateRentalInput input)
        {
            var entity = _mapper.Map<Rental>(input);
            _rentalsRepo.Create(entity);
        }
    }
}