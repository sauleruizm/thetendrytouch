using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Web.TendryTouch.Models
{
	
	public class Product
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ProducId { get; set; }

		/// <summary>
		/// It's a compleate barcode country+manofacture+id[productcode]
		/// </summary>
		[MaxLength(13)]
		[MinLength(13)]
		public string Barcode { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public DateTime Created { get; set; }

		/// <summary>
		/// Precio de compra
		/// </summary>
		public decimal Price { get; set; }

		public decimal PriceSale { get; set; }

		public int Quantity { get; set; }

		public int QuantitySale { get; set; }

		/// <summary>
		/// Define a relationship between Product & Stock
		/// show a list of stocks of this product
		/// </summary>
		public virtual ICollection<Stock> Stock {get; set;}

	}
}