using System.Threading.Tasks;
using BoardGameRentalApp.Core.Dto.BoardGames;
using BoardGameRentalApp.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace BoardGameRentalApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardGamesController : ControllerBase
    {
        private readonly IBoardGamesService _service;

        public BoardGamesController(IBoardGamesService service)
        {
            _service = service;
        }

        [HttpGet("[action]")]
        public ActionResult<GetAllBoardGamesOutput> GetAllBoardGames()
        {
            return _service.GetAll();
        }

        [HttpGet("[action]")]
        public ActionResult<GetAllBoardGamesOutput> GetAllBoardGamesAvailableForRental()
        {
            return _service.GetAllAvailableForRental();
        }

        [HttpGet("[action]/{id}")]
        public ActionResult<BoardGameDto> GetBoardGame(int id)
        {
            return _service.Get(id);
        }

        [HttpPost("[action]")]
        public async Task<BoardGameDto> AddBoardGameAsync([FromBody]
            CreateBoardGameInput boardGameInput)
        {
            return await _service.CreateAsync(boardGameInput);
        }

        [HttpPut("[action]")]
        public async Task<BoardGameDto> UpdateBoardGameAsync([FromBody]
            BoardGameDto boardGameInput)
        {
            return await _service.UpdateAsync(boardGameInput);
        }

        [HttpDelete("[action]")]
        public async Task<BoardGameDto> RemoveBoardGameAsync([FromBody]
            BoardGameDto clientInput)
        {
            return await _service.RemoveAsync(clientInput);
        }
    }
}