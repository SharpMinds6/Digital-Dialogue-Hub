using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using DigitalDialogueHub.Mobile.ViewModels;
using DigitalDialogueHub.Mobile.Views;
using DigitalDialogueHub.Mobile.Services;

namespace DigitalDialogueHub.Mobile;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-SemiBold.ttf", "OpenSansSemiBold");
                fonts.AddFont("OpenSans-Bold.ttf", "OpenSansBold");
            });

#if ANDROID
        var baseApiUrl = new Uri("https://10.0.2.2:7231/");
#else
        var baseApiUrl = new Uri("https://localhost:7231/");
#endif

        builder.Services.AddHttpClient<AuthService>(c => c.BaseAddress = baseApiUrl);
        builder.Services.AddHttpClient<BadgeService>(c => c.BaseAddress = baseApiUrl);
        builder.Services.AddHttpClient<CommentService>(c => c.BaseAddress = baseApiUrl);
        builder.Services.AddHttpClient<FileService>(c => c.BaseAddress = baseApiUrl);
        builder.Services.AddHttpClient<LeaderboardService>(c => c.BaseAddress = baseApiUrl);
        builder.Services.AddHttpClient<ModerationService>(c => c.BaseAddress = baseApiUrl);
        builder.Services.AddHttpClient<NotificationService>(c => c.BaseAddress = baseApiUrl);
        builder.Services.AddHttpClient<ReactionService>(c => c.BaseAddress = baseApiUrl);
        builder.Services.AddHttpClient<ReportService>(c => c.BaseAddress = baseApiUrl);
        builder.Services.AddHttpClient<UserBadgeService>(c => c.BaseAddress = baseApiUrl);
        builder.Services.AddHttpClient<UserService>(c => c.BaseAddress = baseApiUrl);
        builder.Services.AddHttpClient<DiscussionService>(c => c.BaseAddress = baseApiUrl);
        builder.Services.AddHttpClient<PostService>(c => c.BaseAddress = baseApiUrl);
        builder.Services.AddHttpClient<CategoryService>(c => c.BaseAddress = baseApiUrl);

        builder.Services.AddTransient<AccountPageViewModel>();
        builder.Services.AddTransient<ChangePersonalInfoPageViewModel>();
        builder.Services.AddTransient<CommentsPopupViewModel>();
        builder.Services.AddTransient<EditProfilePageViewModel>();
        builder.Services.AddTransient<DiscussionsPageViewModel>();
        builder.Services.AddTransient<ForumPageViewModel>();
        builder.Services.AddTransient<MyPostsPageViewModel>();
        builder.Services.AddTransient<LeaderboardsPageViewModel>();
        builder.Services.AddTransient<NewPostPageViewModel>();
        builder.Services.AddTransient<UserBadgesPageViewModel>();
        builder.Services.AddTransient<SettingsPageViewModel>();
        builder.Services.AddTransient<CategorySelectionPopupViewModel>();
        builder.Services.AddTransient<ChangePasswordPageViewModel>();
        builder.Services.AddTransient<RegisterPageViewModel>();
        builder.Services.AddTransient<LoginPageViewModel>();
        builder.Services.AddTransient<UsernamePageViewModel>();

        builder.Services.AddTransient<AccountPage>();
        builder.Services.AddTransient<ChangePersonalInfoPage>();
        builder.Services.AddTransient<CommentsPopup>();
        builder.Services.AddTransient<EditProfilePage>();
        builder.Services.AddTransient<DiscussionsPage>();
        builder.Services.AddTransient<ForumPage>();
        builder.Services.AddTransient<MyPostsPage>();
        builder.Services.AddTransient<LeaderboardsPage>();
        builder.Services.AddTransient<NewPostPage>();
        builder.Services.AddTransient<UserBadgesPage>();
        builder.Services.AddTransient<SettingsPage>();
        builder.Services.AddTransient<CategorySelectionPopup>();
        builder.Services.AddTransient<ChangePasswordPage>();
        builder.Services.AddTransient<RegisterPage>();
        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<UsernamePage>();
        builder.Services.AddTransient<WelcomePage>();
        builder.Services.AddTransient<NotificationPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
