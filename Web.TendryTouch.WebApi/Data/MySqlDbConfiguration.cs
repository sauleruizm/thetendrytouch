using System.Data.Common;
using System.Data.Entity;
using MySql.Data.Entity;
using MySql.Data.MySqlClient;

namespace Web.TendryTouch.WebApi.Models
{
	[DbConfigurationType(typeof(MySqlEFConfiguration))]
	public class MySqlDbConfiguration :MySqlEFConfiguration
	{
		/// <summary>
		/// Set the initial infrastructure.
		/// </summary>
		public MySqlDbConfiguration()
		{
			SetProviderServices(MySqlProviderInvariantName.ProviderName, new MySqlProviderServices());
			SetDatabaseInitializer(new MySqlDatabaseInitialization());
		}

		public static DbConnection GetMySqlConnection(string connectionString)
		{
			var connectionFactory = new MySqlConnectionFactory();

			return connectionFactory.CreateConnection(connectionString);
		}
	}
}