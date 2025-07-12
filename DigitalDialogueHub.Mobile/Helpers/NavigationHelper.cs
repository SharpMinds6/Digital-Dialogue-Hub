using Microsoft.Maui.Controls;
using System;
using System.Threading.Tasks;

namespace DigitalDialogueHub.Mobile.Helpers
{
    public static class NavigationHelper
    {
        public static async Task NavigateToAsync<TPage>() where TPage : Page
        {
            var page = App.Services.GetService<TPage>();
            if (page is not null)
                await Shell.Current.Navigation.PushAsync(page);
            else
                throw new Exception($"Page of type {typeof(TPage)} is not registered in DI.");
        }

        
        public static async Task NavigateModalToAsync<TPage>() where TPage : Page
        {
            var page = App.Services.GetService<TPage>();
            if (page is not null)
                await Shell.Current.Navigation.PushModalAsync(page);
            else
                throw new Exception($"Page of type {typeof(TPage)} is not registered in DI.");
        }
    }
}
