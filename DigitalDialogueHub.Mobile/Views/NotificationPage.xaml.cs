using DigitalDialogueHub.Mobile.ViewModels;

namespace DigitalDialogueHub.Mobile.Views
{
    public partial class NotificationPage : ContentPage
    {
        public NotificationPage(NotificationPageViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

        private async void OnCloseTapped(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}
