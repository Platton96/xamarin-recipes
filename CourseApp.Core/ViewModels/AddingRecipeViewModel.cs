using CourseApp.Core.Infarstructure;
using CourseApp.Core.Models;
using MvvmCross.ViewModels;
using System;

namespace CourseApp.Core.ViewModels
{

    public class AddingRecipeViewModel : MvxViewModel<DishesCategory>
    {
        private readonly IRecipesService _recipesService;

        private DishesCategory _dishesCategory;
        private string _recipeTitle;
        private string _recipeDescription;
        private string _recipeId;
        

        public string RecipeImagePath { get; set; }

        public string RecipeTitle
        {
            get => _recipeTitle;
            set
            {
                _recipeTitle = value;
                RaisePropertyChanged(() => RecipeTitle);
            }
        }

        public string RecipeDescription
        {
            get => _recipeDescription;
            set
            {
                _recipeDescription = value;
                RaisePropertyChanged(() => RecipeDescription);
            }
        }

        public AddingRecipeViewModel(IRecipesService recipesService)
        {
            _recipesService = recipesService;
        }
        public override void Prepare(DishesCategory parameter)
        {
            _dishesCategory = parameter;
        }

        public Recipe SaveRecipe()
        {
            _recipeId = _recipeId ?? Guid.NewGuid().ToString();
            var recipe = new Recipe
            {
                Id = _recipeId,
                Title = RecipeTitle,
                Description = RecipeDescription,
                Favorite = false,
                ImagePath = RecipeImagePath,
                DishesCategoryId = _dishesCategory.Id
            };
            
            return _recipesService.AddOrReplaceRecipe(recipe);
        }

    }
}
