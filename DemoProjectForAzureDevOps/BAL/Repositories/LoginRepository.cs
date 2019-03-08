using DAL.DbContextSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
namespace BAL.Repositories
{
	/// <summary>
	/// Login Repository 
	/// </summary>
	public class LoginRepository : AzureDevOpsRepository<LoginMaster>, ILoginRepository
	{
		public LoginRepository(MVCApplicationDbContext dbContext) : base(dbContext)
		{

		}

		/// <summary>
		/// Encrypt User Password
		/// </summary>
		/// <param name="password"></param>
		/// <returns></returns>
		public BAL.Models.UserProfileMaster LoginUser(string userName, string password)
		{
			var loggedInUserData = dbContext.LoginMasters.FirstOrDefault(user => user.UserName == userName && user.LoginPassword == password);
			if (loggedInUserData != null && loggedInUserData.UserProfileId != null)
			{
				var loginData = dbContext.UserProfileMasters.FirstOrDefault(user => user.UserProfileId == loggedInUserData.UserProfileId);
				BAL.Models.UserProfileMaster userProfile = new Models.UserProfileMaster();
				userProfile.FirstName = loginData.FirstName;
				userProfile.MiddleName = loginData.MiddleName;
				userProfile.LastName = loginData.LastName;
				userProfile.MobileNumber = loginData.MobileNumber;
				userProfile.PrimaryEmail = loginData.PrimaryEmail;
				userProfile.RecoveryEmail = loginData.RecoveryEmail;
				userProfile.UserProfileId = loginData.UserProfileId;
				return userProfile;
				//var userInformation = dbContext.UserProfileMasters.Where(S => S.LoginUserId == loginData.LoginMasterId).FirstOrDefault();
			}
			return null;
		}

		/// <summary>
		/// Validate User Name Should Not Allow Duplicate UserName
		/// </summary>
		/// <param name="userName"></param>
		/// <returns></returns>
		public bool ValidateUserName(string userName)
		{
			return dbContext.LoginMasters.Any(user => user.UserName == userName);
		}
	}
}
