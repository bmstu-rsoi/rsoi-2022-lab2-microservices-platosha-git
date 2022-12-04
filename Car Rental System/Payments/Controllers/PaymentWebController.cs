using Payments.ModelsDB;
using Payments.Repositories;

namespace Payments.Controllers
{
    public class PaymentsWebController
    {
        private readonly IPaymentsRepository _paymentsRepository;

        public PaymentsWebController(IPaymentsRepository paymentsRepository)
        {
            _paymentsRepository = paymentsRepository;
        }

        public async Task<Payment> GetPaymentByUid(Guid paymentUid)
        {
            return await _paymentsRepository.FindByUid(paymentUid);
        }
    }
}
