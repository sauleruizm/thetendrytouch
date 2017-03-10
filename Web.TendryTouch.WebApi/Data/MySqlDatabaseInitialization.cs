using System.Data.Entity;
using Web.TendryTouch.WebApi.Data;

namespace Web.TendryTouch.WebApi.Data
{
	public class MySqlDatabaseInitialization : CreateDatabaseIfNotExists<MySqlContext>
	{
		protected override void Seed(MySqlContext context)
		{
			context.Products.Add(
				new Models.Product { Barcode = "74512345123453", 
					Description="Test propuse", Name ="Product Test"  }
				);
		}	

		
	}
}