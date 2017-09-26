using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Web.TendryTouch.Models;

namespace Web.TendryTouch.WebApi.api.Controllers
{
    public class CategoryController : BaseApiController
	{
		#region -- Methods --

			// GET api/category
			public async Task<IHttpActionResult> Get()
			{
				return Ok(_repository.GetAllAsync<Category>());
			}

			// GET api/category/5
			public async Task<IHttpActionResult> Get(int id)
			{
				return Ok(_repository.GetByIdAsync<Category>(id:id));
			}

			// POST api/category
			public void Post([FromBody]Category value)
			{
				try
				{
					_repository.Create<Category>(value, "sauleruizm");
					_repository.Save();
				}
				catch (System.Exception)
				{
					
					throw;
				}
			}

			// PUT api/category/5
			public void Put(int id, [FromBody]string value)
			{
			}

			// DELETE api/category/5
			public void Delete(int id)
			{
			}
		
		#endregion -- Methods --;
    }
}
