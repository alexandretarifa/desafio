using DesafioGuitarras.Models;
using DomainValidation.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace DesafioGuitarras.Controllers
{
    public abstract class MvcController : Controller
    {
        public List<NotificationModel> Notifications;

        public MvcController()
        {
            this.Notifications = new List<NotificationModel>();
        }

        protected override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            if (this.Notifications.Count > 0) filterContext.Controller.ViewData.Add("Notification", this.Notifications);
            base.OnResultExecuting(filterContext);
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            this.Notifications.RemoveAll(x => !x.Show);
            base.OnActionExecuting(filterContext);
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            if (filterContext == null)
                return;

            //Elmah.ErrorSignal.FromCurrentContext().Raise(filterContext.Exception);
            var exception = (filterContext.Exception != null) ? filterContext.Exception : new Exception("No details"));
            AddNotification(exception);
            filterContext.ExceptionHandled = true;

            if (!filterContext.Controller.ViewData.ContainsKey("Notification"))
                filterContext.Controller.ViewData.Add("Notification", this.Notifications);

            if (System.Web.HttpContext.Current.Request.HttpMethod == "POST")
                filterContext.Result = View("Index");
            else
                filterContext.Result = PartialView("_Notification");
        }

        protected void AddNotification(string message, NotificationModel.Types type = NotificationModel.Types.DANGER)
        {
            this.Notifications.Add(new NotificationModel(message, type));
        }

        protected void AddNotification(ValidationResult validation)
        {
            foreach (var error in validation.Erros)
                this.AddNotification(error.Message);
        }

        protected void AddNotification(ModelStateDictionary modelState)
        {
            foreach (var state in modelState.Where(x => x.Value.Errors.Count > 0))
                state.Value.Errors.ToList().ForEach(x => this.AddNotification(x.ErrorMessage));
        }

        protected void AddNotification(Exception exception)
        {
            //Elmah.ErrorSignal.FromCurrentContext().Raise(exception);
            AddNotification($"Exception thrown, type of {exception.GetType()}, please contact support");
        }
    }
}