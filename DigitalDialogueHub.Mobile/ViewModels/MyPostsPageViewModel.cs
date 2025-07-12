using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DigitalDialogueHub.Mobile.DTOs;
using DigitalDialogueHub.Mobile.Services;

namespace DigitalDialogueHub.Mobile.ViewModels
{
    public partial class MyPostsPageViewModel : ObservableObject
    {
        private readonly PostService _postService;

        public ObservableCollection<PostDto> MyPosts { get; } = new ObservableCollection<PostDto>();

        public IAsyncRelayCommand LoadPostsCommand { get; }

        public MyPostsPageViewModel(PostService postService)
        {
            _postService = postService;
            LoadPostsCommand = new AsyncRelayCommand(LoadPostsAsync);
            LoadPostsCommand.Execute(null);
        }

        private async Task LoadPostsAsync()
        {
            var posts = await _postService.GetMyPostsAsync();
            MyPosts.Clear();
            foreach (var post in posts)
            {
                MyPosts.Add(post);
            }
        }
    }
}
