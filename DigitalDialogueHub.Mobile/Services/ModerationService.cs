using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using DigitalDialogueHub.Mobile.DTOs;

public class ModerationService
{
    private readonly HttpClient _httpClient;

    public ModerationService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<MessageDto?> ReportContentAsync(ReportCreateDto dto)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Moderation/ReportContent", dto);
        if (response.IsSuccessStatusCode)
            return await response.Content.ReadFromJsonAsync<MessageDto>();
        return null;
    }

    public async Task<MessageDto?> FlagCommentAsync(int commentId)
    {
        var response = await _httpClient.PostAsync($"api/Moderation/FlagComment?commentId={commentId}", null);
        if (response.IsSuccessStatusCode)
            return await response.Content.ReadFromJsonAsync<MessageDto>();
        return null;
    }

    public async Task<MessageDto?> FlagDiscussionAsync(int discussionId)
    {
        var response = await _httpClient.PostAsync($"api/Moderation/FlagDiscussion?discussionId={discussionId}", null);
        if (response.IsSuccessStatusCode)
            return await response.Content.ReadFromJsonAsync<MessageDto>();
        return null;
    }

    // Ostale metode su iste strukture, samo mjenjaš rutu i parametre

    public async Task<List<ReportDto>> GetReportsAsync()
    {
        var result = await _httpClient.GetFromJsonAsync<List<ReportDto>>("api/Moderation/GetReports");
        return result!;
    }
}
