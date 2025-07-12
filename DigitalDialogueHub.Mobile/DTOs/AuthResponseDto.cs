namespace DigitalDialogueHub.Mobile.DTOs
{
    public class AuthResponseDto
    {
        public string Token { get; set; } = null!;
        public string RefreshToken { get; set; } = null!;
    }

    public class ErrorResponseDto
    {
        public string Message { get; set; } = null!;
    }

    public class RoleSelectResponseDto
    {
        public string Message { get; set; } = null!;
    }

    public class LogoutResponseDto
    {
        public string Message { get; set; } = null!;
    }
}
