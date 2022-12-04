using System.Net.Http;
using System.Web;
using APIGateway.ModelsDTO;
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
    
    public async Task<List<RentalsDTO>?> GetAllAsyncByUsername(string username)
    {
        var query = HttpUtility.ParseQueryString(string.Empty);
        query["X-User-Name"] = username;

        var response = await _httpClient.GetAsync($"/api/v1/rental/?{query}");
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<List<RentalsDTO>>();
    }

    /*public async Task<RentalsDTO?> FindByUsernameAndUid(string username, Guid rentalUid)
    {
        var query = HttpUtility.ParseQueryString(string.Empty);
        query["X-User-Name"] = username;

        var response = await _httpClient.GetAsync($"/api/v1/rental/{rentalUid}/?{query}");
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<RentalsDTO?>();
    }

    public async Task<RentalsDTO?> CreateRental(RentalsDTO rental)
    {
        var response = await _httpClient.PostAsJsonAsync("/api/v1/rental/", rental);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<RentalsDTO>();
    }
    */
}