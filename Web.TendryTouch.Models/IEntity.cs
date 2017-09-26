﻿namespace Web.TendryTouch.Models
{
	using System;

	/// <summary>
	/// Base class for RepositoryPattern
	/// </summary>
	public class IEntity
	{
		public DateTime CreatedDate { get; set; }

		public string CreatedBy { get; set; }

		public DateTime ModifiedDate { get; set; }

		public string ModifiedBy { get; set; }
	}
}
