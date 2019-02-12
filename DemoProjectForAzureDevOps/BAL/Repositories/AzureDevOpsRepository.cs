using DAL.DbContextSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace DemoProjectForAzureDevOps.Repositories
{
	public class AzureDevOpsRepository<T> : IAzureDevOpsMVCRespository<T> where T : class
	{
		protected readonly MVCApplicationForAzureEntities dbContext;
		public void Add(T add)
		{
			throw new NotImplementedException();
		}

		public void AddRange(IEnumerable<T> entity)
		{
			throw new NotImplementedException();
		}

		public void Find(Expression<Func<T, bool>> predicate)
		{
			throw new NotImplementedException();
		}

		public T Get(int id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<T> GetAll()
		{
			throw new NotImplementedException();
		}

		public void Remove(T remove)
		{
			throw new NotImplementedException();
		}

		public void RemoveRange(IEnumerable<T> entities)
		{
			throw new NotImplementedException();
		}
	}
}