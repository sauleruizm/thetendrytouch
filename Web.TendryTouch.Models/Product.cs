using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Web.TendryTouch.Models
{
	[Table("product")]
	public partial class Product: IEntity
	{		

		//[Key, Column(Order= 1)]
		//public int ProductId { get; set; }

		/// <summary>
		/// Define a relationship between Product & BarcodeHistory
		/// show a list of Barcode of this product
		/// </summary>
		[Key,Column(Order = 1), ForeignKey(name: "BarcodeHistory")]
		public int BarcodeId { get; set; }
		public virtual BarcodeHistory BarcodeHistory { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public DateTime Created { get; set; }

		/// <summary>
		/// Precio de compra
		/// </summary>
		public decimal Price { get; set; }

		public decimal PriceSale { get; set; }

		public int Quantity { get; set; }

		

		//public virtual Category Categories { get; set; }

	}
}