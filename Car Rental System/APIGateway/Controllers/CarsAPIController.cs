using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using ModelsDTO.Cars;

namespace APIGateway.Controllers
{
    [ApiController]
    [Route("/api/v1/cars")]
    public class CarsAPIController : ControllerBase
    {
        private readonly CarsRepository _carsRepository;

        public CarsAPIController(CarsRepository carsRepository)
        {
            _carsRepository = carsRepository;
        }

        /// <summary>Get all Cars</summary>
        /// <returns>Cars information</returns>
        /// <response code="200">All Cars</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationCarsDTO))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllCars([Range(1, 10)] int page, [Range(1, 10)] int size, bool showAll)
        {
            var response = await _carsRepository.FindAll(page, size, showAll);
            return Ok(response);
        }
    }
}