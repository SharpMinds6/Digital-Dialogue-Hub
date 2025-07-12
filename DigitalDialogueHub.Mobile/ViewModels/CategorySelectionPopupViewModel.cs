using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DigitalDialogueHub.Mobile.DTOs;
using System.Threading.Tasks;
using DigitalDialogueHub.Mobile.Views;

namespace DigitalDialogueHub.Mobile.ViewModels
{
    public partial class CategorySelectionPopupViewModel : ObservableObject
    {
        private readonly CategoryService _categoryService;
        private readonly Action<CategoryDto> _closePopup;

        public ObservableCollection<CategoryDto> Categories { get; set; } = new();
        public ICommand SelectCategoryCommand { get; }

        public CategorySelectionPopupViewModel(CategoryService categoryService, Action<CategoryDto> closePopup)
        {
            _categoryService = categoryService;
            _closePopup = closePopup;

            SelectCategoryCommand = new RelayCommand<CategoryDto>(OnCategorySelected);

            LoadCategories();
        }

        private async void LoadCategories()
        {
            var categories = await _categoryService.GetAllAsync();
            Categories.Clear();
            foreach (var cat in categories)
                Categories.Add(cat);
        }

        private void OnCategorySelected(CategoryDto selected)
        {
            _closePopup?.Invoke(selected);
        }
    }
}
