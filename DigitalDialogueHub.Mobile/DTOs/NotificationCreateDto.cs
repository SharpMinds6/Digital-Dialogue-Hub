using DigitalDialogueHub.Mobile.DTOs;

namespace DigitalDialogueHub.Mobile.DTOs
{
    public class NotificationCreateDto
    {
        public int UserId { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; } = false;
    }
}


