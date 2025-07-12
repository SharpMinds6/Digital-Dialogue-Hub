using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using DigitalDialogueHub.Mobile.DTOs;
using DigitalDialogueHub.Mobile.Services;
using DigitalDialogueHub.Mobile.ViewModels;

namespace DigitalDialogueHub.Mobile.ViewModels
{
    public class DiscussionsPageViewModel : ObservableObject
    {
        private readonly DiscussionService _discussionService;

        public ObservableCollection<DiscussionDto> Discussions { get; } = new();

        public ICommand LoadDiscussionsCommand { get; }

        public DiscussionsPageViewModel(DiscussionService discussionService)
        {
            _discussionService = discussionService;
            LoadDiscussionsCommand = new Command(async () => await LoadDiscussionsAsync());
        }

        public async Task LoadDiscussionsAsync()
        {
            var result = await _discussionService.GetAllAsync();
            Discussions.Clear();
            if (result != null)
            {
                foreach (var discussion in result)
                    Discussions.Add(discussion);
            }
        }
    }
}
