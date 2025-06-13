using System;
using System.Collections.Generic;

namespace DigitalDialogueHub.Models;

public partial class File
{
    public int Id { get; set; }

    public string FileName { get; set; } = null!;

    public string? FileType { get; set; }

    public string FilePath { get; set; } = null!;

    public DateTime? UploadedAt { get; set; }

    public int UploadedBy { get; set; }

    public int? DiscussionId { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Discussion? Discussion { get; set; }

    public virtual User UploadedByNavigation { get; set; } = null!;
}
