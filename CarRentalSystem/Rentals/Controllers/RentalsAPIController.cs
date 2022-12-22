using System.ComponentModel.DataAnnotations;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using ModelsDTO.Cars;
using Rentals.ModelsDB;
using ModelsDTO.Rentals;

namespace Rentals.Controllers
{
    [ApiController]
    [Route("/api/v1/rental")]
    public class RentalsAPIController : ControllerBase
    {
        private readonly RentalsWebController _rentalsController;
        private readonly ILogger<RentalsWebController> _logger;

        public RentalsAPIController(RentalsWebController rentalsController, ILogger<RentalsWebController> logger)
        {
            _rentalsController = rentalsController;
            _logger = logger;
        }

        private Rental GetRentalFromDTO(RentalsDTO rentalDTO)
        {
            var rental = new Rental()
            {
                Id = 0,
                RentalUid = rentalDTO.RentalUid,
                Username = rentalDTO.Username,
                PaymentUid = rentalDTO.PaymentUid,
                CarUid = rentalDTO.CarUid,
                DateFrom = rentalDTO.DateFrom.UtcDateTime,
                DateTo = rentalDTO.DateTo.UtcDateTime,
                Status = rentalDTO.Status
            };
            return rental;
        }

        private RentalsDTO? InitRentalsDTO(Rental? rental)
        {
            if (rental == null) return null;
            
            RentalsDTO rentalDTO = new RentalsDTO()
            {
                RentalUid = rental.RentalUid,
                Username = rental.Username,
                PaymentUid = rental.PaymentUid,
                CarUid = rental.CarUid,
                DateFrom = rental.DateFrom,
                DateTo = rental.DateTo,
                Status = rental.Status
            };

            return rentalDTO;
        }

        private List<RentalsDTO> ListRentalsDTO(List<Rental> lRentals)
        {
            List<RentalsDTO> lRentalsDTO = new List<RentalsDTO>();
            foreach (var rental in lRentals)
            {
                RentalsDTO rentalDTO = InitRentalsDTO(rental);
                lRentalsDTO.Add(rentalDTO);
            }

            return lRentalsDTO;
        }

        /// <summary>Получить информацию о всех арендах пользователя</summary>
        /// <param name="X-User-Name"> Имя пользователя </param>
        /// <returns>Информация обо всех арендах</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<RentalsDTO>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetRentalsByUsername([Required, FromQuery(Name = "X-User-Name")] string username)
        {
            try
            {
                var rentals = await _rentalsController.GetAllRentalsByUsername(username);
                var response = ListRentalsDTO(rentals);
                return Ok(response);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "+ Error occurred trying GetRentalsByUsername!");
                throw;
            }
        }

        // Glen
        // 8b33afd0-9850-41c8-8325-32b5ea91759c
        [HttpGet("{rentalUid:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RentalsDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetRentalByUid([Required, FromQuery(Name = "X-User-Name")] string username,
            Guid rentalUid)
        {
            try
            {
                var rental = await _rentalsController.GetRentalByRentalUid(username, rentalUid);
                var response = InitRentalsDTO(rental);
                return Ok(response);
            }
            catch (HttpRequestException e) when (e.StatusCode == HttpStatusCode.NotFound)
            {
                return NotFound(username);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "+ Error occurred trying GetRentalByRentalUid!");
                throw;
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(RentalsDTO))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateRental([FromBody] RentalsDTO rentalDTO)
        {
            var rentalToAdd = GetRentalFromDTO(rentalDTO);
            var addedRental = await _rentalsController.AddRental(rentalToAdd);

            var response = InitRentalsDTO(addedRental);
            return Created($"/api/v1/{addedRental.Id}", response);
        }
        
        [HttpPatch("{username}/{rentalUid}/{status}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RentalsDTO))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> FinishRent(string username, Guid rentalUid, string status)
        {
            var rental = await _rentalsController.GetRentalByRentalUid(username, rentalUid);
            rental.Status = status;
            await _rentalsController.FinishRent(rental);

            var response = InitRentalsDTO(rental);
            return Ok(response);
        }
    }
}