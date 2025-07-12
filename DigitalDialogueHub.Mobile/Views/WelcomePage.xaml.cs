using System;
using Microsoft.Maui.Controls;
using DigitalDialogueHub.Mobile.Helpers;

namespace DigitalDialogueHub.Mobile.Views
{
    public partial class WelcomePage : ContentPage
    {
        public WelcomePage()
        {
            InitializeComponent();
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            await NavigationHelper.NavigateToAsync<LoginPage>();
        }

        private async void OnSignUpClicked(object sender, EventArgs e)
        {
            await NavigationHelper.NavigateToAsync<RegisterPage>();
        }
    }
}
