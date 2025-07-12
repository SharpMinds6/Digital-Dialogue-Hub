using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using DigitalDialogueHub.Mobile.DTOs;

public class CommentService
{
    private readonly HttpClient _httpClient;

    public CommentService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<CommentDto>> GetAllAsync()
    {
        var result = await _httpClient.GetFromJsonAsync<List<CommentDto>>("api/Comments/GetAll");
        return result!;
    }

    public async Task<CommentDto?> GetAsync(int id)
    {
        var response = await _httpClient.GetAsync($"api/Comments/Get/{id}");
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<CommentDto>();
        }
        return null;
    }

    public async Task<CommentDto?> CreateAsync(CommentCreateDto comment)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Comments/Create", comment);
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<CommentDto>();
        }
        return null;
    }

    public async Task<bool> UpdateAsync(int id, CommentUpdateDto comment)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/Comments/Update/{id}", comment);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> UpdatePartialAsync(int id, CommentPartialUpdateDto comment)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/Comments/UpdatePartial/{id}", comment);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/Comments/Delete/{id}");
        return response.IsSuccessStatusCode;
    }
}
