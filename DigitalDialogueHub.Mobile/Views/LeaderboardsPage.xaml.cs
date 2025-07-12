using DigitalDialogueHub.Mobile.ViewModels;

namespace DigitalDialogueHub.Mobile.Views
{
    public partial class LeaderboardsPage : ContentPage
    {
        // OBAVEZNO: Prazan konstruktor za XAML/previewer!
        public LeaderboardsPage()
        {
            InitializeComponent();
            
        }

        // DI konstruktor: koristiæe ga DI servis prilikom instanciranja stranice
        public LeaderboardsPage(LeaderboardsPageViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}
