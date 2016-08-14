using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebDeveloper.Filters
{
    public class ExceptionControl : ActionFilterAttribute, IExceptionFilter
    {
        private static ILog Log{get;set;}

        ILog log = LogManager.GetLogger
            (//centralizar una unica vez , mediante reflexion
            System.Reflection.MethodBase.GetCurrentMethod().DeclaringType
            );
        public void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true; //controla el pantallazo amarillo de error
            log.Error(filterContext.Exception);
            //obtiene el nombre del controlador y de la acction
            var controller = filterContext.RouteData.Values["controller"].ToString();
            var action = filterContext.RouteData.Values["action"].ToString();
            //HandleErrorInfo
            var model = new HandleErrorInfo(filterContext.Exception, controller, action);

            //reedireccionar a otra vista cuando hay  un error
            filterContext.Result = new ViewResult
            {
                ViewName="~/Views/Shared/Error.cshtml",
                ViewData=new ViewDataDictionary<HandleErrorInfo>(model),
                TempData=filterContext.Controller.TempData

            };



        }
    }
}