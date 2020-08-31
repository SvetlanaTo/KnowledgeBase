using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using KnowledgeBase.Data;
using KnowledgeBase.Helpers;
using KnowledgeBase.Models;
using KnowledgeBase.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Configuration;
using NLog;

namespace KnowledgeBase.Controllers
{
    [Authorize]
    public class FileController : Controller
    {
        //private readonly IActionContextAccessor _actionContextAccessor;

        private readonly IWebHostEnvironment _env;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private KnowledgeBaseContext _context;
        private Logger log = LogManager.GetCurrentClassLogger();
        private static KbVaultLuceneHelper _lucene;

        public FileController(IWebHostEnvironment env, IHttpContextAccessor httpContextAccessor, KnowledgeBaseContext context, KbVaultLuceneHelper lucene)
        {
            _env = env;
            _httpContextAccessor = httpContextAccessor;
            _context = context;
            _lucene = lucene;
        }




        //public void RemoveAttachment(string hash, long currentUserId, IWebHostEnvironment env)
        public void RemoveAttachment(string hash, string currentUserId, IWebHostEnvironment env)
        {
            //var webroot = _env.WebRootPath;
            try
            {
                //using (var db = new KnowledgeBaseContext())
                //{
                //var attachment = db.Attachments.First(a => a.Hash == hash);
                var attachment = _context.Attachments.First(a => a.Hash == hash);
                if (attachment == null)
                {
                    //throw new ArgumentNullException(Resources.ErrorMessages.AttachmentNotFound);
                    throw new ArgumentNullException("AttachmentNotFound");
                }

                var localPath = Path.Combine(env.WebRootPath, (attachment.Path), attachment.FileName);
                attachment.AuthorId = currentUserId;
                _context.Attachments.Remove(attachment);
                _context.SaveChanges();
                System.IO.File.Delete(localPath); 
                //}
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw;
            }
        }

        public Attachment SaveAttachment(long articleId, IFormFile attachedFile, string userId, IWebHostEnvironment env)
        {
            //var webroot = _env.WebRootPath;
            try
            {
                //using (var db = new KnowledgeBaseContext())
                //{
                //0408
                //https://stackoverflow.com/questions/55234943/what-is-the-equivalent-of-configuration-proxycreationenabled-in-ef-core
                //*****By default, EF Core won't use lazy load with proxy!!!
                //db.Configuration.ProxyCreationEnabled = false;
                //db.Configuration.LazyLoadingEnabled = false;
                //var article = db.Articles.First(a => a.Id == articleId);
                var article = _context.Articles.First(a => a.Id == articleId);
                if (article != null)
                {
                    var attachment = new Attachment();
                    //var localPath = HttpContext.Current.Server.MapPath("~/Uploads");
                    var localPath = Path.Combine(env.WebRootPath, "/Uploads");
                    attachment.Path = "~/Uploads/";
                    attachment.FileName = Path.GetFileName(attachedFile.FileName);
                    attachment.Extension = Path.GetExtension(attachedFile.FileName);
                    attachment.ArticleId = articleId;
                    attachment.MimeType = attachedFile.ContentType;
                    attachment.Hash = Guid.NewGuid().ToString().Replace("-", string.Empty);
                    attachment.AuthorId = userId;
                    _context.Attachments.Add(attachment);
                    article.Attachments.Add(attachment);

                    var path = Path.Combine(localPath, attachment.FileName);
                    while (System.IO.File.Exists(path))
                    {
                        attachment.FileName = Path.GetFileNameWithoutExtension(attachment.FileName) +
                                               Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(1, 5) +
                                               Path.GetExtension(attachment.FileName);
                        path = Path.Combine(localPath, attachment.FileName);
                    }

                    attachedFile.SaveAs(path);
                    _context.SaveChanges();
                    return attachment;
                }

                //throw new ArgumentNullException(Resources.ErrorMessages.FileUploadArticleNotFound);
                throw new ArgumentNullException("FileUploadArticleNotFound");
                //}
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw;
            }
        }

        [HttpPost]
        public JsonResult Remove(string id)
        {
            var result = new JsonOperationResponse
            {
                Successful = false
            };

            try
            {
                var parts = id.Split(new[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length == 2)
                {
                    var attachmentHash = parts[0];
                    var attachmentId = parts[1];

                    var at = new Attachment
                    {
                        Id = Convert.ToInt64(attachmentId),
                        //AuthorId = KBVaultHelperFunctions.UserAsKbUser(User).Id
                        AuthorId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)
                };

                RemoveAttachment(attachmentHash, _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier), _env);

                    _lucene.RemoveAttachmentFromIndex(at);
                    result.Successful = true;
                    return Json(result);
                }

                throw new ArgumentOutOfRangeException("Invalid file hash");
            }
            catch (Exception ex)
            {
                log.Error(ex);
                result.ErrorMessage = ex.Message;
                return Json(result);
            }
        }

        [HttpPost]
        public JsonResult Upload()
        {

            var result = new JsonOperationResponse
            {
                Successful = false
            };
            try
            {
                if (Request.Query["ArticleId"] == "")
                {
                    //result.ErrorMessage = Resources.ErrorMessages.FileUploadArticleNotFound;
                    result.ErrorMessage = "FileUploadArticleNotFound";
                }
                else if (Request.Form.Files.Count == 1)
                {

                    var articleId = Convert.ToInt64(HttpContext.Request.Query["ArticleId"]);
                    var attachedFile = Request.Form.Files[0];
                    //var attachment = KbVaultAttachmentHelper.SaveAttachment(articleId, attachedFile, KBVaultHelperFunctions.UserAsKbUser(User).Id, _env);
                    //attachment.Author = KBVaultHelperFunctions.UserAsKbUser(User).Id;

                    var attachment = SaveAttachment(articleId, attachedFile, _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier), _env);
                    attachment.AuthorId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                    result.Successful = true;
                    //result.Data = new AttachmentViewModel(attachment, _actionContextAccessor); 
                    result.Data = new AttachmentViewModel(attachment, _httpContextAccessor);
                    
                    //using (var db = new KbVaultContext(_config))
                    //{
                        var sets = _context.Settings.FirstOrDefault();
                        if (sets != null)
                        {
                            var extensions = sets.IndexFileExtensions.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

                            if (extensions.FirstOrDefault(a => a.ToLowerInvariant() == attachment.Extension.ToLowerInvariant()) != null)
                            {
                            //todo VRATI SE
                            _lucene.AddAttachmentToIndex(attachment);
                            }
                        }
                    //}
                }
                else
                {
                    //result.ErrorMessage = Resources.ErrorMessages.FileUploadTooManyFiles;
                    result.ErrorMessage = "FileUploadTooManyFiles";
                }

                return Json(result);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                result.ErrorMessage = ex.Message;
                return Json(result);
            }
        }
    }
}

