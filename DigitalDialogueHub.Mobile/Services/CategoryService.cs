using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalDialogueHub.Mobile.DTOs;

public class CategoryService
{
    // Za sada hardkodirane kategorije, kasnije zamijeni sa http pozivom
    public Task<List<CategoryDto>> GetAllAsync()
    {
        var categories = new List<CategoryDto>
        {
                new CategoryDto { Name = "All", IconPath = "all_icon.png" },
                new CategoryDto { Name = "Literature", IconPath = "emoji_books.png" },
                new CategoryDto { Name = "Art", IconPath = "emoji_artistpalette.png" },
                new CategoryDto { Name = "History", IconPath = "illustration_thegreatpyramid.png" },
                new CategoryDto { Name = "Technology", IconPath = "illustration_artifical_inteligence.png" },
                new CategoryDto { Name = "Sport", IconPath = "sport_icon.png" },
                new CategoryDto { Name = "Mathematics & Logic", IconPath = "math_icon.png" },
                new CategoryDto { Name = "Health", IconPath = "icon_health.png" },
                new CategoryDto { Name = "Psychology", IconPath = "psycology_icon.png" },
                new CategoryDto { Name = "Architecture", IconPath = "icon_architecture.png" },
                new CategoryDto { Name = "Research & Innovation", IconPath = "research_icon.png" },
                new CategoryDto { Name = "Business & Economics", IconPath = "business_icon.png" },
                new CategoryDto { Name = "Food", IconPath = "food_icon.png" }
        };
        return Task.FromResult(categories);
    }
}
