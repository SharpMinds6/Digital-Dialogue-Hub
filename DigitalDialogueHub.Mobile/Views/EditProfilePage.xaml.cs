using System;
using Microsoft.Maui.Controls;
using DigitalDialogueHub.Mobile.ViewModels;

namespace DigitalDialogueHub.Mobile.Views
{
    public partial class EditProfilePage : ContentPage
    {
        public EditProfilePage(EditProfilePageViewModel vm) // DI
        {
            InitializeComponent();
            BindingContext = vm; // Postavi ViewModel preko DI-a
        }

        private async void OnBackTapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("..");
        }

        private async void OnChangePersonalClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("ChangePersonalInfoPage");
        }

        private async void OnChangePasswordClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("ChangePasswordPage");
        }
    }
}
