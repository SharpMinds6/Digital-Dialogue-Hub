using DigitalDialogueHub.Mobile.ViewModels;

namespace DigitalDialogueHub.Mobile.Views;

public partial class BadgesPage : ContentPage
{
    public BadgesPage(BadgesPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
