using System.Collections.Generic;

namespace BoardGameRentalApp.Core.Dto.BoardGames
{
    public class GetAllBoardGamesOutput
    {
        public GetAllBoardGamesOutput(IEnumerable<BoardGameDto> boardGames)
        {
            BoardGames = boardGames;
        }

        public IEnumerable<BoardGameDto> BoardGames { get; set; }
    }
}