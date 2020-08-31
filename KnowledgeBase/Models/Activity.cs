using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeBase.Models
{
    [Table("Activities")]
    public class Activity
    {
        public long Id { get; set; }


        [Column(TypeName = "datetime2")]
        public DateTime ActivityDate { get; set; }

        [Required]
        [StringLength(50)]
        public string Operation { get; set; }

        [StringLength(500)]
        public string Information { get; set; }

        public string AuthorId { get; set; }
        public virtual AppUser Author { get; set; }
    }
}

