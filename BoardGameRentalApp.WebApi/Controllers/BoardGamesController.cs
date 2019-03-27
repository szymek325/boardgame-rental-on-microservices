using System;
using System.Collections.Generic;
using BoardGameRentalApp.Core.Dto.BoardGames;
using BoardGameRentalApp.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BoardGameRentalApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardGamesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<BoardGameDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public ActionResult<BoardGameDto> Get(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult<int> Add([FromBody]
            BoardGame boardGame)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public ActionResult Remove(BoardGame boardGame)
        {
            throw new NotImplementedException();
        }
    }
}