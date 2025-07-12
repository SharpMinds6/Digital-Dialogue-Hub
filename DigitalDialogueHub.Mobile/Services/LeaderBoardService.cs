using System.Net.Http.Json;
using DigitalDialogueHub.Mobile.DTOs;
using DigitalDialogueHub.Mobile.ViewModels;

public class LeaderboardService
{
    private readonly HttpClient _httpClient;

    public LeaderboardService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<LeaderboardDto>> GetAllAsync()
    {
        var result = await _httpClient.GetFromJsonAsync<List<LeaderboardDto>>("api/Leaderboards/GetAll");
        return result!;
    }

    public async Task<LeaderboardDto?> GetAsync(int id)
    {
        var response = await _httpClient.GetAsync($"api/Leaderboards/Get/{id}");
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<LeaderboardDto>();
        }
        return null;
    }

    public async Task<LeaderboardDto?> CreateAsync(LeaderboardDto dto)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Leaderboards/Create", dto);
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<LeaderboardDto>();
        }
        return null;
    }

    public async Task<bool> UpdateAsync(int id, LeaderboardDto dto)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/Leaderboards/Update/{id}", dto);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/Leaderboards/Delete/{id}");
        return response.IsSuccessStatusCode;
    }
}


