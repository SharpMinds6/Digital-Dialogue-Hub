using Microsoft.Maui.Controls;
using DigitalDialogueHub.Mobile.Views;
namespace DigitalDialogueHub.Mobile;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        // Pre-login flow (Welcome, Login, Register, Username)
        Routing.RegisterRoute(nameof(WelcomePage), typeof(WelcomePage));
        Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
        Routing.RegisterRoute(nameof(UsernamePage), typeof(UsernamePage));

        // Post-login flow i ostale stranice
        Routing.RegisterRoute(nameof(AccountPage), typeof(AccountPage));
        Routing.RegisterRoute(nameof(EditProfilePage), typeof(EditProfilePage));
        Routing.RegisterRoute(nameof(ChangePersonalInfoPage), typeof(ChangePersonalInfoPage));
        Routing.RegisterRoute(nameof(ChangePasswordPage), typeof(ChangePasswordPage));
        Routing.RegisterRoute(nameof(BadgesPage), typeof(BadgesPage));
        Routing.RegisterRoute(nameof(SettingsPage), typeof(SettingsPage));
        Routing.RegisterRoute(nameof(MyPostsPage), typeof(MyPostsPage));
        Routing.RegisterRoute(nameof(DiscussionsPage), typeof(DiscussionsPage));
        Routing.RegisterRoute(nameof(ForumPage), typeof(ForumPage));
        Routing.RegisterRoute(nameof(LeaderboardsPage), typeof(LeaderboardsPage));
        Routing.RegisterRoute(nameof(NotificationPage), typeof(NotificationPage));
        Routing.RegisterRoute(nameof(UserPage), typeof(UserPage));
        Routing.RegisterRoute(nameof(UserBadgesPage), typeof(UserBadgesPage));
        Routing.RegisterRoute(nameof(NewPostPage), typeof(NewPostPage));
        Routing.RegisterRoute(nameof(CategorySelectionPopup), typeof(CategorySelectionPopup));
    }
}
