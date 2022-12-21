﻿using Microsoft.Extensions.Options;
using ModelsDTO.Cars;

namespace APIGateway;

public class CarsSettings
{
    public Uri Host { get; set; }
}

public class CarsRepository : ICarsRepository
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<CarsRepository> _logger;

    public CarsRepository(IOptions<CarsSettings> settings, HttpClient httpClient, ILogger<CarsRepository> logger)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = settings.Value.Host;
        _logger = logger;
    }

    public async Task<PaginationCarResponse?> GetAllAsync(int page, int size, bool showAll)
    {
        var response = await _httpClient.GetAsync($"/api/v1/cars/?page={page}&size={size}&showAll={showAll}");
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<PaginationCarResponse>();
    }
    
    public async Task<CarResponse> GetAsyncByUid(Guid carUid)
    {
        var response = await _httpClient.GetAsync($"/api/v1/cars/{carUid}");
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<CarResponse>();
    }

    public async Task<CarResponse> ReserveCar(Guid carUid, bool availability)
    {
        var request = new HttpRequestMessage(new HttpMethod("PATCH"), $"/api/v1/cars/{carUid}/?availability={availability}");
        var response = await _httpClient.SendAsync(request);
        
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<CarResponse>();
    }
}