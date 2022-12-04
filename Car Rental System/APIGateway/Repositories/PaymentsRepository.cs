using ModelsDTO.Payments;

namespace APIGateway;

public class PaymentsRepository : IPaymentsRepository
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<PaymentsRepository> _logger;

    public PaymentsRepository(HttpClient httpClient, ILogger<PaymentsRepository> logger)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("http://localhost:8050");
        _logger = logger;
    }

    public async Task<PaymentInfo> GetAsyncByUid(Guid paymentUid)
    {
        var response = await _httpClient.GetAsync($"/api/v1/payment/{paymentUid}");
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<PaymentInfo>();
    }
}