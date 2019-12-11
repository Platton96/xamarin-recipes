using CourseApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CourseApp.Core
{
    public static class Defines
    {
        public static ObservableCollection<DishesCategory> GetDishesCategories()
        {
            return new ObservableCollection<DishesCategory>
            {
                new DishesCategory
                {
                    Id = 1,
                    Name = "Супы",
                    FileName = "soups"
                },

                new DishesCategory
                {
                    Id = 2,
                    Name = "Гарниры",
                    FileName = "side_dishes"
                },

                new DishesCategory
                {
                    Id = 3,
                    Name = "Каши",
                    FileName = "porridge"
                },

                new DishesCategory
                {
                    Id = 4,
                    Name = "Десерты",
                    FileName = "dessert"
                },

                new DishesCategory
                {
                    Id = 5,
                    Name = "bacery_products",
                    FileName = "soups"
                },

                new DishesCategory
                {
                    Id = 6,
                    Name = "salads",
                    FileName = "soups"
                },
            };
        }
    }
}
