using System.ComponentModel.DataAnnotations;

namespace DigitalDialogueHub.DTOs
{
    public class DiscussionCreateDto
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public int UserId { get; set; }

        public bool IsDeleted { get; set; } = false;
    }

}
