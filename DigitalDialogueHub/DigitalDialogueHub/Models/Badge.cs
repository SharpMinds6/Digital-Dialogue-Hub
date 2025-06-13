using System;
using System.Collections.Generic;

namespace DigitalDialogueHub.Models;

public partial class Badge
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? IconPath { get; set; }

    public virtual ICollection<UserBadge> UserBadges { get; } = new List<UserBadge>();
}
