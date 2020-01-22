using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Sitecore.Pipelines;

namespace Sitecore.Support.Forms.Mvc.Pipelines.Initialize
{
    public class InitializeRoutes : Sitecore.Mvc.Pipelines.Loader.InitializeRoutes
    {
        protected override void RegisterRoutes(RouteCollection routes, PipelineArgs args)
        {
            if (routes.Remove(RouteTable.Routes[Sitecore.Forms.Mvc.Constants.Routes.Form]))
            {
                routes.MapRoute(
                    Sitecore.Forms.Mvc.Constants.Routes.Form,
                    "form/{action}",
                    new {controller = "Form", action = "Process"},
                    new[] {"Sitecore.Support.Forms.Mvc.Controllers"});
            }
        }
    }
}