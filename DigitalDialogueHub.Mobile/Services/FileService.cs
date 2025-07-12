using System.Net.Http.Json;
using DigitalDialogueHub.Mobile.DTOs;

public class FileService
{
    private readonly HttpClient _httpClient;

    public FileService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<FileDto>> GetAllAsync()
    {
        var result = await _httpClient.GetFromJsonAsync<List<FileDto>>("api/Files/GetAll");
        return result!;
    }

    public async Task<FileDto?> GetAsync(int id)
    {
        var response = await _httpClient.GetAsync($"api/Files/Get/{id}");
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<FileDto>();
        }
        return null;
    }

    public async Task<FileDto?> CreateAsync(FileDto dto)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Files/Create", dto);
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<FileDto>();
        }
        return null;
    }

    public async Task<bool> UpdateAsync(int id, FileDto dto)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/Files/Update/{id}", dto);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/Files/Delete/{id}");
        return response.IsSuccessStatusCode;
    }
}
