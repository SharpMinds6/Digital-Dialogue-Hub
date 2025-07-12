namespace DigitalDialogueHub.Mobile.DTOs
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Title { get; set; }               // Naslov posta
        public string Content { get; set; }             // Sadržaj posta
        public string? Image { get; set; }              // Slika posta (putanja ili URL)
        public string AuthorName { get; set; }          // Ime autora
        public int AuthorId { get; set; }               // ID autora
        public DateTime CreatedAt { get; set; }         // Datum objave
        public int Likes { get; set; }                  // Broj lajkova
        public int Dislikes { get; set; }               // Broj dislajkova
        public int CommentsCount { get; set; }          // Broj komentara
        public string Category { get; set; }            // Kategorija posta
        public bool IsEdited { get; set; }              // Je li post editovan
        public bool IsDeleted { get; set; }
        public bool HasImage => !string.IsNullOrEmpty(Image);

        public List<CommentDto> Comments { get; set; }

    }
}
