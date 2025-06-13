using System;
using System.Collections.Generic;

namespace DigitalDialogueHub.Models;

public partial class FileMetadatum
{
    public int Id { get; set; }

    public string FileName { get; set; } = null!;

    public string FilePath { get; set; } = null!;

    public string? ContentType { get; set; }

    public long Size { get; set; }

    public DateTime UploadedAt { get; set; }
}
