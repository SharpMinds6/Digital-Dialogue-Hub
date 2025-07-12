using System.Net.Http.Json;
using DigitalDialogueHub.Mobile.DTOs;

public class NotificationService
{
    private readonly HttpClient _httpClient;

    public NotificationService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<NotificationDto>> GetAllAsync()
    {
        var result = await _httpClient.GetFromJsonAsync<List<NotificationDto>>("api/Notifications/GetAll");
        return result!;
    }

    public async Task<NotificationDto?> GetAsync(int id)
    {
        var response = await _httpClient.GetAsync($"api/Notifications/Get/{id}");
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<NotificationDto>();
        }
        return null;
    }

    public async Task<NotificationDto?> CreateAsync(NotificationCreateDto dto)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Notifications/Create", dto);
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<NotificationDto>();
        }
        return null;
    }

    public async Task<bool> UpdateAsync(int id, NotificationDto dto)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/Notifications/Update/{id}", dto);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/Notifications/Delete/{id}");
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> NotifyAllAsync(string message)
    {
        var response = await _httpClient.PostAsync($"api/Notifications/NotifyAll?message={Uri.EscapeDataString(message)}", null);
        return response.IsSuccessStatusCode;
    }
}



