using System;
using Microsoft.Maui.Controls;
using DigitalDialogueHub.Mobile.DTOs;
using DigitalDialogueHub.Mobile.Services;
using Microsoft.Maui.Storage;

namespace DigitalDialogueHub.Mobile.Views
{
    public partial class RegisterPage : ContentPage
    {
        private readonly RegisterPageViewModel _viewModel;

        public RegisterPage(RegisterPageViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

    }
}
