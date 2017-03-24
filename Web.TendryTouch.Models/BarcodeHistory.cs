using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.TendryTouch.Models
{
	[Table("BarcodeHistory")]
	public partial class BarcodeHistory
	{
		/// <summary>
		/// Consecutive Identifier
		/// </summary>
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int BarcodeId { get; set; }

		/// <summary>
		/// Contry name of manufacturer
		/// </summary>
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

		/// <summary>
		/// Briefly description of item
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// Name of item
		/// </summary>
		public string Name { get; set; }

		public virtual Product Product { get; set; }
	}
}