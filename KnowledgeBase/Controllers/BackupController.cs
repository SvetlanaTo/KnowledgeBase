using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using KnowledgeBase.Backup.Classes;
using KnowledgeBase.Backup.Interface;
using KnowledgeBase.Data;
using KnowledgeBase.Models;
using KnowledgeBase.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using NLog;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;


namespace KnowledgeBase.Controllers
{
    public class BackupController : Controller//: KbVaultAdminController
    {
        public readonly IWebHostEnvironment _env;

        private static Logger Log = LogManager.GetCurrentClassLogger();

        private readonly KnowledgeBaseContext _context;

        public BackupController(IWebHostEnvironment env, KnowledgeBaseContext context)
        {
            _env = env;
            _context = context;
        }

        //Settings = db.Settings.FirstOrDefault(s => true);

        public IActionResult Index()
        {
            var foundSettings = _context.Settings.FirstOrDefault(s => true);
            var backupDirectory = string.Empty;
            if (!string.IsNullOrEmpty(foundSettings.BackupPath) && foundSettings.BackupPath.StartsWith("~"))
            {
                var webroot = _env.WebRootPath;
                backupDirectory = System.IO.Path.Combine(webroot, foundSettings.BackupPath);
                //backupDirectory = Server.MapPath(Settings.BackupPath);
            }
            else
            {
                backupDirectory = foundSettings.BackupPath;
            }

            var model = new List<BackupListViewModel>();
            var i = 0;
            if (!string.IsNullOrEmpty(backupDirectory))
            {
                foreach (var filePath in Directory.GetFiles(backupDirectory, "*.bak"))
                {
                    var fo = new FileInfo(filePath);
                    model.Add(new BackupListViewModel
                    {
                        Id = i,
                        FileName = Path.GetFileName(filePath),
                        FileDate = fo.CreationTime
                    });
                    i++;
                }
            }

            return View(model.OrderByDescending(f => f.FileDate));
        }

        [HttpPost]
        public JsonResult Restore(string file)
        {
            try
            {
                var foundSettings = _context.Settings.FirstOrDefault(s => true);
                var result = new JsonOperationResponse();
                try
                {
                    var backupFile = string.Empty;
                    if (foundSettings.BackupPath.StartsWith("~"))
                    {
                        var webroot = _env.WebRootPath;
                        backupFile = System.IO.Path.Combine(webroot, foundSettings.BackupPath + file);
                        //backupFile = Server.MapPath(Settings.BackupPath + file);
                    }
                    else
                    {
                        backupFile = foundSettings.BackupPath + file;
                    }

                    if (System.IO.File.Exists(backupFile))
                    {
                        var connectionString = ConfigurationManager.ConnectionStrings["KnowledgeBaseContextBackup"].ConnectionString;
                        //https://docs.microsoft.com/en-us/dotnet/api/system.data.entity.core.entityclient?view=entity-framework-6.2.0
                        var entityConnectionString = ConfigurationManager.ConnectionStrings["KnowledgeBaseContextBackup"].ConnectionString;
                        var builder = new System.Data.SqlClient.SqlConnectionStringBuilder(entityConnectionString);

                        //var entityConnectionString = new EntityConnectionStringBuilder(connectionString);                        
                        //var entityConnectionString = new System.Data.Entity.Core.EntityClient.EntityConnectionStringBuilder(connectionString); 
                        //var builder = new System.Data.SqlClient.SqlConnectionStringBuilder(entityConnectionString.ProviderConnectionString);  
                        

                        //var builder = new System.Data.Common.DbConnectionStringBuilder.SqlConnectionStringBuilder(entityConnectionString.ProviderConnectionString);
                        //System.Data.Entity.Core.EntityClient.
                        //System.Data.Common.DbConnectionStringBuilder.

                        IVaultBackup backup = new VaultMsSqlBackup();
                        //backup.Connect(entityConnectionString.ProviderConnectionString);
                        backup.Connect(entityConnectionString);

                        result.Successful = backup.Restore(builder.InitialCatalog, backupFile);
                        if (result.Successful)
                        {
                            result.ErrorMessage = "BackupRestoreSuccessfull"; // Resources.UIResources.BackupRestoreSuccessfull;
                        }
                    }
                    else
                    {
                        throw new FileNotFoundException(file);
                    }
                }
                catch (Exception ex)
                {
                    Log.Error(ex);
                    result.ErrorMessage = ex.Message;
                }

                return Json(result);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }

        [HttpPost]
        public JsonResult BackupNow()
        {
            try
            {
                var foundSettings = _context.Settings.FirstOrDefault(s => true);
                var result = new JsonOperationResponse();
                if (string.IsNullOrEmpty(foundSettings.BackupPath))
                {
                    result.Successful = false;
                    //result.ErrorMessage = Resources.ErrorMessages.BackupPathIsNotSet;
                    result.ErrorMessage = "BackupPathIsNotSet";
                }
                else
                {
                    //var connectionString = ConfigurationManager.ConnectionStrings["KbVaultContext"].ConnectionString;
                    var connectionString = ConfigurationManager.ConnectionStrings["KnowledgeBaseContextBackup"].ConnectionString;
                    var builder = new System.Data.SqlClient.SqlConnectionStringBuilder(connectionString);
                    IVaultBackup backup = new VaultMsSqlBackup();
                    backup.Connect(connectionString);
                    var backupFile = string.Format("{0:yyyyMddhhmm}.bak", DateTime.Now);
                    if (!string.IsNullOrEmpty(foundSettings.BackupPath) && foundSettings.BackupPath.StartsWith("~"))
                    {
                        //backupFile = Server.MapPath(Settings.BackupPath + backupFile);
                        var contentroot = _env.ContentRootPath;
                        backupFile = System.IO.Path.Combine(contentroot, foundSettings.BackupPath + backupFile);
                    }
                    else
                    {
                        backupFile = foundSettings.BackupPath + backupFile;
                    }

                    var backupSuccessful = backup.Backup(builder.InitialCatalog, backupFile);
                    if (backupSuccessful)
                    {
                        if (!string.IsNullOrEmpty(backupFile))
                        {
                            result.Data = backupFile;
                            result.Successful = true;
                        }
                    }
                }

                return Json(result);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }
    }
}
