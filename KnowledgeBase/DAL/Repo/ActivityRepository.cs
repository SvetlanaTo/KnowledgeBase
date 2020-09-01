using KnowledgeBase.Data;
using KnowledgeBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeBase.DAL.Repo
{
    public class ActivityRepository : IActivityRepository
    {

        private KnowledgeBaseContext _context;

        public ActivityRepository(KnowledgeBaseContext context)
        {
            _context = context;
        }

        public void ArticleActivities(Article article, string v)
        {
            Activity activity = new Activity();
            activity.ActivityDate = DateTime.Now;
            if (v.Equals("added"))
            {
                activity.Operation = "Article - Added";
            }
            else if (v.Equals("updated"))
            {
                activity.Operation = "Article - Updated";
            }
            else
                activity.Operation = "Article - Deleted";

            activity.Information = "Title: " + article.Title + " Id:" + article.Id.ToString();
            activity.AuthorId = article.AuthorId;

            _context.Activities.Add(activity);
            _context.SaveChanges();
        }



    }
}
