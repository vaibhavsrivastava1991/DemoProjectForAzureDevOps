using DAL.DbContextSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Repositories
{
	public interface ILoginRepository : IAzureDevOpsMVCRespository<LoginMaster>
	{
		/// <summary>
		/// Validate User Name
		/// </summary>
		/// <param name="userName"></param>
		/// <returns></returns>
		bool ValidateUserName(string userName);
		/// <summary>
		/// Allow Login For User
		/// </summary>
		/// <param name="userName"></param>
		/// <param name="password"></param>
		/// <returns></returns>
		BAL.Models.UserProfileMaster LoginUser(string userName, string password);
	}
}
