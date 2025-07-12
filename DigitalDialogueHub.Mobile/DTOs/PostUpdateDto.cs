namespace DigitalDialogueHub.Mobile.DTOs
{

    public class PostUpdateDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string? Image { get; set; }
        public int CategoryId { get; set; }
        public bool IsEdited { get; set; }
        public bool IsDeleted { get; set; }
    }
}
