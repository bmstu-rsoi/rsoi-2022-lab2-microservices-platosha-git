﻿using System.ComponentModel.DataAnnotations;
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

        /// <summary>Получить список всех доступных для бронирования автомобилей</summary>
        /// <response code="200">Список доступных для бронирования автомобилей</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationCarResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllCars([Range(1, 10)] int page, [Range(1, 10)] int size, bool showAll)
        {
            var response = await _carsRepository.GetAllAsync(page, size, showAll);
            return Ok(response);
        }
    }
}