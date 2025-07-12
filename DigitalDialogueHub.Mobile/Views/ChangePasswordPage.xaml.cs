using System;
using Microsoft.Maui.Controls;

namespace DigitalDialogueHub.Mobile.Views
{
    public partial class ChangePasswordPage : ContentPage
    {
        public ChangePasswordPage()
        {
            InitializeComponent();
        }

        private async void OnBackTapped(object sender, EventArgs e)
        {
            // Vraæa na prethodnu stranicu (EditProfilePage)
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSavePasswordClicked(object sender, EventArgs e)
        {
            // Ovdje ide logika za promjenu lozinke (pozovi ViewModel metodu)
            // Npr. await (BindingContext as ChangePasswordPageViewModel).ChangePassword();

            // Nakon uspješne promjene možeš vratiti usera ili prikazati poruku
            await DisplayAlert("Success", "Your password has been changed.", "OK");
            await Shell.Current.GoToAsync("..");
        }
    }
}
