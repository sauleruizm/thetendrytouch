
using System.Drawing;
namespace Web.TendryTouch.WebApi.Models
{
	public class BarcodeCreateResponseModel : BarcodeCreateRequestModel
	{
		/// <summary>
		/// Representation of barcode image on byte array
		/// </summary>
		public Image[] Barcode { get; set; }
	}
}