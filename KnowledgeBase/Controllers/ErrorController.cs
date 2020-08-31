using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace KnowledgeBase.Controllers
{
    public class ErrorController : Controller
    {
        private const string ExceptionObjectKey = "TEMPDATA_EXCEPTION_KEY";
        public IActionResult Index()
        {
            ViewBag.ErrorMessage = "...";
            var ex = GetGlobalException();
            if (ex != null)
            {
                ViewBag.ErrorMessage = ex.Message;
            }

            return View();
        }

        public IActionResult PublicError()
        {
            return View();
        }

        protected Exception GetGlobalException()
        {
            return TempData[ExceptionObjectKey] as Exception;
        }
    }
}
