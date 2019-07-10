﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BoardGameRentalApp.Core.Dto.GameRentals;
using BoardGameRentalApp.Core.Entities;
using BoardGameRentalApp.Core.Interfaces.DataAccess;
using BoardGameRentalApp.Core.Models;

namespace BoardGameRentalApp.Core.Services
{
    public interface IGameRentalsService
    {
        GetAllGameRentalsOutput GetAll();
        GameRentalDto Get(int id);
        GetAllGameRentalsOutput GetForClient(int id);
        GetAllGameRentalsOutput GetForBoardGame(int id);
        Task<GameRentalDto> CreateAsync(CreateGameRentalInput input);
        Task<GameRentalDto> UpdateAsync(GameRentalDto input);
    }

    internal class GameRentalsService : IGameRentalsService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GameRentalsService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public GetAllGameRentalsOutput GetAll()
        {
            var clients = _unitOfWork.GameRentalsRepository.GetAll().ToList();
            return MapList(clients);
        }

        public GetAllGameRentalsOutput GetForClient(int id)
        {
            var clients = _unitOfWork.GameRentalsRepository.GetForClient(id);
            return MapList(clients);
        }

        public GetAllGameRentalsOutput GetForBoardGame(int id)
        {
            var clients = _unitOfWork.GameRentalsRepository.GetForBoardGame(id);
            return MapList(clients);
        }

        public GameRentalDto Get(int id)
        {
            var gameRental = _unitOfWork.GameRentalsRepository.GetWithDetails(id);
            var output = _mapper.Map<GameRentalDto>(gameRental);
            return output;
        }

        public async Task<GameRentalDto> CreateAsync(CreateGameRentalInput input)
        {
            var mappedEntity = _mapper.Map<GameRental>(input);
            mappedEntity.Status = Status.InProgress;
            await _unitOfWork.GameRentalsRepository.AddAsync(mappedEntity);
            await _unitOfWork.SaveChangesAsync();
            var result = _mapper.Map<GameRentalDto>(mappedEntity);
            return result;
        }

        public async Task<GameRentalDto> UpdateAsync(GameRentalDto input)
        {
            var mappedEntity = _mapper.Map<Client>(input);
            _unitOfWork.ClientsRepository.Update(mappedEntity);
            await _unitOfWork.SaveChangesAsync();
            var result = _mapper.Map<GameRentalDto>(mappedEntity);
            return result;
        }

        private GetAllGameRentalsOutput MapList(IEnumerable<GameRental> clients)
        {
            var output = _mapper.Map<IEnumerable<GameRentalDto>>(clients);
            return new GetAllGameRentalsOutput(output);
        }
    }
}