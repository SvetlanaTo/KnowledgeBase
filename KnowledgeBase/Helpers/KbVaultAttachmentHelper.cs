using KnowledgeBase.Data;
using KnowledgeBase.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeBase.Helpers
{
    public class KbVaultAttachmentHelper
    {
        private KnowledgeBaseContext _context;
        public IWebHostEnvironment _env;

        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        public KbVaultAttachmentHelper(IWebHostEnvironment env, KnowledgeBaseContext context)
        {
            _context = context;
            _env = env;
        }

        //vrati se IWebHostEnvironment env

        public void RemoveLocalAttachmentFile(Attachment at)
        {
            //var webroot = env.WebRootPath;
            try
            {
                var localPath = Path.Combine(at.Path, at.FileName);
                System.IO.File.Delete(localPath);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }

        //public void RemoveAttachment(string hash, long currentUserId, IWebHostEnvironment env)
        public void RemoveAttachment(string hash, string currentUserId)
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

                var localPath = Path.Combine((attachment.Path), attachment.FileName);
                attachment.AuthorId = currentUserId;
                _context.Attachments.Remove(attachment);
                _context.SaveChanges();
                File.Delete(localPath);
                //}
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }

        public Attachment SaveAttachment(long articleId, IFormFile attachedFile, long userId)
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
                    var localPath = Path.Combine("/Uploads");
                    attachment.Path = "~/Uploads/";
                    attachment.FileName = Path.GetFileName(attachedFile.FileName);
                    attachment.Extension = Path.GetExtension(attachedFile.FileName);
                    attachment.ArticleId = articleId;
                    attachment.MimeType = attachedFile.ContentType;
                    attachment.Hash = Guid.NewGuid().ToString().Replace("-", string.Empty);
                    attachment.AuthorId = userId.ToString();
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
                Log.Error(ex);
                throw;
            }
        }
    }
}
