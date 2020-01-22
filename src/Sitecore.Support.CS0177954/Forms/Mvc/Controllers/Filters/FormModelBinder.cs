using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;
using Sitecore.Diagnostics;
using Sitecore.Forms.Mvc.Controllers.ModelBinders;
using Sitecore.Forms.Mvc.Data.Wrappers;
using Sitecore.Forms.Mvc.Models;
using Sitecore.Forms.Mvc.ViewModels;

namespace Sitecore.Support.Forms.Mvc.Controllers.Filters
{
    public class FormModelBinder : Sitecore.Forms.Mvc.Controllers.ModelBinders.FormModelBinder
    {
        public FormModelBinder()
        {
        }

        public FormModelBinder(IRenderingContext renderingContext)
            : base(renderingContext)
        {
        }

        public override FormViewModel GetFormViewModel(ControllerContext controllerContext)
        {
            Assert.ArgumentNotNull(controllerContext, "controllerContext");
            if (this.RenderingContext != null && this.RenderingContext.Rendering != null)
            {
                Guid uniqueId = this.RenderingContext.Rendering.UniqueId;
                if (controllerContext.HttpContext.Session != null && controllerContext.HttpContext.Session.Mode == SessionStateMode.InProc)
                {
                    FormViewModel formViewModel = controllerContext.HttpContext.Session[uniqueId.ToString()] as FormViewModel;
                    if (formViewModel != null)
                    {
                        formViewModel.SuccessSubmit = false;
                        return formViewModel;
                    }
                }
                FormController formController = controllerContext.Controller as FormController;
                if (formController != null)
                {
                    FormModel model = formController.FormRepository.GetModel(uniqueId);
                    if (model != null)
                    {
                        return formController.Mapper.GetView(model);
                    }
                }
                return null;
            }
            return null;
        }
    }
}