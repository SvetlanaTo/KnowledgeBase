using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KnowledgeBase.Data;
using KnowledgeBase.Models;
using KnowledgeBase.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using NLog;

namespace KnowledgeBase.Controllers
{
    //[Authorize]
    public class ActivityController : Controller//: KbVaultAdminController
    {       
        private readonly KnowledgeBaseContext _context;
        private static Logger log = LogManager.GetCurrentClassLogger();
        public ActivityController(KnowledgeBaseContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Admin,Manager")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin,Manager")]
        [HttpPost]
        public JsonResult Get(ActivityDataTablesPostModel model)
        {
            try
            {
                var length = model.length;
                var page = model.start / length;
                var result = new JsonOperationResponse();
                //using (var db = new KbVaultContext(_config))
                //{
                    var recordCount = _context.Activities.Count();
                //0408
                //https://stackoverflow.com/questions/55234943/what-is-the-equivalent-of-configuration-proxycreationenabled-in-ef-core
                //*****By default, EF Core won't use lazy load with proxy!!!
                //db.Configuration.LazyLoadingEnabled = false;

                //[AspNetUsers]
                //var activities = _context.Activities.Include("KbUser")
                    var activities = _context.Activities.Include("AspNetUsers")
                                    .OrderByDescending(a => a.ActivityDate)
                                    .Skip(page * length)
                                    .Take(length).AsEnumerable()
                                    .Select(a => new ActivityViewModel
                                    {
                                        ActivityDate = a.ActivityDate.ToString("dd/MM/yyyy H:mm"),
                                        Operation = a.Operation,
                                        Text = a.Information,
                                        User = a.Author.UserName
                                        //todo: first + lastname
                                        //User = a.User.Name + " " + a.KbUser.LastName
                                    }).ToList();
                    result.Successful = true;
                    result.Data = activities;
                    return Json(new { recordsFiltered = recordCount, recordsTotal = recordCount, Successfull = result.Successful, ErrorMessage = result.ErrorMessage, data = ((List<ActivityViewModel>)result.Data).Select(aw => new[] { aw.ActivityDate, aw.Operation, aw.Text, aw.User }) });
                //}
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw;
            }
        }

    }
}
