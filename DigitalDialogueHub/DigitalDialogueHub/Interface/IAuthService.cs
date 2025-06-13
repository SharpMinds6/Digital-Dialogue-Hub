using DigitalDialogueHub.DTOs;
using System.Threading.Tasks;

namespace DigitalDialogueHub.Interface
{
    public interface IAuthService
    {
        Task<string> RegisterAsync(RegisterDto dto);
        Task<LoginResultDto> LoginAsync(LoginDto dto);
        Task<string> RefreshTokenAsync(string token, string refreshToken);

        Task<bool> RevokeRefreshTokenAsync(string refreshToken);
        Task<string> SelectRoleAsync(RoleSelectDto dto);

    }
}
