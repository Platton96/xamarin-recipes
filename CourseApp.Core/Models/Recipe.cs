using SQLite;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CourseApp.Core.Models
{
    [Table("Recipes")]
    public class Recipe
	{
        [PrimaryKey]
        public string Id { get; set; }

		public string Title { get; set; }

		public string Description { get; set; }

		public string ImagePath{ get; set; }

		public bool? Favorite { get; set; }
        
        public int DishesCategoryId { get; set; }



    }
}
