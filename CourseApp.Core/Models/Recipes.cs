using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CourseApp.Core.Models
{
	public class Recipe
	{
		[DataMember(Name = "id")]
		public int Id { get; set; }

		[DataMember(Name = "title")]
		public string Title { get; set; }

		[DataMember(Name = "name")]
		public string Name { get; set; }

		[DataMember(Name = "description")]
		public string Description { get; set; }

		[DataMember(Name = "image")]
		public string ImageRecipes { get; set; }

		[DataMember(Name = "name")]
		public string Product { get; set; }

		public bool? Favorite { get; set; }


		//[ForeignKey(typeof(Dishes))]
  //      public int EmployeeId { get; set; }
	}
}
