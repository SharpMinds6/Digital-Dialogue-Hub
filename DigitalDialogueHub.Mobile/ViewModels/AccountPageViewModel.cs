using Microsoft.Maui.Controls;
using System.Data;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DigitalDialogueHub.Mobile.DTOs;
using DigitalDialogueHub.Mobile.Services;
using DigitalDialogueHub.Mobile.Views;

public partial class AccountPageViewModel : ObservableObject
{
    private readonly AuthService _authService;

    [ObservableProperty] private string fullName;
    [ObservableProperty] private string email;
    [ObservableProperty] private string role;

    public IRelayCommand LogoutCommand { get; }

    public AccountPageViewModel(AuthService authService)
    {
        _authService = authService;

       
        FullName = "student.user";
        Email = "student@edu.com";
        Role = "Student";

        LogoutCommand = new RelayCommand(async () => await LogoutAsync());
    }

    private async Task LogoutAsync()
    {
        await Shell.Current.GoToAsync("//WelcomePage");
    }

    public IRelayCommand EditProfileCommand { get; }

    public AccountPageViewModel()
    {
        EditProfileCommand = new RelayCommand(OnEditProfile);
    }

    private async void OnEditProfile()
    {
        await Shell.Current.GoToAsync(nameof(EditProfilePage));
    }

}
