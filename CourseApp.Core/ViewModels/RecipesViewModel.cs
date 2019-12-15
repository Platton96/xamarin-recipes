using CourseApp.Core.Models;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Core.ViewModels
{
    public class RecipesViewModel : MvxViewModel<DishesCategory>
    {
        private readonly IMvxNavigationService _mvxNavigationService;
        private DishesCategory _dishesCategory;

        public IMvxCommand NavigateToAddingRecipeAsyncCommand => new MvxAsyncCommand(DoNavigateToAddingRecipeAsync);

        public RecipesViewModel(IMvxNavigationService mvxNavigationService)
        {
            _mvxNavigationService = mvxNavigationService;
        }

        private async Task DoNavigateToAddingRecipeAsync()
        {
            await _mvxNavigationService.Navigate<AddingRecipeViewModel, DishesCategory>(_dishesCategory);
        }
        public override void Prepare(DishesCategory parameter)
        {
            _dishesCategory = parameter;
        }
    }
}
