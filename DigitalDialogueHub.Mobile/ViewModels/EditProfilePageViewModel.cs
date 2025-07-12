using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DigitalDialogueHub.Mobile.DTOs;
using DigitalDialogueHub.Mobile.Services;
using System.Threading.Tasks;

namespace DigitalDialogueHub.Mobile.ViewModels
{
    public partial class EditProfilePageViewModel : ObservableObject
    {
        private readonly UserService _userService;

        [ObservableProperty] private string username;
        [ObservableProperty] private string email;
        [ObservableProperty] private string role;
        [ObservableProperty] private string errorMessage;

        public IAsyncRelayCommand SaveCommand { get; }

        private readonly int _userId;

        public EditProfilePageViewModel(UserService userService, UserDto currentUser)
        {
            _userService = userService;

            _userId = currentUser.Id;
            Username = currentUser.FullName;
            Email = currentUser.Email;
            Role = currentUser.Role;

            SaveCommand = new AsyncRelayCommand(SaveProfileAsync);
        }

        private async Task SaveProfileAsync()
        {
            ErrorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Email))
            {
                ErrorMessage = "All fields are required.";
                return;
            }

            var updatedUser = new UserDto
            {
                Id = _userId,
                FullName = Username,
                Email = Email,
                Role = Role
            };

            var success = await _userService.UpdateAsync(_userId, updatedUser);

            ErrorMessage = success
                ? "Profile successfully updated!"
                : "Error updating profile.";
        }

    }
}
