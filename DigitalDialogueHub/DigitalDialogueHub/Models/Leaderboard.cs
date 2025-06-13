using System;
using System.Collections.Generic;

namespace DigitalDialogueHub.Models;

public partial class Leaderboard
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int Points { get; set; }

    public int? Rank { get; set; }

    public virtual User User { get; set; } = null!;
}
