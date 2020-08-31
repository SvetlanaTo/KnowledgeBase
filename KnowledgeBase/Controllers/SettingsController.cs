using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using KnowledgeBase.Business.ApplicationSettings;
using KnowledgeBase.DAL.Repo;
using KnowledgeBase.Models;
using KnowledgeBase.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using NLog;

namespace KnowledgeBase.Controllers
{
    //[Authorize]
    public class SettingsController : Controller 
    {
        

        private const string ExceptionObjectKey = "TEMPDATA_EXCEPTION_KEY";
        private const string OperationMessageKey = "KBVAULT_OPERATION_MSG_KEY";
        private const string ErrorMessageKey = "KBVAULT_ERROR_MSG_KEY";

        private static Logger Log = LogManager.GetCurrentClassLogger();

        public IWebHostEnvironment _env;
        public ISettingsFactory _settingsFactory { get; set; }
        public ISettingsService _settingsService { get; set; }
        public ISettingsRepository _settingsRepository { get; set; }

        public SettingsController(IWebHostEnvironment env, ISettingsFactory settingsFactory, ISettingsService settingsService, ISettingsRepository settingsRepository)
        {
            _env = env;
            _settingsFactory = settingsFactory;
            _settingsService = settingsService;
            _settingsRepository = settingsRepository;
        }


        [HttpPost]
        public IActionResult Index(SettingsViewModel model)
        {
            //var webRoot = _env.WebRootPath; //wwwroot
            var webRoot = _env.ContentRootPath; //apsolutna


            try
            {
                if (ModelState.IsValid)
                {
                    var set = _settingsFactory.CreateModel(model);
                    if (set != null)
                    {
                        _settingsRepository.Save(set);
                        ConfigurationManager.AppSettings["Theme"] = model.SelectedTheme;
                        _settingsService.ReloadSettings();
                        //ShowOperationMessage(Resources.UIResources.SettingsPageSaveSuccessfull);
                        ShowOperationMessage("SettingsPageSaveSuccessfull");

                    }
                }
                //model.Themes.AddRange(Directory.EnumerateDirectories(Path.Combine(webRoot, "~/Views/Themes")).Select(e => Path.GetFileName(e)).ToList());
                model.Themes.AddRange(Directory.EnumerateDirectories(Path.Combine(webRoot, "Views\\Themes")).Select(e => Path.GetFileName(e)).ToList());

                return View(model);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                ShowErrorMessage(ex.Message);
                return RedirectToAction("Index", "Error");
            }
        }

        public IActionResult Index()
        {
            ViewBag.UpdateSuccessfull = false;
            var model = _settingsFactory.CreateViewModel(_settingsService.GetSettings());
            return View(model);
        }

        protected void ShowErrorMessage(string msg)
        {
            //ControllerContext.HttpContext.Session[ErrorMessageKey] += msg;
            var session1 = ControllerContext.HttpContext.Session.GetString("ErrorMessageKey");
            session1 += msg;
        }

        protected void ShowOperationMessage(string msg)
        {
            //ControllerContext.HttpContext.Session[OperationMessageKey] += msg;
            var session1 = ControllerContext.HttpContext.Session.GetString("OperationMessageKey");
            session1 += msg;
        }

      

    }
}
