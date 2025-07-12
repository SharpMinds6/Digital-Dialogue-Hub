using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.Maui.Controls;  // za Command
using System.Threading.Tasks;

namespace DigitalDialogueHub.Mobile.ViewModels
{
    public class UserViewModel : INotifyPropertyChanged
    {
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

        public UserViewModel()
        {
            SaveCommand = new Command(async () => await SaveUserAsync());
        }

        private async Task SaveUserAsync()
        {
            // Ovdje ide tvoja logika za spremanje podataka, npr. poziv servisa

            // Za demonstraciju samo simuliramo čekanje
            await Task.Delay(500);

            // Možeš dodati logiku za validaciju i spremanje
            // Npr. pozvati API za update korisnika

            // U praksi, ovdje ćeš koristiti HttpClient ili servis koji komunicira s API-jem
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
