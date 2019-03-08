using DAL.DbContextSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace BAL.Repositories
{
	public class SignupRepository : AzureDevOpsRepository<UserProfileMaster>, ISignupRepository
	{
		public SignupRepository(MVCApplicationDbContext _dbContext) : base(_dbContext)
		{

		}
		public bool ValidateEmail(string email)
		{
			return dbContext.UserProfileMasters.Any(pro => pro.PrimaryEmail == email);
		}
	}
}
