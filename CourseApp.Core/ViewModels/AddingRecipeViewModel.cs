using CourseApp.Core.Models;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CourseApp.Core.ViewModels
{

    public class AddingRecipeViewModel : MvxViewModel<DishesCategory>
    {
        private readonly IMvxNavigationService _mvxNavigationService;
        private DishesCategory _dishesCategory;
        private string _recipeTitle;
        private string _recipeDescription;

        public IMvxCommand SaveRecipeCamand => new MvxCommand(DoSaveRecipe);

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


        public override void Prepare(DishesCategory parameter)
        {
            _dishesCategory = parameter;
        }

        private void DoSaveRecipe()
        {

        }

    }
}
