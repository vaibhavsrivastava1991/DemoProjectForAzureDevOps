using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Repositories
{
	public interface IUnitOfWork : IDisposable
	{
		/// <summary>
		/// Login Repository Property
		/// </summary>
		ILoginRepository LoginRepository { get;}
		/// <summary>
		/// Signup Repository Property
		/// </summary>
		ISignupRepository SignupRepository { get; }
		int Complete();
	}
}
