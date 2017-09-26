using System.Web.Http;
using Web.TendryTouch.WebApi.Models;
using Web.TendryTouch.WebApi.Models.RepositoryPattern;

namespace Web.TendryTouch.WebApi.api.Controllers
{
    public class BaseApiController : ApiController
	{
		#region -- Private constants --
		#endregion -- Private constants --;

		#region -- Private member variables --

			protected readonly IRepository _repository;

		#endregion -- Private member variables --;


		#region -- Constructors, destructors, and finalizers --

			/// <summary>
			/// Constructor by default use a instance of MySqlContext
			/// to initialize 
			/// </summary>
			public BaseApiController()
			{
				_repository = new EntityFrameworkRepository<MySqlContext>(new MySqlContext());
			}

			/// <summary>
			/// Use a Interface of IRepository to get a instance
			/// </summary>
			/// <param name="repository"></param>
			public BaseApiController(IRepository repository)
			{
				_repository = repository;
			}

		#endregion -- Constructors, destructors, and finalizers --;


		#region -- Properties --

			/// <summary>
			/// Data manager
			/// </summary>
			protected IRepository DataSourceManager 
			{
				get
				{
					return _repository ?? null;
				}
			}

		#endregion -- Properties --;


		#region -- Methods --
		#endregion -- Methods --;

	}
}
