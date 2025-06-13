namespace DigitalDialogueHub.DTOs
{
    public class RoleSelectDto
    {
        public string Email { get; set; } = null!;
        public string Role { get; set; } = null!;  // očekujemo "Student" ili "Moderator"
    }
}
