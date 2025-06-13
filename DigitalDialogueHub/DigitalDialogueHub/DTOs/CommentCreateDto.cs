using System.ComponentModel.DataAnnotations;

namespace DigitalDialogueHub.DTOs
{
    public class CommentCreateDto
    {
        [Required]
        public int DiscussionId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }

        public int? ParentCommentId { get; set; }

        public bool IsDeleted { get; set; }
    }
}
