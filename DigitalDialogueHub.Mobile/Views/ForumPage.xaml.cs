using DigitalDialogueHub.Mobile.ViewModels;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Hosting;

namespace DigitalDialogueHub.Mobile.Views
{
    public partial class ForumPage : ContentPage
    {
        public ForumPage()
        {
            InitializeComponent();
        }
        public ForumPage(ForumPageViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

        private async void OnMenuTapped(object sender, EventArgs e)
        {
            // Otvori kategorije ili meni - dodaj await ako treba
            // await SomeAsyncMethod();
        }

        private async void OnProfileIconTapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(AccountPage));
        }

        private void OnHomeTapped(object sender, EventArgs e)
        {
            // Navigacija na home
        }

        private async void OnAddPostTapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(NewPostPage));
        }

        private async void OnNotificationTapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(NotificationPage));
        }
    }
}
