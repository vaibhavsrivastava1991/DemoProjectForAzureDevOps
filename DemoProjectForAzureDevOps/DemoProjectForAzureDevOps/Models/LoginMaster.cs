using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoProjectForAzureDevOps.Models
{
	/// <summary>
	/// Login Master Model Class
	/// </summary>
	public class LoginMaster
	{
		public Guid LoginMasterId { get; set; }

		[Required]
		public string UserName { get; set; }
		[Required]
		[StringLength(30, ErrorMessage = "Minimum Char 6 And Maximum 30 Required")]
		public string Password { get; set; }
	}
}