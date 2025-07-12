using DigitalDialogueHub.Mobile.DTOs;
using DigitalDialogueHub.Mobile.Services;
using Microsoft.Maui.Controls;

namespace DigitalDialogueHub.Mobile.Views
{
    public partial class UserPage : ContentPage
    {
        private readonly UserService _userService;

        public UserDto CurrentUser { get; set; }

        public UserPage(UserService userService)
        {
            InitializeComponent();
            _userService = userService;

            // Primjer uèitavanja korisnika sa ID 1 (možeš prilagoditi)
            LoadUserAsync(1);
        }

        private async void LoadUserAsync(int userId)
        {
            CurrentUser = await _userService.GetAsync(userId);
            if (CurrentUser != null)
            {
                // Rukovanje podacima - postavi BindingContext na DTO direktno
                BindingContext = CurrentUser;
            }
            else
            {
                await DisplayAlert("Greška", "Korisnik nije pronaðen.", "OK");
            }
        }
    }
}
