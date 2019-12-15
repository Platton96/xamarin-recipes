using CourseApp.Core.Infarstructure;
using CourseApp.Core.Models;
using System.Linq;

namespace CourseApp.Core.Service
{
    public class RecipesService : IRecipesService
    {

        private IRecipesRepository _recipesRepository;

        public RecipesService(IRecipesRepository recipesRepository)
        {
            _recipesRepository = recipesRepository;
        }


        public IQueryable<Recipe> GetRecipesByDishesCategoryId(int dishesCategoryId)
        {
            return _recipesRepository.GetAllRecipe()
                .Where(r => r.DishesCategoryId == dishesCategoryId);
        }

        public Recipe AddOrReplaceRecipe(Recipe recipe)
        {
            return _recipesRepository.AddOrReplaceRecipe(recipe);
        }
    }
}
