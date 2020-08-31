using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeBase.Models
{
    [Table("Attachments")]
    public class Attachment
    {
        public long Id { get; set; }

        [Required]
        [StringLength(2048)]
        public string Path { get; set; }

        [Required]
        [StringLength(2048)]
        public string FileName { get; set; }

        [Required]
        [StringLength(5)]
        public string Extension { get; set; }

        public int Downloads { get; set; }

        [StringLength(256)]
        public string Hash { get; set; }

        public DateTime? HashTime { get; set; }

        [StringLength(50)]
        public string MimeType { get; set; }

        public long ArticleId { get; set; }
        public virtual Article Article { get; set; }

        public string AuthorId { get; set; }
        public virtual AppUser Author { get; set; }
    }
}
