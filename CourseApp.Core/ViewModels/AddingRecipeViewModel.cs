using CourseApp.Core.Models;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CourseApp.Core.ViewModels
{

    public class AddingRecipeViewModel :  MvxViewModel<DishesCategory>
    {
        private readonly IMvxNavigationService _mvxNavigationService;
        private DishesCategory _dishesCategory;


        public override void Prepare(DishesCategory parameter)
        {
            _dishesCategory = parameter;
        }

    }
}
