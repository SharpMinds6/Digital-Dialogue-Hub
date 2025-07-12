using System.Collections.ObjectModel;
using System.Threading.Tasks;
using DigitalDialogueHub.Mobile.DTOs;
using DigitalDialogueHub.Mobile.Services;
using DigitalDialogueHub.Mobile.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;

public partial class ForumPageViewModel : ObservableObject
{
    private readonly DiscussionService _discussionService;

    public ObservableCollection<DiscussionDto> Discussions { get; } = new();

    public ForumPageViewModel(DiscussionService discussionService)
    {
        _discussionService = discussionService;
  
        Task.Run(LoadDiscussionsAsync);
    }

    public async Task LoadDiscussionsAsync()
    {
        var items = await _discussionService.GetAllAsync();
        Discussions.Clear();
        if (items != null)
        {
            foreach (var disc in items)
                Discussions.Add(disc);
        }
    }
}
