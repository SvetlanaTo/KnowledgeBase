using KnowledgeBase.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeBase.DAL.Repo
{
    public class UserRepository : IUserRepository
    {
        private UserManager<AppUser> _userManager;

        public UserRepository(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<AppUser> Get(string id)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            return user;
        }

    }
}
