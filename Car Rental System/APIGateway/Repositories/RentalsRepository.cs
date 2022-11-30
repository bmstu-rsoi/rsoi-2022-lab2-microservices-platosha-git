using System.Web;
using ModelsDTO.Rentals;

namespace APIGateway;

public class RentalsRepository : IRentalsRepository
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<RentalsRepository> _logger;

    public RentalsRepository(HttpClient httpClient, ILogger<RentalsRepository> logger)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("http://localhost:8060");
        _logger = logger;
    }

    public async Task<PaginationRentalsDTO?> FindAllByUsername(string username)
    {
        var query = HttpUtility.ParseQueryString(string.Empty);
        query["X-User-Name"] = username;

        var response = await _httpClient.GetAsync($"/api/v1/rental/?{query}");
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<PaginationRentalsDTO>();
    }
}