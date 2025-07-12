namespace DigitalDialogueHub.Mobile.DTOs
{
    public class FileDto
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string? FileType { get; set; }
        public string FilePath { get; set; }
        public DateTime? UploadedAt { get; set; }
        public int UploadedBy { get; set; }
        public int? DiscussionId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
