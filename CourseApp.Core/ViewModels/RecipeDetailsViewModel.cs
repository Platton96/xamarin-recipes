using CourseApp.Core.Models;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseApp.Core.ViewModels
{
    public class RecipeDetailsViewModel : MvxViewModel<Recipe>
    {
        private string _recipeDescription;
        private string _recipeImagePath;

        public string RecipeImagePath
        {
            get => _recipeImagePath;
            set
            {
                _recipeImagePath = value;
                RaisePropertyChanged(() => RecipeImagePath);
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

        public override void Prepare(Recipe parameter)
        {
            RecipeDescription = parameter.Description;
            RecipeImagePath = parameter.ImagePath;
        }
    }
}
