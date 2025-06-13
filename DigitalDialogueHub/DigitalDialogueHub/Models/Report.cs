using System;
using System.Collections.Generic;

namespace DigitalDialogueHub.Models;

public partial class Report
{
    public int Id { get; set; }

    public int ReporterId { get; set; }

    public string ContentType { get; set; } = null!;

    public int ContentId { get; set; }

    public string? Reason { get; set; }

    public DateTime ReportedAt { get; set; }

    public int? CommentId { get; set; }

    public int? DiscussionId { get; set; }

    public virtual Discussion? Discussion { get; set; }

    public virtual User Reporter { get; set; } = null!;
}
