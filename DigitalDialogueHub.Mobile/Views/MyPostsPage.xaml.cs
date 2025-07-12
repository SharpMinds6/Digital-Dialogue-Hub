using DigitalDialogueHub.Mobile.ViewModels;
using Microsoft.Maui.Controls;
namespace DigitalDialogueHub.Mobile.Views
{
    public partial class MyPostsPage : ContentPage
    {
        public MyPostsPage(MyPostsPageViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

        private void OnBackTapped(object sender, EventArgs e)
        {
            // Navigacija nazad
            Shell.Current.GoToAsync("..");
        }
      
    }
}
