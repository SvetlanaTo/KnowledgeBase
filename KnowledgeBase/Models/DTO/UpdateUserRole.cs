using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeBase.Models
{
    public class UpdateUserRole
    {
        public IEnumerable<IdentityRole> Roles { get; set; }

        //public IEnumerable<AppUser> Users { get; set; }
        public AppUser User { get; set; }

        //public string UserId { get; set; }
        public IdentityRole Role { get; set; }
        public bool Delete { get; set; }

    }
}