﻿using CourseApp.Core.Models;
using System.Linq;

namespace CourseApp.Core.Infarstructure
{
    public interface IRecipesRepository
    {
        IQueryable<Recipe> GetAllRecipe();
        Recipe AddOrReplaceRecipe(Recipe recipe);

    }
}
