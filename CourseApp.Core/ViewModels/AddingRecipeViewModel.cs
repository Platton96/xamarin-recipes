using CourseApp.Core.Infarstructure;
using CourseApp.Core.Models;
using MvvmCross.ViewModels;
using System;
using System.Threading.Tasks;
using MvvmCross.Plugin.File;
using System.Collections;
using System.Collections.Generic;

namespace CourseApp.Core.ViewModels
{

    public class AddingRecipeViewModel : MvxViewModel<EditRecipeModel>
    {
        private readonly IRecipesService _recipesService;
        private readonly IMvxFileStoreAsync _mvxFileStore;
        private EditRecipeModel _editRecipeModel;
        private DishesCategory _dishesCategory;
        private string _recipeTitle;
        private string _recipeDescription;
        private string _recipeId;

        public IEnumerable<byte> RecipeImageBytes { get; set; }

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

        public AddingRecipeViewModel(IRecipesService recipesService, IMvxFileStoreAsync mvxFileStoreAsync)
        {
            _recipesService = recipesService;
            _mvxFileStore = mvxFileStoreAsync;
        }
        public override void Prepare(EditRecipeModel parameter)
        {
            _editRecipeModel = parameter;
            _dishesCategory = _editRecipeModel.DishesCategory;
            if (_editRecipeModel.Recipe != null)
            {
                _recipeId = _editRecipeModel.Recipe.Id;
                RecipeTitle = _editRecipeModel.Recipe.Title;
                RecipeDescription = _editRecipeModel.Recipe.Description;
            }
        }

        public async Task<Recipe> SaveRecipeAsync()
        {
            if (RecipeImageBytes != null && !string.IsNullOrEmpty(RecipeTitle))
            {
                await WriteImageImageToStoreAsync();
            }

            _recipeId = _recipeId ?? Guid.NewGuid().ToString();
            var recipe = new Recipe
            {
                Id = _recipeId,
                Title = RecipeTitle,
                Description = RecipeDescription,
                Favorite = false,
                DishesCategoryId = _dishesCategory.Id
            };

            return _recipesService.AddOrReplaceRecipe(recipe);
        }
        public async Task<string> WriteImageImageToStoreAsync()
        {
            try
            {
                await _mvxFileStore.WriteFileAsync(RecipeTitle, RecipeImageBytes);
                return RecipeTitle;
            }
            catch (Exception)
            {

                return null;
            }
        }

    }
}
