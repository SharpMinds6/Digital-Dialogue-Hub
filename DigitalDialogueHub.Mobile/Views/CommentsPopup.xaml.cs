using System;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using CommunityToolkit.Maui.Views;
using DigitalDialogueHub.Mobile.ViewModels;


namespace DigitalDialogueHub.Mobile.Views
{
    public partial class CommentsPopup : Popup
    {
        public CommentsPopup(CommentsPopupViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }

    }
}

