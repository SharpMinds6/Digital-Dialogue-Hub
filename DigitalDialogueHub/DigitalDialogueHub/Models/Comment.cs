using System;
using System.Collections.Generic;

namespace DigitalDialogueHub.Models;

public partial class Comment
{
    public int Id { get; set; }

    public int DiscussionId { get; set; }

    public int UserId { get; set; }

    public string Content { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public int? ParentCommentId { get; set; }

    public bool IsDeleted { get; set; }

    public bool IsFlagged { get; set; }

    public virtual Discussion Discussion { get; set; } = null!;

    public virtual ICollection<Comment> InverseParentComment { get; } = new List<Comment>();

    public virtual Comment? ParentComment { get; set; }

    public virtual ICollection<Reaction> Reactions { get; } = new List<Reaction>();

    public virtual User User { get; set; } = null!;
}
