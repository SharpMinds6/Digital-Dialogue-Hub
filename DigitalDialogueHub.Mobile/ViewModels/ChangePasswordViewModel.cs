using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using DigitalDialogueHub.Mobile.Views;

namespace DigitalDialogueHub.Mobile.ViewModels
{
    public class ChangePasswordPageViewModel : UserViewModel, INotifyPropertyChanged
    {
        private string currentPassword;
        public string CurrentPassword
        {
            get => currentPassword;
            set { currentPassword = value; OnPropertyChanged(); }
        }

        private string newPassword;
        public string NewPassword
        {
            get => newPassword;
            set { newPassword = value; OnPropertyChanged(); }
        }

        private string confirmPassword;
        public string ConfirmPassword
        {
            get => confirmPassword;
            set { confirmPassword = value; OnPropertyChanged(); }
        }

        private string errorMessage;
        public string ErrorMessage
        {
            get => errorMessage;
            set { errorMessage = value; OnPropertyChanged(); }
        }

        public ICommand SavePasswordCommand { get; }

        public ChangePasswordPageViewModel()
        {
            Username = "student.user";
            Email = "student@edu.com";
            SavePasswordCommand = new RelayCommand(OnSavePassword);
        }

        private void OnSavePassword()
        {
            // Osnovna validacija
            ErrorMessage = string.Empty;
            if (string.IsNullOrWhiteSpace(CurrentPassword) ||
                string.IsNullOrWhiteSpace(NewPassword) ||
                string.IsNullOrWhiteSpace(ConfirmPassword))
            {
                ErrorMessage = "All fields are required.";
                return;
            }
            if (NewPassword != ConfirmPassword)
            {
                ErrorMessage = "New passwords do not match.";
                return;
            }
            if (NewPassword.Length < 6)
            {
                ErrorMessage = "Password must be at least 6 characters.";
                return;
            }

            // Ovdje dodaj logiku za slanje nove lozinke na backend/api...
            // Ako uspješno:
            ErrorMessage = "Password successfully changed!";
            // Ako ne uspije:
            // ErrorMessage = "An error occurred. Try again.";
        }

        // Ako koristiš CommunityToolkit.Mvvm, možeš koristiti ObservableObject
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
