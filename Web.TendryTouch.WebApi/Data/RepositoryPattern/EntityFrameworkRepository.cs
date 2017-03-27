using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Web.TendryTouch.Models;

namespace Web.TendryTouch.WebApi.Models.RepositoryPattern
{
	public class EntityFrameworkRepository<TContext>: EntityFrameworkReadOnlyRepository<TContext>, 
		IRepository where TContext :DbContext
	{

		#region -- Private member variables --
		#endregion -- Private member variables --;


		#region -- Constructors, destructors, and finalizers --

			public EntityFrameworkRepository(TContext context) : base(context) { }

		#endregion -- Constructors, destructors, and finalizers --;


		#region -- Properties --
		#endregion -- Properties --;


		#region -- Methods --

			public void Create<TEntity>(TEntity entity, string createdBy = null) where TEntity : IEntity
			{
				entity.CreatedDate = DateTime.UtcNow;
				entity.CreatedBy = createdBy;
				_context.Set<TEntity>().Add(entity);
			}

			public void Update<TEntity>(TEntity entity, string modifiedBy = null) where TEntity : IEntity
			{
				entity.ModifiedDate = DateTime.UtcNow;
				entity.ModifiedBy = modifiedBy;
				_context.Set<TEntity>().Attach(entity);
				_context.Entry(entity).State = EntityState.Modified;
			}

			public void Delete<TEntity>(object id) where TEntity : IEntity
			{
				TEntity entity = _context.Set<TEntity>().Find(id);
				Delete(entity);
			}

			public void Delete<TEntity>(TEntity entity) where TEntity : IEntity
			{
				var dbSet = _context.Set<TEntity>();
				if (_context.Entry(entity).State == EntityState.Detached)
				{
					dbSet.Attach(entity);
				}
				dbSet.Remove(entity);
			}

			public void Save()
			{
				try
				{
					_context.SaveChanges();
				}
				catch (DbEntityValidationException e)
				{
					ThrowEnhancedValidationException(e);
				}
			}

			public async Task<int> SaveAsync()
			{
				try
				{
					return await _context.SaveChangesAsync();
				}
				catch (DbEntityValidationException e)
				{
					ThrowEnhancedValidationException(e);
				}

				return await Task.FromResult(0);
			}

			protected virtual void ThrowEnhancedValidationException(DbEntityValidationException e)
			{
				var errorMessages = e.EntityValidationErrors
						.SelectMany(x => x.ValidationErrors)
						.Select(x => x.ErrorMessage);

				var fullErrorMessage = string.Join("; ", errorMessages);
				var exceptionMessage = string.Concat(e.Message, " The validation errors are: ", fullErrorMessage);
				throw new DbEntityValidationException(exceptionMessage, e.EntityValidationErrors);
			}

		#endregion -- Methods --;
	}
}