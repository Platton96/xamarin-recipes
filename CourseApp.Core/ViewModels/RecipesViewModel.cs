using CourseApp.Core.Infarstructure;
using CourseApp.Core.Models;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Core.ViewModels
{
    public class RecipesViewModel : MvxViewModel<DishesCategory>
    {
        private readonly IMvxNavigationService _mvxNavigationService;
        private readonly IRecipesService _recipesService;

        private DishesCategory _dishesCategory;
        private ObservableCollection<Recipe> _dishesCategoryRecipes;

        public IMvxCommand NavigateToAddingRecipeAsyncCommand => new MvxAsyncCommand(DoNavigateToAddingRecipeAsync);
        public IMvxCommand NavigateToEdingRecipeAsyncCommand => new MvxAsyncCommand<Recipe>(DoNavigateToEditingRecipeAsync);
        public IMvxCommand NavigateToRecipeDetailsAsyncCommand => new MvxAsyncCommand<Recipe>(DoNavigateToRecipeDetailsAsync);
        public ObservableCollection<Recipe> DishesCategoryRecipes
        {
            get => _dishesCategoryRecipes;
            set
            {
                _dishesCategoryRecipes = value;
                RaisePropertyChanged(() => DishesCategoryRecipes);
            }
        }

        public RecipesViewModel(IMvxNavigationService mvxNavigationService, IRecipesService recipesService)
        {
            _mvxNavigationService = mvxNavigationService;
            _recipesService = recipesService;
        }
        public override void ViewCreated()
        {
            base.ViewCreated();
            var dishesCategoryRecipes = _recipesService.GetRecipesByDishesCategoryId(_dishesCategory.Id);

            DishesCategoryRecipes = dishesCategoryRecipes == null ?
                new ObservableCollection<Recipe>()
                : new ObservableCollection<Recipe>(dishesCategoryRecipes);

        }
        private async Task DoNavigateToAddingRecipeAsync()
        {
            var newRecipeModel = new EditRecipeModel
            {
                DishesCategory = _dishesCategory
            };

            await _mvxNavigationService.Navigate<AddingRecipeViewModel, EditRecipeModel>(newRecipeModel);
        }
        private async Task DoNavigateToEditingRecipeAsync(Recipe recipe)
        {
            var editRecipeModel = new EditRecipeModel
            {
                DishesCategory = _dishesCategory,
                Recipe = recipe
            };

            await _mvxNavigationService.Navigate<AddingRecipeViewModel, EditRecipeModel>(editRecipeModel);
        }
        public override void Prepare(DishesCategory parameter)
        {
            _dishesCategory = parameter;
        }
        private async Task DoNavigateToRecipeDetailsAsync(Recipe recipe)
        {
            await _mvxNavigationService.Navigate<RecipeDetailsViewModel, Recipe>(recipe);
        }
    }
}
