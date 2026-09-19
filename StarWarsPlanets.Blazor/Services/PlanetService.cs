using System.Net.Http.Json;
using StarWarsPlanets.Blazor.Models;

namespace StarWarsPlanets.Blazor.Services;

public class PlanetService
{
    private readonly HttpClient _httpClient;

    public PlanetService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Planet>> GetPlanetsAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Planet>>("api/planets") 
            ?? new List<Planet>();
    }

    public async Task<bool> CreatePlanetAsync(Planet planet)
    {
        var response = await _httpClient.PostAsJsonAsync("api/planets", planet);

        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeletePlanetAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/planets/{id}");
        
        return response.IsSuccessStatusCode;
    }
}
