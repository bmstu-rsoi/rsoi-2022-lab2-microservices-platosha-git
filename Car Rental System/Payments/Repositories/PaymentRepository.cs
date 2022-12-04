using Microsoft.EntityFrameworkCore;
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

        public async Task<Payment> FindByUid(Guid paymentUid)
        {
            try
            {
                var payment = await _db.Payments
                    .FirstOrDefaultAsync(x => x.PaymentUid == paymentUid);
                return payment;

            }
            catch (Exception e)
            {
                _logger.LogError(e, "+ Error while trying to FindByUid");
                throw;
            }
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}