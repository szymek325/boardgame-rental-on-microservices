using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BoardGameRentalApp.Core.Dto.BoardGames;
using BoardGameRentalApp.Core.Entities;
using BoardGameRentalApp.Core.Interfaces.DataAccess;

namespace BoardGameRentalApp.Core.Services
{
    public interface IBoardGamesService
    {
        GetAllBoardGamesOutput GetAll();
        BoardGameDto Get(int id);
        Task<BoardGameDto> CreateAsync(CreateBoardGameInput input);
        Task<BoardGameDto> UpdateAsync(BoardGameDto input);
        Task<BoardGameDto> RemoveAsync(BoardGameDto input);
    }

    internal class BoardGamesService : IBoardGamesService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public BoardGamesService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public GetAllBoardGamesOutput GetAll()
        {
            var boardGames = _unitOfWork.BoardGamesRepository.GetAll();
            var output = _mapper.Map<IEnumerable<BoardGameDto>>(boardGames);
            return new GetAllBoardGamesOutput(output);
        }

        public BoardGameDto Get(int id)
        {
            var boardGame = _unitOfWork.BoardGamesRepository.GetWithDetails(id);
            var output = _mapper.Map<BoardGameDto>(boardGame);
            return output;
        }

        public async Task<BoardGameDto> CreateAsync(CreateBoardGameInput input)
        {
            var mappedEntity = _mapper.Map<BoardGame>(input);
            await _unitOfWork.BoardGamesRepository.AddAsync(mappedEntity);
            await _unitOfWork.SaveChangesAsync();
            var result = _mapper.Map<BoardGameDto>(mappedEntity);
            return result;
        }

        public async Task<BoardGameDto> UpdateAsync(BoardGameDto input)
        {
            var mappedEntity = _mapper.Map<BoardGame>(input);
            _unitOfWork.BoardGamesRepository.Update(mappedEntity);
            await _unitOfWork.SaveChangesAsync();
            var result = _mapper.Map<BoardGameDto>(mappedEntity);
            return result;
        }

        public async Task<BoardGameDto> RemoveAsync(BoardGameDto input)
        {
            var mappedEntity = _mapper.Map<BoardGame>(input);
            _unitOfWork.BoardGamesRepository.Remove(mappedEntity);
            await _unitOfWork.SaveChangesAsync();
            var result = _mapper.Map<BoardGameDto>(mappedEntity);
            return result;
        }
    }
}