using DigitalDialogueHub.Mobile.DTOs;

namespace DigitalDialogueHub.Mobile.DTOs
{
    public class NotificationUpdateDto
    {
        public int Id { get; set; }
        public string? Message { get; set; }
        public bool IsRead { get; set; }
    }
}
