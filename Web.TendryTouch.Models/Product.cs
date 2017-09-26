using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Web.TendryTouch.Models
{
	[Table("product")]
	public partial class Product: IEntity
	{		
		/// <summary>
		/// Secuencial identification of product
		/// </summary>
		[Key, Column(Order= 1)]
		public int ProductId { get; set; }

		/// <summary>
		/// Name of product.
		/// </summary>
		[Required, MaxLength(64)]
		public string Name { get; set; }

		/// <summary>
		/// a extense description of product
		/// </summary>
		[MaxLength(512)]
		public string Description { get; set; }

		/// <summary>
		/// Precio de compra
		/// </summary>
		[Required]
		public decimal Price { get; set; }

		[Required]
		public decimal PriceSale { get; set; }
		
		[Required]
		public int Quantity { get; set; }

		[Required]
		public string Country { get; set; }

		/// <summary>
		/// Category of item
		/// </summary>
		[Required]
		public string TypeProduct { get; set; }

		/// <summary>
		/// Unique identifier of item
		/// </summary>
		public string CodeProduct { get; set; }

		public int CategoryId { get; set; }
		public virtual Category Category { get; set; }

	}
}