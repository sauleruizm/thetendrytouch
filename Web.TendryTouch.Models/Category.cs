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


		//[Key, ForeignKey("Product")]
		//[Column(Order = 2)]
		//public int ProductId { get; set; }

		public virtual Product Product { get; set; }

		//[Key, ForeignKey("BarcodeHistory")]
		//[Column(Order = 3)]
		//public int BarcodeId { get; set; }

		//public virtual BarcodeHistory Barcode { get; set; }	
		
	}
}
