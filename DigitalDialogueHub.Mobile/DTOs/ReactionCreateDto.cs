namespace DigitalDialogueHub.Mobile.DTOs
{
    public class ReactionDto
    {
        public int Id { get; set; }
        public int CommentId { get; set; }
        public int UserId { get; set; }
        public string ReactionType { get; set; } = null!;
        public DateTime? CreatedAt { get; set; } // <--- OVO MORA BITI NULLABLE!
    }

    public class ReactionCreateDto
    {
        public int CommentId { get; set; }
        public int UserId { get; set; }
        public string ReactionType { get; set; } = null!;
        // CreatedAt NE treba ovdje, backend ga može sam postaviti
    }

    public class ReactionUpdateDto
    {
        public int Id { get; set; }
        public string ReactionType { get; set; } = null!;
        // CreatedAt NE treba ovdje, jer se obično ne ažurira
    }
}
