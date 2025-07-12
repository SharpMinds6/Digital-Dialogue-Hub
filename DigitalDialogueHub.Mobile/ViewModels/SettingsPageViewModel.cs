using DigitalDialogueHub.Mobile.DTOs;
using System.ComponentModel;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input; // NuGet: CommunityToolkit.Mvvm

namespace DigitalDialogueHub.Mobile.ViewModels
{
    public class SettingsPageViewModel : INotifyPropertyChanged
    {
        private readonly HttpClient _httpClient;

        public SettingsPageViewModel(HttpClient httpClient)
        {
            _httpClient = httpClient;

            // Inicijalni dummy podaci (možeš kasnije učitati stvarne)
            Username = "student.user";
            Email = "student@edu.com";

            SaveCommand = new AsyncRelayCommand(SaveUserAsync);
        }

        private string username;
        public string Username
        {
            get => username;
            set { username = value; OnPropertyChanged(); }
        }

        private string email;
        public string Email
        {
            get => email;
            set { email = value; OnPropertyChanged(); }
        }

        public ICommand SaveCommand { get; }

        // Učitaj korisnika iz API-ja po ID-ju i popuni polja
        public async Task LoadUserAsync(int userId)
        {
            var user = await _httpClient.GetFromJsonAsync<UserDto>($"api/Users/Get/{userId}");
            if (user != null)
            {
                Username = user.Username;
                Email = user.Email;
            }
        }

        // Spremi izmjene korisnika u API
        private async Task SaveUserAsync()
        {
            // Pretpostavimo da imamo trenutno ulogovanog korisnika s ID=1 (zamijeni sa stvarnim)
            int currentUserId = 1;

            var userDto = new UserDto
            {
                Id = currentUserId,
                Username = this.Username,
                Email = this.Email
            };

            var response = await _httpClient.PutAsJsonAsync($"api/Users/Update/{currentUserId}", userDto);
            if (response.IsSuccessStatusCode)
            {
                await App.Current.MainPage.DisplayAlert("Success", "Settings saved successfully.", "OK");
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "Failed to save settings.", "OK");
            }
        }

        #region INotifyPropertyChanged Implementation

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        #endregion
    }
}

