using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using DigitalDialogueHub.Mobile.DTOs;

public class DiscussionService
{
    private readonly HttpClient _httpClient;

    public DiscussionService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<DiscussionDto>> GetAllAsync()
    {
        var result = await _httpClient.GetFromJsonAsync<List<DiscussionDto>>("api/Discussions/GetAll");
        return result!;
    }

    public async Task<DiscussionDto?> GetAsync(int id)
    {
        var response = await _httpClient.GetAsync($"api/Discussions/Get/{id}");
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<DiscussionDto>();
        }
        return null;
    }

    public async Task<DiscussionDto?> CreateAsync(DiscussionCreateDto discussion)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Discussions/Create", discussion);
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<DiscussionDto>();
        }
        return null;
    }

    public async Task<bool> UpdateAsync(int id, DiscussionUpdateDto discussion)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/Discussions/Update/{id}", discussion);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> UpdatePartialAsync(int id, DiscussionPartialUpdateDto discussion)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/Discussions/UpdatePartial/{id}", discussion);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/Discussions/Delete/{id}");
        return response.IsSuccessStatusCode;
    }
}
