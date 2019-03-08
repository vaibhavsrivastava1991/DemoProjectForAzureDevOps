using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BAL.Models
{
	/// <summary>
	/// User Profile Model Class
	/// </summary>
	public class UserProfileMaster
	{
		public Guid UserProfileId { get; set; }
		[Required]
		public string FirstName { get; set; }
		public string MiddleName { get; set; }
		[Required]
		public string LastName { get; set; }
		[Required]
		public string PrimaryEmail { get; set; }
		[Required]
		public string UserName { get; set; }
		public string RecoveryEmail { get; set; }
		[Required]
		public string MobileNumber { get; set; }
		public Guid LoginUserId { get; set; }
	}
}