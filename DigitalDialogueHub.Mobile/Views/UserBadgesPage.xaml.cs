using DigitalDialogueHub.Mobile.ViewModels;
namespace DigitalDialogueHub.Mobile.Views;


public partial class UserBadgesPage : ContentPage
{
    public UserBadgesPage(UserBadgesPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
