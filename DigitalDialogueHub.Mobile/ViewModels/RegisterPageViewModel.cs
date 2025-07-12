using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DigitalDialogueHub.Mobile.DTOs;
using DigitalDialogueHub.Mobile.Services;
using System.Threading.Tasks;
using DigitalDialogueHub.Mobile.Views;

public partial class RegisterPageViewModel : ObservableObject
{
    private readonly AuthService _authService;

    [ObservableProperty]
    private string email;

    [ObservableProperty]
    private string password;

    [ObservableProperty]
    private string errorMessage;

    [ObservableProperty]
    private string confirmPassword;

    public IAsyncRelayCommand RegisterCommand { get; }

    public RegisterPageViewModel(AuthService authService)
    {
        _authService = authService;
        RegisterCommand = new AsyncRelayCommand(RegisterAsync);
    }

    private async Task RegisterAsync()
    {
        ErrorMessage = string.Empty;

        if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
        {
            ErrorMessage = "Email and password are required.";
            return;
        }

        // Možeš dodati dodatnu validaciju za email format, jačinu lozinke, itd.

        var registerDto = new RegisterDto
        {
            Email = Email,
            Password = Password
        };

        var result = await _authService.RegisterAsync(registerDto);

        if (result != null)
        {
            // Registracija uspješna - idi na sljedeću stranicu (npr. UsernamePage)
            await Shell.Current.GoToAsync(nameof(UsernamePage));
        }
        else
        {
            ErrorMessage = "Registration failed. Please try again.";
        }
    }
}
