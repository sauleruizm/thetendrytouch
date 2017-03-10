using System.Threading.Tasks;

namespace Web.TendryTouch.WebApi.Data.RepositoryPattern
{
	public interface IRepository: IReadOnlyRepository
	{
		void Create<TEntity>(TEntity entity, string createdBy = null)
		where TEntity : IEntity;

		void Update<TEntity>(TEntity entity, string modifiedBy = null)
			where TEntity : IEntity;

		void Delete<TEntity>(object id)
			where TEntity : IEntity;

		void Delete<TEntity>(TEntity entity)
			where TEntity : IEntity;

		void Save();

		Task<int> SaveAsync();
	}
}
