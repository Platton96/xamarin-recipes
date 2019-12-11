using CourseApp.Core.Models;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseApp.Core.ViewModels
{
	public class RecipesViewModel : MvxViewModel<DishesCategory>
	{
        private DishesCategory _dishesCategory;
		public DishesCategory DishesCategory
        {
			get => _dishesCategory;
			set
			{
				_dishesCategory = value;
				RaisePropertyChanged(() => DishesCategory);
			}
		}
		public override void Prepare(DishesCategory parameter)
		{
			_dishesCategory = parameter;
		}
	}
}
