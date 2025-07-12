using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using DigitalDialogueHub.Mobile.DTOs;
using System;





public class AuthService
{
    private readonly HttpClient _httpClient;

    public AuthService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<AuthResponseDto?> RegisterAsync(RegisterDto dto)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Auth/Register", dto);
        if (response.IsSuccessStatusCode)
            return await response.Content.ReadFromJsonAsync<AuthResponseDto>();
        return null;
    }

    public async Task<AuthResponseDto?> LoginAsync(LoginDto dto)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Auth/Login", dto);
        if (response.IsSuccessStatusCode)
            return await response.Content.ReadFromJsonAsync<AuthResponseDto>();
        return null;
    }

    public async Task<RoleSelectResponseDto?> SelectRoleAsync(RoleSelectDto dto)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Auth/select-role", dto);
        if (response.IsSuccessStatusCode)
            return await response.Content.ReadFromJsonAsync<RoleSelectResponseDto>();
        return null;
    }

    public async Task<AuthResponseDto?> RefreshTokenAsync(RefreshTokenRequest dto)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Auth/RefreshToken", dto);
        if (response.IsSuccessStatusCode)
            return await response.Content.ReadFromJsonAsync<AuthResponseDto>();
        return null;
    }

    public async Task<LogoutResponseDto?> LogoutAsync(LogoutDto dto)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Auth/Logout", dto);
        if (response.IsSuccessStatusCode)
            return await response.Content.ReadFromJsonAsync<LogoutResponseDto>();
        return null;
    }

    public async Task<UserDto?> GetCurrentUserAsync()
    {
        var response = await _httpClient.GetAsync("api/Auth/GetCurrentUser");
        if (response.IsSuccessStatusCode)
            return await response.Content.ReadFromJsonAsync<UserDto>();
        return null;
    }
}
