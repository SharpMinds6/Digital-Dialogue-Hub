namespace DigitalDialogueHub.Mobile.DTOs
{
    public class ReportCreateDto
    {
        public int ReporterId { get; set; }
        public string? Reason { get; set; }
        public int? CommentId { get; set; }
        public int? DiscussionId { get; set; }
    }
}
