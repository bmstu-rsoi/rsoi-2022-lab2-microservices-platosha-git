using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using ModelsDTO.Rentals;

namespace APIGateway.Controllers
{
    [ApiController]
    [Route("/api/v1/rental")]
    public class RentalsAPIController : ControllerBase
    {
        private readonly RentalsRepository _rentalsRepository;

        public RentalsAPIController(RentalsRepository rentalsRepository)
        {
            _rentalsRepository = rentalsRepository;
        }

        /// <summary>Get all Rentals by username</summary>
        /// <returns>Rentals information</returns>
        /// <response code="200">All Rentals</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationRentalsDTO))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllRentalsByUsername([Required, FromHeader(Name = "X-User-Name")] string username)
        {
            var response = await _rentalsRepository.FindAllByUsername(username);
            return Ok(response);
        }
    }
}