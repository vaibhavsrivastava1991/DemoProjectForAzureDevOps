﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;


namespace DemoProjectForAzureDevOps
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
	
			RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
		/// <summary>
		/// Run If Any Error Occured In Application
		/// </summary>
		protected void Application_Error()
		{
		
			HttpContext context = HttpContext.Current;
			if (context != null)
			{
				//Returing If Any Exception Coming....
				context.Response.Redirect("ErrorHandler/Index");
			}
		}
    }
}
