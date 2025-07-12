using Android.App;
using Android.Content.PM;
using Android.OS;

namespace DigitalDialogueHub.Mobile;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
public class MainActivity : MauiAppCompatActivity
{
    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        // Fullscreen mod
        Window.SetStatusBarColor(Android.Graphics.Color.Transparent);
        Window.DecorView.SystemUiVisibility = (Android.Views.StatusBarVisibility)(
            Android.Views.SystemUiFlags.LayoutStable |
            Android.Views.SystemUiFlags.LayoutFullscreen
        );
    }
}
