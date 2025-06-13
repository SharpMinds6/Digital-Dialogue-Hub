using System;
using System.Collections.Generic;

namespace DigitalDialogueHub.Models;

public partial class User
{
    public int Id { get; set; }

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string? Role { get; set; }

    public bool IsEmailConfirmed { get; set; }

    public bool TwoFactorEnabled { get; set; }

    public DateTime? CreatedAt { get; set; }

    public bool IsDeleted { get; set; }

    public string? RefreshToken { get; set; }

    public DateTime? RefreshTokenExpiryTime { get; set; }

    public virtual ICollection<Comment> Comments { get; } = new List<Comment>();

    public virtual ICollection<Discussion> Discussions { get; } = new List<Discussion>();

    public virtual ICollection<File> Files { get; } = new List<File>();

    public virtual ICollection<Leaderboard> Leaderboards { get; } = new List<Leaderboard>();

    public virtual ICollection<Notification> Notifications { get; } = new List<Notification>();

    public virtual ICollection<Reaction> Reactions { get; } = new List<Reaction>();

    public virtual ICollection<RefreshToken> RefreshTokens { get; } = new List<RefreshToken>();

    public virtual ICollection<Report> Reports { get; } = new List<Report>();

    public virtual ICollection<UserBadge> UserBadges { get; } = new List<UserBadge>();
}
