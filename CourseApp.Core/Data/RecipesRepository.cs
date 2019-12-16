using CourseApp.Core.Infarstructure;
using CourseApp.Core.Models;
using SQLite;
using System;
using System.Linq;

namespace CourseApp.Core.Data
{
    public class RecipesRepository : IRecipesRepository
	{
        private SQLiteConnection _db = null;

        public RecipesRepository()
		{
            _db = new SQLiteConnection(Defines.DbFilePath);
            _db.CreateTable<Recipe>();
        }


        public IQueryable<Recipe> GetAllRecipe()
        {
            return _db.Table<Recipe>().AsQueryable();
        }

        public Recipe AddOrReplaceRecipe(Recipe recipe)
        {
            try
            {
                _db.InsertOrReplace(recipe);
                return recipe;
            }

            catch 
            {
                return null;
            }
        }
    }
}
