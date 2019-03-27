using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BoardGameRentalApp.Core.Dto.Clients;
using BoardGameRentalApp.Core.Entities;
using BoardGameRentalApp.Core.Interfaces.DataAccess;

namespace BoardGameRentalApp.Core.Services
{
    public interface IClientsService
    {
        GetAllClientsOutput GetAll();
        ClientDto Get(int id);
        Task<ClientDto> CreateAsync(CreateClientInput input);
        Task<ClientDto> UpdateAsync(ClientDto input);
    }

    internal class ClientsService : IClientsService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ClientsService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public GetAllClientsOutput GetAll()
        {
            var clients = _unitOfWork.ClientsRepository.GetAll();
            var output = _mapper.Map<IEnumerable<ClientDto>>(clients);
            return new GetAllClientsOutput(output);
        }

        public ClientDto Get(int id)
        {
            var client = _unitOfWork.ClientsRepository.Get(id);
            var output = _mapper.Map<ClientDto>(client);
            return output;
        }

        public async Task<ClientDto> CreateAsync(CreateClientInput input)
        {
            var mappedEntity = _mapper.Map<Client>(input);
            await _unitOfWork.ClientsRepository.AddAsync(mappedEntity);
            await _unitOfWork.SaveChangesAsync();
            var result = _mapper.Map<ClientDto>(mappedEntity);
            return result;
        }

        public async Task<ClientDto> UpdateAsync(ClientDto input)
        {
            var mappedEntity = _mapper.Map<Client>(input);
            _unitOfWork.ClientsRepository.Update(mappedEntity);
            await _unitOfWork.SaveChangesAsync();
            var result = _mapper.Map<ClientDto>(mappedEntity);
            return result;
        }
    }
}