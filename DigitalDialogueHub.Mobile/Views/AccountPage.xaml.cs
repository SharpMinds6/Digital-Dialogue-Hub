using DigitalDialogueHub.Mobile.ViewModels;
using Microsoft.Maui.Controls;


namespace DigitalDialogueHub.Mobile.Views;

public partial class AccountPage : ContentPage
{
    public AccountPage(AccountPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    

    private async void OnBadgesClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(UserBadgesPage));
    }
    private void OnBackTapped(object sender, EventArgs e)
    {
        // Tvoj kod za povratak, npr:
        Shell.Current.GoToAsync("..");
    }



}
