namespace DigitalDialogueHub.Mobile.DTOs
{
    public class ReportDto
    {
        public int Id { get; set; }
        public string ReporterName { get; set; }
        public string? CommentPreview { get; set; }
        public string? DiscussionTitle { get; set; }
        public string? Reason { get; set; }
        public DateTime CreatedAt { get; set; } // OVO je ključno za rješavanje greške!
    }
}
