namespace DigitalDialogueHub.DTOs
{
    public class ReactionCreateDto
    {
        public int CommentId { get; set; }
        public int UserId { get; set; }
        public string ReactionType { get; set; } = string.Empty;
    }

}
