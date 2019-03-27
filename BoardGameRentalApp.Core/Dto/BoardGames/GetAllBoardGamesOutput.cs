using System.Collections.Generic;

namespace BoardGameRentalApp.Core.Dto.BoardGames
{
    public class GetAllBoardGamesOutput
    {
        public IEnumerable<BoardGameDto> BoardGames { get; set; }
    }
}