using CourseApp.Core.Models;
using System.Linq;

namespace CourseApp.Core.Infarstructure
{
    public interface IRecipesService
    {
        IQueryable<Recipe> GetRecipesByDishesCategoryId(int dishesCategoryId);
        Recipe AddOrReplaceRecipe(Recipe recipe);
    }
}
