using System;
using System.Collections.Generic;

namespace DigitalDialogueHub.Models;

public partial class Discussion
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Content { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int UserId { get; set; }

    public bool IsDeleted { get; set; }

    public bool IsFlagged { get; set; }

    public virtual ICollection<Comment> Comments { get; } = new List<Comment>();

    public virtual ICollection<File> Files { get; } = new List<File>();

    public virtual ICollection<Report> Reports { get; } = new List<Report>();

    public virtual User User { get; set; } = null!;
}
