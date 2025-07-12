namespace DigitalDialogueHub.Mobile.DTOs
{
    public class RegisterRequestDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } // "Student" ili "Moderator"
    }
}
