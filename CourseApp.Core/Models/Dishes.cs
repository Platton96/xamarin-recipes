using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseApp.Core.Models
{
	public class Dishes 
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }

		public string Name { get; set; }

		public List<Recipe> Recipes { get; set; }
	}
}
