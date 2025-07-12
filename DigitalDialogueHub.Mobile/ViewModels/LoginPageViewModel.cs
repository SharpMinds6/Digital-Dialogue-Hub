using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DigitalDialogueHub.Mobile.DTOs;
using System.Threading.Tasks;
using System.Windows.Input;
using System;


namespace DigitalDialogueHub.Mobile.ViewModels
{
    public partial class LoginPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private string email;
        [ObservableProperty]
        private string password;
        [ObservableProperty]
        private bool isBusy;
        [ObservableProperty]
        private string errorMessage;

        public bool HasError => !string.IsNullOrEmpty(errorMessage);

        private readonly AuthService _authService;

        public LoginPageViewModel(AuthService authService)
        {
            _authService = authService;
        }

        [RelayCommand]
        public async Task LoginAsync()
        {
            await Application.Current.MainPage.DisplayAlert("DEBUG", "Kliknuto na login!", "OK");
            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
            {
                ErrorMessage = "Please enter both email and password.";
                return;
            }

            IsBusy = true;
            ErrorMessage = "";

            try
            {
                var loginDto = new LoginDto { Email = Email, Password = Password };
                var response = await _authService.LoginAsync(loginDto);

                if (response != null && !string.IsNullOrWhiteSpace(response.Token))
                {
                    // Spremi JWT i refresh token po potrebi
                    await SecureStorage.SetAsync("jwt_token", response.Token);
                    await SecureStorage.SetAsync("refresh_token", response.RefreshToken);

                    // Po uspješnom loginu vodi dalje (npr. ForumPage, UsernamePage...)
                    await Shell.Current.GoToAsync("//ForumPage");
                }
                else
                {
                    ErrorMessage = "Login failed. Check your credentials.";
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
