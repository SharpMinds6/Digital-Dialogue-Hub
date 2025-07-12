using System.Collections.ObjectModel;
using System.Threading.Tasks;
using DigitalDialogueHub.Mobile.DTOs;
using DigitalDialogueHub.Mobile.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace DigitalDialogueHub.Mobile.ViewModels
{
    public partial class UserBadgesPageViewModel : ObservableObject
    {
        private readonly UserBadgeService _service;

        public ObservableCollection<UserBadgeDto> UserBadges { get; } = new();

        [ObservableProperty]
        private bool isBusy;

        public UserBadgesPageViewModel(UserBadgeService service)
        {
            _service = service;
            LoadUserBadgesCommand = new AsyncRelayCommand(LoadUserBadgesAsync);
        }

        public IAsyncRelayCommand LoadUserBadgesCommand { get; }

        private async Task LoadUserBadgesAsync()
        {
            if (IsBusy) return;

            try
            {
                IsBusy = true;
                UserBadges.Clear();
                var list = await _service.GetAllAsync();
                foreach (var item in list)
                    UserBadges.Add(item);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
