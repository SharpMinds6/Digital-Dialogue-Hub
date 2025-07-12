namespace DigitalDialogueHub.Mobile.DTOs

{
    public class PostCreateDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int CategoryId { get; set; }
        public List<string> ImagePaths { get; set; } = new();
        public List<string> VideoPaths { get; set; } = new();
        public List<string> Links { get; set; } = new();
    }
}

