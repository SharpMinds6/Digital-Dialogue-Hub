namespace DigitalDialogueHub.DTOs
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int? ParentCommentId { get; set; }
    }

}
