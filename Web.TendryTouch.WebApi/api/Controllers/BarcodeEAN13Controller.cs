using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Web.Http;
using Web.TendryTouch.WebApi.Data;
using Zen.Barcode;

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

					var barimg = Zen.Barcode.CodeEan13Checksum.Instance;

					var draw = new Zen.Barcode.CodeEan13BarcodeDraw(barimg);
					
					BarcodeMetrics barcodeMatrix = new BarcodeMetrics1d(newBarcode.Width, 
						newBarcode.Height);


					var img = draw.Draw( text, barcodeMatrix);
					var memoryStream = new MemoryStream();
					img.Save(memoryStream,System.Drawing.Imaging.ImageFormat.Png);
				
					var response = new HttpResponseMessage(HttpStatusCode.OK) 
					{
						Content = new ByteArrayContent(memoryStream.ToArray()),
						
						//Content = new MediaTypeHeaderValue("image/jpeg"),
					   
						StatusCode = HttpStatusCode.OK
					};
					response.Content.Headers.Add("content-disposition", "attachment; filename=test.png");
					response.Content.Headers.Add("content-Type", "image/png");
					return response;
				}
				catch (Exception ex)
				{

					throw;
				}
			}

		#endregion -- Methods --;

	}
}
