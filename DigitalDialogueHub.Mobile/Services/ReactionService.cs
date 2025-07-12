using System.Net.Http.Json;
using DigitalDialogueHub.Mobile.DTOs;

public class ReactionService
{
    private readonly HttpClient _httpClient;

    public ReactionService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<ReactionDto>> GetAllAsync()
    {
        var result = await _httpClient.GetFromJsonAsync<List<ReactionDto>>("api/Reactions/GetAll");
        return result!;
    }

    public async Task<ReactionDto?> GetAsync(int id)
    {
        var response = await _httpClient.GetAsync($"api/Reactions/Get/{id}");
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<ReactionDto>();
        }
        return null;
    }

    public async Task<ReactionDto?> CreateAsync(ReactionCreateDto dto)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Reactions/Create", dto);
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<ReactionDto>();
        }
        return null;
    }

    public async Task<bool> UpdateAsync(int id, ReactionDto dto)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/Reactions/Update/{id}", dto);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/Reactions/Delete/{id}");
        return response.IsSuccessStatusCode;
    }
}



