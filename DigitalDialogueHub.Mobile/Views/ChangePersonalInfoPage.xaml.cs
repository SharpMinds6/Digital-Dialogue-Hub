using Microsoft.Maui.Controls;
using DigitalDialogueHub.Mobile.ViewModels;

namespace DigitalDialogueHub.Mobile.Views
{
    public partial class ChangePersonalInfoPage : ContentPage
    {
        public ChangePersonalInfoPage(ChangePersonalInfoPageViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}
