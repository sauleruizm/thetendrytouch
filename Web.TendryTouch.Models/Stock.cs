using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.TendryTouch.Models
{
	public class Stock
	{
		#region -- Properties --			

			[Key]
			[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
			public int StockId { get; set; }

			/// <summary>
			/// Precio de compra
			/// </summary>
			public decimal Price { get; set; }

			public decimal PriceSale { get; set; }

			public int Quantity { get; set; }

			public int QuantitySale { get; set; }

			/// <summary>
			/// Date that was add the new stock items
			/// </summary>
			public DateTime DateAdded { get; set; }

			/// <summary>
			/// Define a relationship between product table [father]
			/// and stock [child]
			/// </summary>
			public int ProductId { get; set; }
			public virtual Product Product { get; set; } 

		#endregion -- Properties --;
	}
}
