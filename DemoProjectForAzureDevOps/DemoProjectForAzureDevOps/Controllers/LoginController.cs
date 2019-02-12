using DemoProjectForAzureDevOps.Filter;
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
			throw new Exception("Something Went Wrong");
        }
    }
}