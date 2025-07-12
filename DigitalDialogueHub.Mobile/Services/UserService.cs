using System.Net.Http.Json;
using DigitalDialogueHub.Mobile.DTOs;

public class UserService
{
    private readonly HttpClient _httpClient;

    public UserService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<UserDto>> GetAllAsync()
    {
        var result = await _httpClient.GetFromJsonAsync<List<UserDto>>("api/Users/GetAll");
        return result!;
    }

    public async Task<UserDto?> GetAsync(int id)
    {
        var response = await _httpClient.GetAsync($"api/Users/Get/{id}");
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<UserDto>();
        }
        return null;
    }

    public async Task<UserDto?> CreateAsync(UserDto dto)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Users/Create", dto);
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<UserDto>();
        }
        return null;
    }

    public async Task<bool> UpdateAsync(int id, UserDto dto)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/Users/Update/{id}", dto);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/Users/Delete/{id}");
        return response.IsSuccessStatusCode;
    }
}



