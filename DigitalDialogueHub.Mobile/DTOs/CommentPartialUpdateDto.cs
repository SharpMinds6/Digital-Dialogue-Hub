namespace DigitalDialogueHub.Mobile.DTOs
{
    public class CommentPartialUpdateDto
    {
        public string? Content { get; set; }
        public int? ParentCommentId { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
