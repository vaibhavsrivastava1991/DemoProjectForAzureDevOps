using DAL.DbContextSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace BAL.Repositories
{
	public class AzureDevOpsRepository<T> : IAzureDevOpsMVCRespository<T> where T : class
	{
		protected readonly MVCApplicationDbContext dbContext;
		public AzureDevOpsRepository(MVCApplicationDbContext _dbContext)
		{
			this.dbContext = _dbContext;
		}
		/// <summary>
		/// Add Entity In Database
		/// </summary>
		/// <param name="add"></param>
		public void Add(T add)
		{
			dbContext.Entry(add).State = System.Data.Entity.EntityState.Added;
		}
		/// <summary>
		/// Add Entities In Database
		/// </summary>
		/// <param name="add"></param>
		public void AddRange(IEnumerable<T> entity)
		{
			dbContext.Set<T>().AddRange(entity);
		}
		/// <summary>
		/// Find Entity From Database
		/// </summary>
		/// <param name="predicate"></param>
		/// <returns></returns>
		public T Find(Expression<Func<T, bool>> predicate)
		{
			return dbContext.Set<T>().Find(predicate);
		}
		/// <summary>
		/// Get Entity From Database
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public T Get(int id)
		{
			return dbContext.Set<T>().Find(id);
		}
		/// <summary>
		/// Get All Entity From Database
		/// </summary>
		/// <returns></returns>
		public IEnumerable<T> GetAll()
		{
			return dbContext.Set<T>().ToList();
		}
		/// <summary>
		/// Remove Entity From Database
		/// </summary>
		/// <param name="removeEntity"></param>
		public void Remove(T removeEntity)
		{
			dbContext.Set<T>().Remove(removeEntity);
		}
		/// <summary>
		/// Remove Entities From Database
		/// </summary>
		/// <param name="entities"></param>
		public void RemoveRange(IEnumerable<T> entities)
		{
			dbContext.Set<T>().RemoveRange(entities);
		}

		public void Update(T entity)
		{
			dbContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;
		}
	}
}