using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeBase.DAL.Types
{
    //[NotMapped]
    public class SimilarArticle
    {
        public long? Id { get; set; }
        public string SefName { get; set; }
        public string Title { get; set; }
        public DateTime PublishEndDate { get; set; }
        public DateTime PublishStartDate { get; set; }
        public int IsDraft { get; set; }
        public int Relevance { get; set; }
    }
}
