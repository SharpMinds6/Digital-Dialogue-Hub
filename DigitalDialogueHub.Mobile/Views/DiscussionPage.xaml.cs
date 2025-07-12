using Microsoft.Maui.Controls;
using DigitalDialogueHub.Mobile.ViewModels;

namespace DigitalDialogueHub.Mobile.Views
{
    public partial class DiscussionsPage : ContentPage
    {
        public DiscussionsPage(DiscussionsPageViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}
