using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using DigitalDialogueHub.Mobile.DTOs;

public class BadgeService
{
    private readonly HttpClient _httpClient;

    public BadgeService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<BadgeDto>> GetAllAsync()
    {
        var result = await _httpClient.GetFromJsonAsync<List<BadgeDto>>("api/Badges/GetAll");
        return result!;
    }

    public async Task<BadgeDto?> GetAsync(int id)
    {
        var response = await _httpClient.GetAsync($"api/Badges/Get/{id}");
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<BadgeDto>();
        }
        return null;
    }

    public async Task<BadgeDto?> CreateAsync(BadgeDto badge)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Badges/Create", badge);
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<BadgeDto>();
        }
        return null;
    }

    public async Task<bool> UpdateAsync(int id, BadgeDto badge)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/Badges/Update/{id}", badge);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/Badges/Delete/{id}");
        return response.IsSuccessStatusCode;
    }
}
