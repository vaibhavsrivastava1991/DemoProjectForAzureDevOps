using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoProjectForAzureDevOps.Models
{
	/// <summary>
	/// User Profile Model Class
	/// </summary>
	public class UserProfileMaster
	{
		public Guid UserProfileId { get; set; }
		public string FirstName { get; set; }
		public string MiddleName { get; set; }
		public string LastName { get; set; }
		public string PrimaryEmail { get; set; }
		public string RecoveryEmail { get; set; }
		public string MobileNumber { get; set; }
		public Guid LoginUserId { get; set; }
	}
}