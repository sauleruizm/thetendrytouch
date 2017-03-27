using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Web.TendryTouch.WebApi.Models.RepositoryPattern
{
	public class EntityFrameworkReadOnlyRepository<TContext>: IReadOnlyRepository 
		where TContext: DbContext
	{

		#region -- Private member variables --

			protected readonly TContext _context;

		#endregion -- Private member variables --;

		#region -- Constructors, destructors, and finalizers --

			public EntityFrameworkReadOnlyRepository(TContext context)
			{
				_context = context;
			}

		#endregion -- Constructors, destructors, and finalizers --;

		#region -- Methods --

			public virtual IEnumerable<TEntity> GetAll<TEntity>(Func<IQueryable<TEntity>, 
				IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null, 
				int? skip = null, int? take = null) 
				where TEntity : class
			{
				return GetQueryable<TEntity>(null, orderBy, includeProperties, skip, take).ToList();
			}

			public virtual async Task<IEnumerable<TEntity>> GetAllAsync<TEntity>(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null, int? skip = null, int? take = null)
				where TEntity : class
			{
				return await GetQueryable<TEntity>(null, orderBy, includeProperties, skip, take).ToListAsync();
			}

			public virtual IEnumerable<TEntity> Get<TEntity>(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null, int? skip = null, int? take = null)
				where TEntity :  class
			{
				return GetQueryable<TEntity>(filter, orderBy, includeProperties, skip, take).ToList();    
			}

			public virtual async Task<IEnumerable<TEntity>> GetAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null, int? skip = null, int? take = null)
				where TEntity :  class
			{
				return await GetQueryable<TEntity>(filter, orderBy, includeProperties, skip, take).ToListAsync();
			}

			public virtual TEntity GetOne<TEntity>(Expression<Func<TEntity, bool>> filter = null, string includeProperties = null) 
				where TEntity : class
			{
				return GetQueryable<TEntity>(filter, null, includeProperties).SingleOrDefault();
			}

			public virtual async Task<TEntity> GetOneAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null, string includeProperties = null) 
				where TEntity : class
			{
				return await GetQueryable<TEntity>(filter, null, includeProperties).SingleOrDefaultAsync();
			}

			public virtual TEntity GetFirst<TEntity>(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null) 
				where TEntity : class
			{
				return GetQueryable<TEntity>(filter, orderBy, includeProperties).FirstOrDefault();
			}

			public virtual async Task<TEntity> GetFirstAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null) 
				where TEntity : class
			{
				return await GetQueryable<TEntity>(filter, orderBy, includeProperties).FirstOrDefaultAsync();
			}

			public virtual TEntity GetById<TEntity>(object id) 
				where TEntity : class
			{
				return _context.Set<TEntity>().Find(id);
			}

			public async Task<TEntity> GetByIdAsync<TEntity>(object id) 
				where TEntity : class
			{
				return await _context.Set<TEntity>().FindAsync(id);
			}

			public int GetCount<TEntity>(Expression<Func<TEntity, bool>> filter = null)
				where TEntity : class
			{
				return GetQueryable<TEntity>(filter).Count();
			}

			public async Task<int> GetCountAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null)
				where TEntity : class
			{
				return await GetQueryable<TEntity>(filter).CountAsync();
			}

			public bool GetExists<TEntity>(Expression<Func<TEntity, bool>> filter = null) 
				where TEntity : class
			{
				return GetQueryable<TEntity>(filter).Any();
			}

			public async Task<bool> GetExistsAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null) 
			where TEntity : class
			{
				return await GetQueryable<TEntity>(filter).AnyAsync();
			}

			protected virtual IQueryable<TEntity> GetQueryable<TEntity>(
				Expression<Func<TEntity, bool>> filter = null,
				Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
				string includeProperties = null, int? skip = null, int? take = null) 
			where TEntity : class
			{
				includeProperties = includeProperties ?? string.Empty;
				IQueryable<TEntity> query = _context.Set<TEntity>();

				if (filter != null)
				{
					query = query.Where(filter);
				}

				foreach (var includeProperty in includeProperties.Split
					(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
				{
					query = query.Include(includeProperty);
				}

				if (orderBy != null)
				{
					query = orderBy(query);
				}

				if (skip.HasValue)
				{
					query = query.Skip(skip.Value);
				}

				if (take.HasValue)
				{
					query = query.Take(take.Value);
				}

				return query;
			}

		#endregion -- Methods --;
	}
}