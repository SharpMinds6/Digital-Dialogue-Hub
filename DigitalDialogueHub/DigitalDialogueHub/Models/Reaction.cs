using System;
using System.Collections.Generic;

namespace DigitalDialogueHub.Models;

public partial class Reaction
{
    public int Id { get; set; }

    public int CommentId { get; set; }

    public int UserId { get; set; }

    public string ReactionType { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public virtual Comment Comment { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
