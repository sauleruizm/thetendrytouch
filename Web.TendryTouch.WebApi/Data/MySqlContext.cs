using System.Data.Entity;
using MySql.Data.Entity;
using Web.TendryTouch.Models;

namespace Web.TendryTouch.WebApi.Models
{
	/// <summary>
	/// 
	/// </summary>
	[DbConfigurationType(typeof(MySqlEFConfiguration))]
	public partial class MySqlContext: DbContext
	{
		#region -- Constructors, destructors, and finalizers --

			//public MySqlContext(string nameOrconnectionString) : 
			//	base(MySqlDbConfiguration.GetMySqlConnection(nameOrconnectionString),true) {
			//	Database.CreateIfNotExists();
			//}

		public MySqlContext()
			: base(nameOrConnectionString: "name=myDbEntities")
		{
		}

		#endregion -- Constructors, destructors, and finalizers --;


		#region -- Properties --

			public DbSet<Product> Products { get; set; }

			public DbSet<Category> Categories { get; set; }

			public DbSet<BarcodeHistory> Barcodes { get; set; }

		#endregion -- Properties --;


		#region -- Methods --

			protected override void OnModelCreating(DbModelBuilder modelBuilder)
			{
			}

		#endregion -- Methods --;
	}
}