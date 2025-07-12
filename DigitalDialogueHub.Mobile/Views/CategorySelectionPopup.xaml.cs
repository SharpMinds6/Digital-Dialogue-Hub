using Microsoft.Maui.Controls;
using DigitalDialogueHub.Mobile.Services;

namespace DigitalDialogueHub.Mobile.Views
{
    public partial class CategorySelectionPopup : CommunityToolkit.Maui.Views.Popup
    {
        private readonly CategoryService _categoryService;

        // Konstruktor prima servis kroz DI
        public CategorySelectionPopup(CategoryService categoryService)
        {
            InitializeComponent();
            _categoryService = categoryService;
        }
    }
}
