using KnowledgeBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeBase.DAL.Repo
{
    public interface IUserRepository
    {
        //Entities.KbUser Get(long id);
        Task<AppUser> Get(string id);
    }
}
