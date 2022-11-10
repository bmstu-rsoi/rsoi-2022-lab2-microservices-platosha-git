using Microsoft.AspNetCore.Mvc;
using Cars.ModelsDB;

namespace Cars.Controllers
{
    [ApiController]
    [Route("/api/v1/cars")]
    public class ApiCarsController : ControllerBase
    {
        private readonly CarsWebController _carsController;

        public ApiCarsController(CarsWebController carsController)
        {
            _carsController = carsController;
        }

        /// <summary>Get all Cars</summary>
        /// <returns>Cars information</returns>
        /// <response code="200">All Cars</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Car>))]
        public IActionResult GetAllCars()
        {
            List<Car> cars = _carsController.GetAllCars();
            return Ok(cars);
        }
    }
}