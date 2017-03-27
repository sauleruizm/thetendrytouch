namespace Web.TendryTouch.WebApi.Models
{
	using System.Data.Entity;
	using System.Data.Entity.Infrastructure;
	using System.Data.Entity.Migrations;
	using System.Diagnostics.Contracts;
	using Web.TendryTouch.WebApi.Models;

	public class MySqlDatabaseInitialization : DropCreateDatabaseAlways<MySqlContext>
	{

	}
}