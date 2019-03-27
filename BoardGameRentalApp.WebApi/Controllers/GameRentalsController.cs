using System.Threading.Tasks;
using BoardGameRentalApp.Core.Dto.GameRentals;
using BoardGameRentalApp.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace BoardGameRentalApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameRentalsController : ControllerBase
    {
        private readonly IGameRentalsService _service;

        public GameRentalsController(IGameRentalsService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<GetAllGameRentalsOutput> GetAll()
        {
            return _service.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<GameRentalDto> Get(int id)
        {
            return _service.Get(id);
        }

        [HttpPost]
        public async Task<GameRentalDto> Create([FromBody]
            CreateGameRentalInput gameRentalInput)
        {
            return await _service.CreateAsync(gameRentalInput);
        }

        [HttpPut]
        public async Task<GameRentalDto> Update([FromBody]
            GameRentalDto gameRentalInput)
        {
            return await _service.UpdateAsync(gameRentalInput);
        }
    }
}