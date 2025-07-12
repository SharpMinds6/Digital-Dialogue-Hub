using System.Net.Http.Json;
using DigitalDialogueHub.Mobile.DTOs;

public class UserBadgeService
{
    private readonly HttpClient _httpClient;

    public UserBadgeService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<UserBadgeDto>> GetAllAsync()
    {
        var result = await _httpClient.GetFromJsonAsync<List<UserBadgeDto>>("api/UserBadges/GetAll");
        return result!;
    }

    public async Task<UserBadgeDto?> GetAsync(int id)
    {
        var response = await _httpClient.GetAsync($"api/UserBadges/Get/{id}");
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<UserBadgeDto>();
        }
        return null;
    }

    public async Task<UserBadgeDto?> CreateAsync(UserBadgeCreateDto dto)
    {
        var response = await _httpClient.PostAsJsonAsync("api/UserBadges/Create", dto);
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<UserBadgeDto>();
        }
        return null;
    }

    public async Task<bool> UpdateAsync(int id, UserBadgeDto dto)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/UserBadges/Update/{id}", dto);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/UserBadges/Delete/{id}");
        return response.IsSuccessStatusCode;
    }
}



