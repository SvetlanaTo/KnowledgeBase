using KnowledgeBase.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeBase.ViewModels
{
    public class AttachmentViewModel 
    {
        //private readonly IActionContextAccessor _actionContextAccessor;
        private readonly IHttpContextAccessor _httpContextAccessor;         
        public AttachmentViewModel(Attachment attachment, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            this.ArticleId = attachment.ArticleId;
            this.Downloads = attachment.Downloads;
            this.Extension = attachment.Extension;
            this.FileName = attachment.FileName;
            this.Id = attachment.Id;
            this.Path = attachment.Path;
            this.Hash = attachment.Hash;
        }

        public long Id { get; set; }
        public long ArticleId { get; set; }
        public string Path { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public long Downloads { get; set; }
        public string Hash { get; set; }

        public string RemoveConfirmMessage => "Remove Attachment?";//Resources.UIResources.ArticleAttachmentRemoveConfirmation;


        //???
        public LinkGenerator _linkGenerator;
        //ControllerLinkGeneratorExtensions
        public string RemoveLink
        {
            get
            {
                //HttpContext.RequestServices.GetService(typeof(IActionContextAccessor)) as IActionContextAccessor;
                //if (actionContextAccessor == null)
                //    throw new Exception("IActionContextAccessor cannot be resolved");

                //var context = actionContextAccessor.ActionContext;
                //var linkHelper = new UrlHelper(_actionContextAccessor.ActionContext);
                //return linkHelper.Action("Remove", "File", new { id = $"{this.Hash}|{this.Id}" });

                //todo TESTIRATI
                HttpContext httpContext = _httpContextAccessor.HttpContext;
                //string uri = ControllerLinkGeneratorExtensions.GetUriByAction(_linkGenerator, httpContext, "Remove", "File", new { id = $"{this.Hash}|{this.Id}" });
                string uri = _linkGenerator.GetUriByAction(httpContext, "Remove", "File", new { id = $"{this.Hash}|{this.Id}" });
                
                return uri;
            }
        }

        //todo VRATI SE
        //public string DownloadLink
        //{
        //    get
        //    {
        //        var linkHelper = new UrlHelper(_actionContextAccessor.ActionContext);
        //        return linkHelper.Content(Path + FileName);
        //    }
        //}
    }
}
