using DigitalDialogueHub.Mobile.ViewModels;

namespace DigitalDialogueHub.Mobile.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage(AuthService authService)
        {
            InitializeComponent();
            BindingContext = new LoginPageViewModel(authService);
        }

    }
}
