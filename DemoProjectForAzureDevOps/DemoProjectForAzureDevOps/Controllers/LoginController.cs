using DemoProjectForAzureDevOps.Filter;
using DemoProjectForAzureDevOps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoProjectForAzureDevOps.Controllers
{
	//[CustomException]
	public class LoginController : Controller
	{
		public ActionResult LoginView()
		{
			return View();
		}
		[HttpPost]
		public ActionResult LoginView(LoginMaster loginMaster)
		{
			return View();
		}
	}
}