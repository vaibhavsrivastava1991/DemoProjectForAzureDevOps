using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DemoProjectForAzureDevOps.Filter
{
	public class CustomException : FilterAttribute, IExceptionFilter
	{
		public void OnException(ExceptionContext filterContext)
		{
			//Check Type Of Exception
			if (filterContext.Exception is NotFiniteNumberException)
			{

			}

			// Set Exception On Exception Case
			filterContext.Result = new ViewResult()
			{
				ViewName = "Error"
			};
			filterContext.ExceptionHandled = true;
		}
	}
}