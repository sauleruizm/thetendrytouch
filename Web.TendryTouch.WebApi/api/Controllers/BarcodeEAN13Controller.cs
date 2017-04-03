using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web.TendryTouch.WebApi.Models;
using Zen.Barcode;
using Web.TendryTouch.WebApi.Extension;
using System.Drawing.Imaging;

namespace Web.TendryTouch.WebApi.Controllers
{
    public class BarcodeEAN13Controller : ApiController
	{
		#region -- Private constants --
		#endregion -- Private constants --;

		#region -- Private member variables --
			
			/// <summary>
			/// variable for create a barcode for EAN13 format
			/// </summary>
		private Lazy<Zen.Barcode.CodeEan13BarcodeDraw> _ean13 = new Lazy<CodeEan13BarcodeDraw>();

		#endregion -- Private member variables --;

		#region -- Properties --


		#endregion -- Properties --;

		#region -- Methods --

			/// <summary>
			/// Create a new EAN13 barcode.
			/// </summary>
			/// <param name="newBarcode">Data about the new barcode</param>
			/// <returns></returns>
			[HttpPost]
			public HttpResponseMessage Create([FromBody]BarcodeCreateRequestModel newBarcode)
			{
				try
				{
					string text = string.Concat<int>( new int[] { newBarcode.GS1Prefix,
						newBarcode.ManufacterCode, newBarcode.ProductCode });

					var img = BarcodeDrawFactory
						.CodeEan13WithChecksum
							.Draw(text, newBarcode.Height, newBarcode.Scale)
							.AddText(text, newBarcode.ColorText);
					
					var memoryStream = new MemoryStream();
					img.Save(memoryStream, ImageFormat.Png);
					
					var response = new HttpResponseMessage(HttpStatusCode.OK) 
					{
						Content = new ByteArrayContent(memoryStream.ToArray()),					   
						StatusCode = HttpStatusCode.OK
					};
					response.Content.Headers.Add("content-disposition", "attachment; filename=test.png");
					response.Content.Headers.Add("content-Type", "image/png");
					return response;
				}
				catch (Exception )
				{
					return new HttpResponseMessage(HttpStatusCode.OK) {  StatusCode = HttpStatusCode.BadRequest };
				}
			}

			
		#endregion -- Methods --;

	}
}