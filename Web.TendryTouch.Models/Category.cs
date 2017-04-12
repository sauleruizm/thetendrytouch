using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.TendryTouch.Models
{
	[Table("category")]
	public class Category
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }

		public string Name { get; set; }

		public virtual Product Product { get; set; }

		
	}
}
