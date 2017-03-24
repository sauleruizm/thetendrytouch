using System.Data.Entity;
using Web.TendryTouch.WebApi.Data;

namespace Web.TendryTouch.WebApi.Data
{
	public class MySqlDatabaseInitialization : DropCreateDatabaseIfModelChanges<MySqlContext>
	{
		protected override void Seed(MySqlContext context)
		{
			
		}	

		
	}
}