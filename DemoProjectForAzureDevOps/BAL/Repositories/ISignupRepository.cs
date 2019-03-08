using DAL.DbContextSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace BAL.Repositories
{
	public interface ISignupRepository : IAzureDevOpsMVCRespository<UserProfileMaster>
	{
		bool ValidateEmail(string email);
	}
}
