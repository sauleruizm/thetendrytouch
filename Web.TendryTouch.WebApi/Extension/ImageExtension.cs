using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace Web.TendryTouch.WebApi.Extension
{
	public static class ImageExtensions
	{		
		#region -- Methods --

			/// <summary>
			/// Extension Method
			/// Add text to a image on bottom part
			/// </summary>
			/// <param name="image">Image</param>
			/// <param name="text">Text to add</param>
			/// <param name="colorText">Color of font</param>
			/// <returns>Image with text on bottom part</returns>
			public static Image AddText(this Image image, string text, Color colorText )
			{
				var graphic = Graphics.FromImage(image);
				var font = new Font("arial", 10, FontStyle.Bold);

				graphic.SmoothingMode = SmoothingMode.AntiAlias;
				graphic.TextRenderingHint = TextRenderingHint.AntiAlias;
				
				SolidBrush brush = new SolidBrush(colorText);

				Bitmap outputImage = new Bitmap(image.Width, image.Height + font.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
				Bitmap secondImage = new Bitmap(image.Width, image.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

				using (Graphics g = Graphics.FromImage(outputImage))
				{
					g.DrawImage(image, new Rectangle(new Point(), outputImage.Size),
						new Rectangle(new Point(), outputImage.Size), GraphicsUnit.Pixel);

					g.DrawImage(secondImage, new Rectangle(new Point(0, image.Height + 1), secondImage.Size),
						new Rectangle(new Point(), secondImage.Size), GraphicsUnit.Pixel);

					g.DrawString(text, font, brush, new RectangleF(new Point(0, secondImage.Height), new Size(secondImage.Width, secondImage.Height)));				
				}

				return outputImage;
			}

		#endregion -- Methods --;
	}
}