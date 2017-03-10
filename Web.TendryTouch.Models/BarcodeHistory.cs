using System.ComponentModel.DataAnnotations;

namespace Web.TendryTouch.Models
{
	public class BarcodeHistory
	{
		/// <summary>
		/// Contry name of manufacturer
		/// </summary>
		[Key()]
		public int Country
		{
			get;
			set;
		}

		/// <summary>
		/// Category of item
		/// </summary>
		[Required()]
		public int TypeProduct
		{
			get;
			set;
		}

		/// <summary>
		/// Unique identifier of item
		/// </summary>
		public int CodeProduct
		{
			get;
			set;
		}

		/// <summary>
		/// Briefly description of item
		/// </summary>
		public int Description
		{
			get;
			set;
		}

		/// <summary>
		/// Name of item
		/// </summary>
		public int Name
		{
			get;
			set;
		}

		/// <summary>
		/// Consecutive Identifier
		/// </summary>
		[Key()]
		public int ID
		{
			get;
			set;
		}
	}
}
