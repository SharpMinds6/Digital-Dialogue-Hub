using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DigitalDialogueHub.Mobile.DTOs;
using DigitalDialogueHub.Mobile.Services;

namespace DigitalDialogueHub.Mobile.ViewModels
{
    public partial class ChangePersonalInfoPageViewModel : ObservableObject
    {
        private readonly UserService _userService;

        [ObservableProperty] private int userId;
        [ObservableProperty] private string newUsername;
        [ObservableProperty] private string newEmail;
        [ObservableProperty] private string errorMessage;

        public IAsyncRelayCommand SaveCommand { get; }

        public ChangePersonalInfoPageViewModel(UserService userService, UserDto currentUser)
        {
            _userService = userService;

            UserId = currentUser.Id;
            NewUsername = currentUser.FullName;
            NewEmail = currentUser.Email;

            SaveCommand = new AsyncRelayCommand(SavePersonalInfoAsync);
        }

        private async Task SavePersonalInfoAsync()
        {
            ErrorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(NewUsername) || string.IsNullOrWhiteSpace(NewEmail))
            {
                ErrorMessage = "All fields are required.";
                return;
            }

            var updatedUser = new UserDto
            {
                Id = UserId,
                FullName = NewUsername,
                Email = NewEmail,
            };

            var success = await _userService.UpdateAsync(updatedUser.Id, updatedUser);

            if (success)
                ErrorMessage = "Profile info successfully updated!";
            else
                ErrorMessage = "Error updating profile info.";
        }

        [RelayCommand]
        private void Back()
        {
            Shell.Current.GoToAsync("..");
        }
    }
}
