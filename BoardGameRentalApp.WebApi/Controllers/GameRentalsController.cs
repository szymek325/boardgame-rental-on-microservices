using BoardGameRentalApp.Core.Interfaces.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace BoardGameRentalApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameRentalsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public GameRentalsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}