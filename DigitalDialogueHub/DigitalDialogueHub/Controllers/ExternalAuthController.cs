using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class ExternalAuthController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public ExternalAuthController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpPost("google-login")]
    public async Task<IActionResult> GoogleLogin([FromBody] string idToken)
    {
        var httpClient = new HttpClient();
        var googleApiUrl = $"https://oauth2.googleapis.com/tokeninfo?id_token={idToken}";

        var response = await httpClient.GetAsync(googleApiUrl);
        if (!response.IsSuccessStatusCode)
            return BadRequest("Invalid Google token");

        var payload = JsonDocument.Parse(await response.Content.ReadAsStringAsync()).RootElement;

        var email = payload.GetProperty("email").GetString();
        var name = payload.GetProperty("name").GetString();

        // Ovdje možeš provjeriti postoji li korisnik u tvojoj bazi
        // Ako ne postoji – kreiraj ga
        // Ako postoji – generiši JWT token

        // Na kraju vraćaš JWT:
        return Ok(new
        {
            Token = "generated-jwt-token",
            Email = email,
            Name = name
        });
    }
}
