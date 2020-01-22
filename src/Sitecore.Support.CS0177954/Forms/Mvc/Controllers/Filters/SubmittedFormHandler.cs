using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore.Diagnostics;
using Sitecore.Forms.Mvc.Interfaces;

namespace Sitecore.Support.Forms.Mvc.Controllers.Filters
{
    public class SubmittedFormHandler : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Assert.ArgumentNotNull(filterContext, "filterContext");
            FormController formController = filterContext.Controller as FormController;
            if (formController != null && !(filterContext.ActionParameters.Values.First() is IViewModel))
            {
                filterContext.Result = formController.Form();
            }
        }
    }
}