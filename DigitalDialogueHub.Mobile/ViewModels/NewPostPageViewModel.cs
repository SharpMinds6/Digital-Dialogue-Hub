using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DigitalDialogueHub.Mobile.DTOs;
using DigitalDialogueHub.Mobile.Services;

namespace DigitalDialogueHub.Mobile.ViewModels
{
    public partial class NewPostPageViewModel : ObservableObject
    {
        private readonly PostService _postService;

        [ObservableProperty]
        private CategoryDto selectedCategory;

        [ObservableProperty]
        private string title;

        [ObservableProperty]
        private string content;

        [ObservableProperty]
        private string errorMessage;

        public ObservableCollection<string> ImagePaths { get; } = new();
        public ObservableCollection<string> VideoPaths { get; } = new();
        public ObservableCollection<string> Links { get; } = new();

        public string SelectedCategoryDisplay => SelectedCategory?.Name ?? "Choose category";

        public string SelectedCategoryIcon =>
            SelectedCategory == null || SelectedCategory.Name == "All" ? "icon_all.png" : SelectedCategory.Icon;

        public ICommand OpenCategorySelectionCommand { get; }
        public ICommand AddPhotoCommand { get; }
        public ICommand AddVideoCommand { get; }
        public ICommand AddLinkCommand { get; }
        public IRelayCommand PostCommand { get; }

        public Action OpenCategorySelectionAction { get; set; }

        public NewPostPageViewModel(PostService postService)
        {
            _postService = postService;

            OpenCategorySelectionCommand = new RelayCommand(() => OpenCategorySelectionAction?.Invoke());

            AddPhotoCommand = new AsyncRelayCommand<string>(AddPhotoAsync);
            AddVideoCommand = new AsyncRelayCommand<string>(AddVideoAsync);
            AddLinkCommand = new RelayCommand<string>(AddLink);

            PostCommand = new AsyncRelayCommand(PostAsync);
        }

        public void SetSelectedCategory(CategoryDto category)
        {
            SelectedCategory = category;
            OnPropertyChanged(nameof(SelectedCategoryDisplay));
            OnPropertyChanged(nameof(SelectedCategoryIcon));
        }

        private Task AddPhotoAsync(string path)
        {
            if (!string.IsNullOrEmpty(path))
                ImagePaths.Add(path);
            return Task.CompletedTask;
        }

        private Task AddVideoAsync(string path)
        {
            if (!string.IsNullOrEmpty(path))
                VideoPaths.Add(path);
            return Task.CompletedTask;
        }

        private void AddLink(string link)
        {
            if (!string.IsNullOrEmpty(link))
                Links.Add(link);
        }

        private async Task PostAsync()
        {
            ErrorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(Title) || string.IsNullOrWhiteSpace(Content) || SelectedCategory == null)
            {
                ErrorMessage = "Please fill all required fields and select a category.";
                return;
            }

            var postDto = new PostCreateDto
            {
                Title = Title,
                Content = Content,
                CategoryId = SelectedCategory.Id,
                ImagePaths = new List<string>(ImagePaths),
                VideoPaths = new List<string>(VideoPaths),
                Links = new List<string>(Links)
            };

            bool success = await _postService.CreateAsync(postDto);

            if (success)
                ErrorMessage = "Post published successfully!";
            else
                ErrorMessage = "Failed to publish post.";
        }
    }
}
