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

        [HttpGet("[action]")]
        public ActionResult<GetAllGameRentalsOutput> GetAllRentals()
        {
            return _service.GetAll();
        }

        [HttpGet("[action]/{id}")]
        public ActionResult<GetAllGameRentalsOutput> GetRentalsForClient(int id)
        {
            return _service.GetForClient(id);
        }

        [HttpGet("[action]/{id}")]
        public ActionResult<GetAllGameRentalsOutput> GetRentalsForBoardGame(int id)
        {
            return _service.GetForBoardGame(id);
        }

        [HttpGet("[action]/{id}")]
        public ActionResult<GameRentalDto> GetRental(int id)
        {
            return _service.Get(id);
        }

        [HttpPost("[action]")]
        public async Task<GameRentalDto> AddRentalAsync([FromBody]
            CreateGameRentalInput gameRentalInput)
        {
            return await _service.CreateAsync(gameRentalInput);
        }

        [HttpPut("[action]")]
        public async Task<GameRentalDto> UpdateRentalAsync([FromBody]
            GameRentalDto gameRentalInput)
        {
            return await _service.UpdateAsync(gameRentalInput);
        }
    }
}