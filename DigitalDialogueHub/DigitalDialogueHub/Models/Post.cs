namespace DigitalDialogueHub.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        // Kolekcija za komentare
        public ICollection<Comment> Comments { get; set; }
    }
}

