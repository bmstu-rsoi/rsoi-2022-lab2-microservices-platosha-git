using Microsoft.AspNetCore.Mvc;
using Payments.ModelsDB;

namespace Payments.Controllers
{
    [ApiController]
    [Route("/api/v1/payments")]
    public class ApiPaymentsController : ControllerBase
    {
        private readonly PaymentsWebController _paymentsController;

        public ApiPaymentsController(PaymentsWebController paymentsController)
        {
            _paymentsController = paymentsController;
        }

        /// <summary>Get all Payments</summary>
        /// <returns>Payments information</returns>
        /// <response code="200">All Payments</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Payment>))]
        public IActionResult GetAllPayments()
        {
            List<Payment> payments = _paymentsController.GetAllPayments();
            return Ok(payments);
        }
    }
}