using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DigitalDialogueHub.Mobile.DTOs;
using DigitalDialogueHub.Mobile.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace DigitalDialogueHub.Mobile.ViewModels
{
    public partial class UsernamePageViewModel : ObservableObject
    {
        private readonly AuthService _authService;

        [ObservableProperty]
        private string username;

        [ObservableProperty]
        private string selectedRole;

        [ObservableProperty]
        private ObservableCollection<string> availableRoles = new() { "Student", "Moderator" };

        [ObservableProperty]
        private string errorMessage;

        [ObservableProperty]
        private bool isBusy;

        public UsernamePageViewModel(AuthService authService)
        {
            _authService = authService;
            SelectedRole = AvailableRoles[0];
        }

        [RelayCommand]
        public async Task ContinueAsync()
        {
            ErrorMessage = string.Empty;

            var email = Microsoft.Maui.Storage.Preferences.Get("user_email", null);

            if (string.IsNullOrWhiteSpace(Username))
            {
                ErrorMessage = "Username is required.";
                return;
            }

            if (string.IsNullOrWhiteSpace(SelectedRole))
            {
                ErrorMessage = "Please select a role.";
                return;
            }

            if (string.IsNullOrWhiteSpace(email))
            {
                ErrorMessage = "Registration flow error: missing email!";
                return;
            }

            IsBusy = true;

            // Pripremi DTO s emailom, username i role
            var roleSelectDto = new RoleSelectDto
            {
                Email = email,
                Username = Username,
                Role = SelectedRole
            };

            // Pozovi backend (AuthService)
            var result = await _authService.SelectRoleAsync(roleSelectDto);

            if (result != null && result.Message?.ToLower().Contains("success") == true)
            {
                // Očisti Preferences (opcionalno)
                Microsoft.Maui.Storage.Preferences.Remove("user_email");

                // Navigacija na ForumPage
                await Shell.Current.GoToAsync("//ForumPage");
            }
            else
            {
                ErrorMessage = result?.Message ?? "Something went wrong, please try again.";
            }

            IsBusy = false;
        }
    }
}