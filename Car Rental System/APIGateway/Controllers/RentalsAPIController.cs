using System.ComponentModel.DataAnnotations;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using ModelsDTO.Rentals;

namespace APIGateway.Controllers
{
    [ApiController]
    [Route("/api/v1/rental")]
    public class RentalsAPIController : ControllerBase
    {
        private readonly RentalsRepository _rentalsRepository;
        private readonly ILogger<RentalsRepository> _logger;

        public RentalsAPIController(RentalsRepository rentalsRepository, ILogger<RentalsRepository> logger)
        {
            _rentalsRepository = rentalsRepository;
            _logger = logger;
        }

        /// <summary>Получить информацию о всех арендах пользователя</summary>
        /// <param name="X-User-Name">Имя пользователя</param>
        /// <response code="200">Информация обо всех арендах</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<RentalsDTO>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllRentalsByUsername([Required, FromHeader(Name = "X-User-Name")] string username)
        {
            try
            {
                var response = await _rentalsRepository.FindAllByUsername(username);
                return Ok(response);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "+ Error occurred trying GetAllRentalsByUsername!");
                throw;
            }
            
        }
        
        /// <summary>Информация по конкретной аренде пользователя</summary>
        /// <param name="rentalUid">UUID аренды</param>
        /// <param name="X-User-Name">Имя пользователя</param>
        /// <response code="200">Информация по конкретному бронированию</response>
        /// <response code="404">Билет не найден</response>
        // Glen
        // 8b33afd0-9850-41c8-8325-32b5ea91759c
        [HttpGet("{rentalUid:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RentalsDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetRentalByUid([Required, FromHeader(Name = "X-User-Name")] string username,
            Guid rentalUid)
        {
            try
            {
                var response = await _rentalsRepository.FindByUsernameAndUid(username, rentalUid);
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
    }
}