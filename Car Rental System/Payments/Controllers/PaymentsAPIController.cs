using Microsoft.AspNetCore.Mvc;
using ModelsDTO.Payments;
using Payments.ModelsDB;

namespace Payments.Controllers
{
    [ApiController]
    [Route("/api/v1/payment")]
    public class PaymentsAPIController : ControllerBase
    {
        private readonly PaymentsWebController _paymentsController;

        public PaymentsAPIController(PaymentsWebController paymentsController)
        {
            _paymentsController = paymentsController;
        }

        private PaymentInfo InitPaymentInfo(Payment payment)
        {
            PaymentInfo paymentInfo = new PaymentInfo()
            {
                PaymentUid = payment.PaymentUid,
                Status = payment.Status,
                Price = payment.Price
            };
            return paymentInfo;
        }

        /// <summary>Получить оплату по Uuid</summary>
        [HttpGet("{paymentUid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaymentInfo))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPaymentByUid(Guid paymentUid)
        {
            var payment = await _paymentsController.GetPaymentByUid(paymentUid);
            var response = InitPaymentInfo(payment);
            
            return Ok(response);
        }
    }
}