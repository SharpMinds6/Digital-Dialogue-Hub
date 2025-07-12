using System.Collections.ObjectModel;
using System.Threading.Tasks;
using DigitalDialogueHub.Mobile.DTOs;
using DigitalDialogueHub.Mobile.Services;
using Microsoft.Maui.Controls;
using DigitalDialogueHub.Mobile.Views;
using DigitalDialogueHub.Mobile.ViewModels;

namespace DigitalDialogueHub.Mobile.ViewModels
{
    public class NotificationPageViewModel : UserViewModel
    {
        private readonly NotificationService _notificationService;

        public ObservableCollection<NotificationDto> Notifications { get; set; } = new();

        public Command LoadNotificationsCommand { get; }

        public NotificationPageViewModel(NotificationService notificationService)
        {
            _notificationService = notificationService;

            LoadNotificationsCommand = new Command(async () => await LoadNotificationsAsync());

            // Opcionalno automatsko uèitavanje notifikacija
            Task.Run(async () => await LoadNotificationsAsync());
        }

        public async Task LoadNotificationsAsync()
        {
            var notifications = await _notificationService.GetAllAsync();
            if (notifications != null)
            {
                Notifications.Clear();
                foreach (var notification in notifications)
                {
                    Notifications.Add(notification);
                }
            }
        }
    }
}
