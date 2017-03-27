using System.Drawing;

namespace Web.TendryTouch.WebApi.Models
{
	/// <summary>
	/// https://en.wikipedia.org/wiki/International_Article_Number
	/// </summary>
	public class BarcodeCreateRequestModel
	{
		/// <summary>
		/// Country code of article 2-3 digit
		/// https://en.wikipedia.org/wiki/List_of_GS1_country_codess
		/// </summary>
		public int GS1Prefix { get; set; }

		/// <summary>
		/// Unique code of manufacter 5 digit length
		/// </summary>
		public int ManufacterCode { get; set; }

		/// <summary>
		/// Unique code for product of manufacture 9-10 digit
		/// </summary>
		public int ProductCode { get; set; }

		/// <summary>
		/// Represent a returned barcode size
		/// </summary>
		public int Width { get; set; }

		public int Height { get; set; }
	}
}
