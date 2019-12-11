using CourseApp.Core.Data;
using CourseApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseApp.Core.Service
{
	public class RecipesService
	{

		private RecipesRepository _newsLocalRepository;

		public RecipesService()
		{
			_newsLocalRepository = new RecipesRepository(GetDbPath());
		}

		public void Save(Dishes recipes)
		{
			_newsLocalRepository.Save(recipes);
		}

		public IEnumerable<Dishes> GetAllSavedForReadLater()
		{
			return _newsLocalRepository.GetAll();
		}

		public void Delete(int id)
		{
			_newsLocalRepository.Delete(id);
		}

		public void Delete(List<int> ids)
		{
			ids.ForEach(x => Delete(x));
		}

		public void DeleteAll()
		{
			_newsLocalRepository.DeleteAll();
		}
		public static readonly string DbName = "notiXamarinDb.db";

		public static string GetDbPath()
		{
			string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
			return System.IO.Path.Combine(folder, DbName);
		}
	}
}
