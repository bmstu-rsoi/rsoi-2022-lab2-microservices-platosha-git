using ModelsDTO.Cars;

namespace APIGateway;

public class CarsRepository : ICarsRepository
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<CarsRepository> _logger;

    public CarsRepository(HttpClient httpClient, ILogger<CarsRepository> logger)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("http://localhost:8070");
        _logger = logger;
    }

    public async Task<PaginationCarsDTO?> FindAll(int page, int size, bool showAll)
    {
        var response = await _httpClient.GetAsync($"/api/v1/cars/?page={page}&size={size}&showAll={showAll}");
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<PaginationCarsDTO>();
    }
}