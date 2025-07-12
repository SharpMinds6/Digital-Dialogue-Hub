using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using DigitalDialogueHub.Mobile.DTOs;
using DigitalDialogueHub.Mobile.Services;

namespace DigitalDialogueHub.Mobile.ViewModels
{
    public class LeaderboardsPageViewModel : INotifyPropertyChanged
    {
        private readonly LeaderboardService _leaderboardService;

        public ObservableCollection<LeaderboardDto> Leaderboards { get; set; } = new();

        private string _username = "student.user";
        public string Username
        {
            get => _username;
            set { _username = value; OnPropertyChanged(); }
        }

        private string _email = "student@edu.com";
        public string Email
        {
            get => _email;
            set { _email = value; OnPropertyChanged(); }
        }

        // Konstruktor prima servis preko DI
        public LeaderboardsPageViewModel(LeaderboardService leaderboardService)
        {
            _leaderboardService = leaderboardService;
            _ = LoadLeaderboardsAsync(); // async void nije dobar, pa ovako u konstruktoru
        }

        private async Task LoadLeaderboardsAsync()
        {
            var list = await _leaderboardService.GetAllAsync();

            Leaderboards.Clear();
            int rank = 1;
            foreach (var item in list.OrderByDescending(x => x.Points))
            {
                item.Rank = rank++;
                Leaderboards.Add(item);
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
