using System;
using Microsoft.Maui.Controls;
using CommunityToolkit.Maui.Views;
using DigitalDialogueHub.Mobile.ViewModels;
using DigitalDialogueHub.Mobile.DTOs;
using DigitalDialogueHub.Mobile.Services;
using Microsoft.Maui.Storage;


namespace DigitalDialogueHub.Mobile.Views { 

public partial class NewPostPage : ContentPage
{
    private readonly CategoryService _categoryService;

    public NewPostPage(CategoryService categoryService)
    {
        InitializeComponent();
        _categoryService = categoryService;
    }

    private async void OnChooseCategoryTapped(object sender, EventArgs e)
    {
        var popup = new CategorySelectionPopup(_categoryService);
        var selectedCategory = await this.ShowPopupAsync(popup) as CategoryDto; // ili odgovarajuæi DTO

        if (selectedCategory != null && BindingContext is NewPostPageViewModel vm)
            vm.SetSelectedCategory(selectedCategory);
    }


    private async void OnCloseTapped(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        // Upload slike
        private async void OnAddPhotoTapped(object sender, EventArgs e)
        {
            var result = await FilePicker.Default.PickAsync(new PickOptions
            {
                PickerTitle = "Select a photo",
                FileTypes = FilePickerFileType.Images
            });

            if (result != null && BindingContext is NewPostPageViewModel vm)
                vm.AddPhotoCommand.Execute(result.FullPath);
        }

        // Upload video
        private async void OnAddVideoTapped(object sender, EventArgs e)
        {
            var result = await FilePicker.Default.PickAsync(new PickOptions
            {
                PickerTitle = "Select a video",
                FileTypes = FilePickerFileType.Videos
            });

            if (result != null && BindingContext is NewPostPageViewModel vm)
                vm.AddVideoCommand.Execute(result.FullPath);
        }

        // Dodavanje linka
        private async void OnAddLinkTapped(object sender, EventArgs e)
        {
            var link = await DisplayPromptAsync("Add Link", "Paste a link:");
            if (!string.IsNullOrWhiteSpace(link) && BindingContext is NewPostPageViewModel vm)
                vm.AddLinkCommand.Execute(link);
        }
    }
}
