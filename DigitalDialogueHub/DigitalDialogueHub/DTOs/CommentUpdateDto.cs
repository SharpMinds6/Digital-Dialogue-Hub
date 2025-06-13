namespace DigitalDialogueHub.DTOs
{
    public class CommentUpdateDto
    {
        public int Id { get; set; }
        public int DiscussionId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? ParentCommentId { get; set; }
        public bool IsDeleted { get; set; }
    }

}
