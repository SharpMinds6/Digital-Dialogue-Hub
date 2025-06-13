namespace DigitalDialogueHub.DTOs
{
    public class FileDto
    {
        public string FileName { get; set; } = null!;
        public string FileType { get; set; } = null!;
        public string FilePath { get; set; } = null!;
        public DateTime UploadedAt { get; set; }
        public int UploadedBy { get; set; }
        public int DiscussionId { get; set; }
        public bool IsDeleted { get; set; }
    }

}
