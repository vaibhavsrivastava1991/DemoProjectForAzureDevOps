using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BAL.Repositories
{
	public interface IAzureDevOpsMVCRespository<T> where T : class
	{
		/// <summary>
		/// Add Entity In Database
		/// </summary>
		void Add(T add);
		/// <summary>
		/// Add Range Of Entities In Database
		/// </summary>
		void AddRange(IEnumerable<T> entity);
		/// <summary>
		/// Remove Entity From Database
		/// </summary>
		void Remove(T remove);
		/// <summary>
		/// Remove Range of Entities From Database
		/// </summary>
		void RemoveRange(IEnumerable<T> entities);
		/// <summary>
		/// Get All Record From Database
		/// </summary>
		IEnumerable<T> GetAll();
		/// <summary>
		/// Get specific Record From Database
		/// </summary>
		T Get(int id);
		/// <summary>
		/// Find specific Record From Database
		/// </summary>
		T Find(System.Linq.Expressions.Expression<Func<T, bool>> predicate);
		/// <summary>
		/// Update Record
		/// </summary>
		/// <param name="entity"></param>
		void Update(T entity);
	}
}