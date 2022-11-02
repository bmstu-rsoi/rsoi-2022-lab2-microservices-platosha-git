using Microsoft.AspNetCore.Mvc;
using Rentals.WebControllers;
using Rentals.ModelsDB;

namespace Rentals.APIControllers
{
    [ApiController]
    [Route("/api/v1/rentals")]
    public class ApiRentalsController : ControllerBase
    {
        private readonly RentalsController _rentalsController;

        public ApiRentalsController(RentalsController rentalsController)
        {
            _rentalsController = rentalsController;
        }

        /// <summary>Get all Rentals</summary>
        /// <returns>Rentals information</returns>
        /// <response code="200">All Rentals</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Rental>))]
        public IActionResult GetAllCars()
        {
            List<Rental> rentals = _rentalsController.GetAllRentals();
            return Ok(rentals);
        }
    }
}