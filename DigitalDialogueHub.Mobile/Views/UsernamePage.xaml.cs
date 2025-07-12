using System;
using Microsoft.Maui.Controls;
using DigitalDialogueHub.Mobile.DTOs;
using DigitalDialogueHub.Mobile.Services;

namespace DigitalDialogueHub.Mobile.Views
{
    public partial class UsernamePage : ContentPage
    {
        private readonly AuthService _authService;

        public UsernamePage(AuthService authService)
        {
            InitializeComponent();
            _authService = authService;
        }

        private async void OnContinueClicked(object sender, EventArgs e)
        {
            string username = UsernameEntry.Text?.Trim();
            string role = RolePicker.SelectedItem as string;

            if (string.IsNullOrEmpty(username))
            {
                await DisplayAlert("Error", "Please enter a username.", "OK");
                return;
            }

            if (string.IsNullOrEmpty(role))
            {
                await DisplayAlert("Error", "Please select a role.", "OK");
                return;
            }

            // Pretpostavimo da imaš DTO za slanje username + role npr. RoleSelectDto
            var roleSelectDto = new RoleSelectDto
            {
                Username = username,
                Role = role
            };

            var result = await _authService.SelectRoleAsync(roleSelectDto);

            if (result != null)
            {
                // Uspješno postavljen username i rola - idi na Forum ili početnu stranicu
                await Shell.Current.GoToAsync("//ForumPage"); // ili kako imaš definirano
            }
            else
            {
                await DisplayAlert("Error", "Failed to set username and role. Please try again.", "OK");
            }
        }
    }
}
