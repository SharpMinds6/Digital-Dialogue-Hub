using DigitalDialogueHub.Mobile.Services;
using System;
using System.Net.Http;
using DigitalDialogueHub.Mobile.DTOs;

public static class ServiceLocator
{
    public static HttpClient HttpClient { get; } = new HttpClient
    {
        BaseAddress = new Uri("https://localhost:7231/") // prilagodi backend URL
    };

    public static BadgeService BadgeService { get; } = new BadgeService(HttpClient);
    public static NotificationService NotificationService { get; } = new NotificationService(HttpClient);
    public static UserService UserService { get; } = new UserService(HttpClient);
    public static DiscussionService DiscussionService { get; } = new DiscussionService(HttpClient);
    public static FileService FileService { get; } = new FileService(HttpClient);
    public static LeaderboardService LeaderboardService { get; } = new LeaderboardService(HttpClient);
    public static ReactionService ReactionService { get; } = new ReactionService(HttpClient);
    public static ReportService ReportService { get; } = new ReportService(HttpClient);
    public static UserBadgeService UserBadgeService { get; } = new UserBadgeService(HttpClient);
    public static PostService PostService { get; } = new PostService(HttpClient);
    public static ModerationService ModerationService { get; } = new ModerationService(HttpClient);
    public static AuthService AuthService { get; } = new AuthService(HttpClient);

    // Po potrebi dodaj ostale servise
}
