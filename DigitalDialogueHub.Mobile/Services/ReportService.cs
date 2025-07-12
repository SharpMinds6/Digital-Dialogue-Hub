using System.Net.Http.Json;
using DigitalDialogueHub.Mobile.DTOs;

public class ReportService
{
    private readonly HttpClient _httpClient;

    public ReportService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<ReportDto>> GetAllAsync()
    {
        var result = await _httpClient.GetFromJsonAsync<List<ReportDto>>("api/Reports/GetAll");
        return result!;
    }

    public async Task<ReportDto?> GetAsync(int id)
    {
        var response = await _httpClient.GetAsync($"api/Reports/Get/{id}");
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<ReportDto>();
        }
        return null;
    }

    public async Task<ReportDto?> CreateAsync(ReportDto dto)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Reports/Create", dto);
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<ReportDto>();
        }
        return null;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/Reports/Delete/{id}");
        return response.IsSuccessStatusCode;
    }
}

