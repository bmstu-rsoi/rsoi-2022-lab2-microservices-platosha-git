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

        public List<Payment> GetAllPayments()
        {
            return _paymentsRepository.FindAll();
        }
    }
}
