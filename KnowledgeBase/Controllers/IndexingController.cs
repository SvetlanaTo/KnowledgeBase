using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace KnowledgeBase.Controllers
{
    public class IndexingController : Controller
    {
        //[Authorize(Roles = "Admin,Manager")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
