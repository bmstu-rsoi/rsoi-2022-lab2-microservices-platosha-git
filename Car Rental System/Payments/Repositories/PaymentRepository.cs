using Payments.ModelsDB;

namespace Payments.Repositories
{
    public class PaymentsRepository : IPaymentsRepository, IDisposable
    {
        private readonly PaymentContext _db;
        private readonly ILogger<PaymentsRepository> _logger;

        public PaymentsRepository(PaymentContext createDb, ILogger<PaymentsRepository> logDb)
        {
            _db = createDb;
            _logger = logDb;
        }

        public List<Payment> FindAll()
        {
            var payments = _db.Payments.ToList();
            return payments;
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}