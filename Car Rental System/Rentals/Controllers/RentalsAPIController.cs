using System.ComponentModel.DataAnnotations;
using System.Net;
using Microsoft.AspNetCore.Mvc;
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
        
        private List<RentalsDTO> ListRentalsDTO(List<Rental> lRentals)
        {
            List<RentalsDTO> lRentalsDTO = new List<RentalsDTO>();
            foreach (var rental in lRentals)
            {
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
                
                lRentalsDTO.Add(rentalDTO);
            }

            return lRentalsDTO;
        }
        
        /*
        /// <summary>Get all Rentals</summary>
        /// <param name="page"> Page number </param>
        /// <param name="size"> Number of elements per page </param>
        /// <returns>Rentals information</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationRentalsDTO))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllRentals([Range(1, int.MaxValue)] int page, [Range(1, 100)] int size)
        {
            var rentals = await _rentalsController.GetAllRentals(page, size);
            
            var response = new PaginationRentalsDTO()
            {
                PageSize = size,
                Page = page,
                TotalElements = rentals.Count,
                Rentals = ListRentalsDTO(rentals)
            };
            
            return Ok(response);
        }
        */

        /// <summary>Get rentals by username </summary>
        /// <param name="username"> Username </param>
        /// <param name="page"> Page number </param>
        /// <param name="size"> Number of elements per page </param>
        /// <returns>Rentals information</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationRentalsDTO))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetRentalsByUsername([Required, FromQuery(Name = "X-User-Name")] string username)
        {
            try
            {
                var rentals = await _rentalsController.GetRentalsByUsername(username);

                var response = new PaginationRentalsDTO()
                {
                    TotalElements = rentals.Count,
                    Rentals = ListRentalsDTO(rentals)
                };

                return Ok(response);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "+ Error occurred trying GetRentalsByUsername!");
                throw;
            }
        }
        
        // [HttpGet("{rentalUid:guid}")]
        // [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RentalsDTO))]
        // [ProducesResponseType(StatusCodes.Status404NotFound)]
        // [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // public async Task<IActionResult> GetRentalByUid([Required, FromHeader(Name = "X-User-Name")] string username,
        //     Guid rentalUid)
        // {
        //     try
        //     {
        //         var rental = await _rentalsController.GetRentalByRentalUid(username, rentalUid);
        //         return Ok(rental);
        //     }
        //     catch (HttpRequestException e) when (e.StatusCode == HttpStatusCode.NotFound)
        //     {
        //         return NotFound(username);
        //     }
        //     catch (Exception e)
        //     {
        //         _logger.LogError(e, "+ Error occurred trying GetRentalByRentalUid!");
        //         throw;
        //     }
        // }
    }
}