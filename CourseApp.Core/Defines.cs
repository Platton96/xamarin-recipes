﻿using CourseApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;

namespace CourseApp.Core
{
    public static class Defines
    {
        public static readonly string DbFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "myrecipes.db");
        public static ObservableCollection<DishesCategory> GetDishesCategories()
        {
            return new ObservableCollection<DishesCategory>
            {
                new DishesCategory
                {
                    Id = 0,
                    Name = "Супы",
                    FileName = "soup"
                },

                new DishesCategory
                {
                    Id = 1,
                    Name = "Напитки",
                    FileName = "drinks"
                },

                new DishesCategory
                {
                    Id = 2,
                    Name = "Десерты",
                    FileName = "deserts"
                },

    
                new DishesCategory
                {
                    Id = 3,
                    Name = "Закатки",
                    FileName = "jams"
                },

                new DishesCategory
                {
                    Id = 4,
                    Name = "Салаты",
                    FileName = "salads"
                },

                   new DishesCategory
                {
                    Id = 5,
                    Name = "Соусы",
                    FileName = "sauses"
                },

                   new DishesCategory
                {
                    Id = 6,
                    Name = "Закуски",
                    FileName = "snacks"
                },
                      new DishesCategory
                {
                    Id = 7,
                    Name = "Cупы",
                    FileName = "soup"
                }
            };
        }
    }
}
