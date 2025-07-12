using DigitalDialogueHub.Mobile.ViewModels;

namespace DigitalDialogueHub.Mobile.Views;

public partial class SettingsPage : ContentPage
{
    public SettingsPage(SettingsPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        // Pretpostavimo da uèitavamo korisnika sa ID=1, promijeni po potrebi
        await (BindingContext as SettingsPageViewModel)?.LoadUserAsync(1);
    }
}


