﻿using CourseApp.Core.Models;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace CourseApp.Core.ViewModels
{
    public class HomePageViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _mvxNavigationService;
        private ObservableCollection<DishesCategory> _dishesCategories;

        public IMvxCommand NavigateToRecipesAsyncCommand => new MvxAsyncCommand<DishesCategory>(DoNavigateToRecipesAsync);
        public HomePageViewModel(IMvxNavigationService mvxNavigationService)
        {
            _mvxNavigationService = mvxNavigationService;
        }

        public ObservableCollection<DishesCategory> DishesCategories
        {
            get => _dishesCategories;
            set
            {
                _dishesCategories = value;
                RaisePropertyChanged(() => DishesCategories);
            }
        }

        public override void ViewCreated()
        {
            base.ViewCreated();
            InitiaizeDiahesCotigories();
        }
        private async Task DoNavigateToRecipesAsync(DishesCategory dishesCategory)
        {
            await _mvxNavigationService.Navigate<RecipesViewModel, DishesCategory>(dishesCategory);
        }

        private void InitiaizeDiahesCotigories()
        {
            DishesCategories = Defines.GetDishesCategories();
        }

    }

}
