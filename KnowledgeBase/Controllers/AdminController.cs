using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KnowledgeBase.Data;
using KnowledgeBase.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KnowledgeBase.Controllers
{
    public class AdminController : Controller
    {
        private UserManager<AppUser> userManager;
        private IPasswordHasher<AppUser> passwordHasher;
        private IPasswordValidator<AppUser> passwordValidator;
        private IUserValidator<AppUser> userValidator;
        private RoleManager<IdentityRole> _roleManager;
        private readonly KnowledgeBaseContext _context;

        public AdminController(UserManager<AppUser> usrMgr, IPasswordHasher<AppUser> passwordHash,
            IPasswordValidator<AppUser> passwordVal, IUserValidator<AppUser> userValid, RoleManager<IdentityRole> roleManager,
            KnowledgeBaseContext context)
        {
            userManager = usrMgr;
            passwordHasher = passwordHash;
            passwordValidator = passwordVal;
            userValidator = userValid;
            _roleManager = roleManager;
            _context = context;
        }


        public IActionResult UserNotFound()
        {
            return View();
        }

        //  [Authorize]
        public IActionResult Index()
        {
            return View(userManager.Users);
        }

        //  [Authorize(Policy = "AdminAccess")]
        public ViewResult Create() => View();

        //   [Authorize(Policy = "AdminAccess")]
        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser
                {
                    UserName = user.Name,
                    Email = user.Email,
                };

                IdentityResult result = await userManager.CreateAsync(appUser, user.Password);
                if (result.Succeeded)
                {
                    await AssignRole(appUser.Id, "User");
                    //AssignRole(string Id, string RoleName)
                    return RedirectToAction("Index");
                }

                else
                {
                    foreach (IdentityError error in result.Errors)
                        ModelState.AddModelError("", error.Description);
                }
            }
            return View(user);
        }

        // [Authorize(Policy = "AdminAccess")]
        public async Task<IActionResult> Details(string id)
        {
            AppUser user = await userManager.FindByIdAsync(id);
            if (user != null)
                return View(user);
            else
                return RedirectToAction("UserNotFound");
        }



        //  [Authorize(Policy = "AdminAccess")]
        public async Task<IActionResult> Update(string id)
        {
            AppUser user = await userManager.FindByIdAsync(id);
            if (user != null)
                return View(user);
            else
                return RedirectToAction("Index");
        }

        //   [Authorize(Policy = "AdminAccess")]
        [HttpPost]
        public async Task<IActionResult> Update(string id, string email, string password)
        {
            AppUser user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult validEmail = null;
                if (!string.IsNullOrEmpty(email))
                {
                    validEmail = await userValidator.ValidateAsync(userManager, user);
                    if (validEmail.Succeeded)
                        user.Email = email;
                    else
                        Errors(validEmail);
                }
                else
                    ModelState.AddModelError("", "Email cannot be empty");

                IdentityResult validPass = null;
                if (!string.IsNullOrEmpty(password))
                {
                    validPass = await passwordValidator.ValidateAsync(userManager, user, password);
                    if (validPass.Succeeded)
                        user.PasswordHash = passwordHasher.HashPassword(user, password);
                    else
                        Errors(validPass);
                }
                else
                    ModelState.AddModelError("", "Password cannot be empty");

                if (validEmail != null && validPass != null && validEmail.Succeeded && validPass.Succeeded)
                {
                    IdentityResult result = await userManager.UpdateAsync(user);
                    if (result.Succeeded)
                        return RedirectToAction("Index");
                    else
                        Errors(result);
                }
            }
            else
                ModelState.AddModelError("", "User Not Found");

            return View(user);
        }

        void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }

        //  [Authorize(Policy = "AdminAccess")]
        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            AppUser user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await userManager.DeleteAsync(user);
                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                    Errors(result);
            }
            else
                ModelState.AddModelError("", "User Not Found");
            return View("Index", userManager.Users);
        }

        //***************************************** assign role to user
        //   [Authorize(Policy = "AdminAccess")]
        public async Task<IActionResult> AssignRole(string Id)
        {
            List<IdentityRole> roles = new List<IdentityRole>();
            foreach (IdentityRole role in _roleManager.Roles)
            {
                roles.Add(role);
            }
            AppUser user = await userManager.FindByIdAsync(Id);

            if (user != null)
                //return View(user); ZBOG OVOGA MI NE VRACA USER ID
                //return View();
                return View(new UpdateUserRole
                {
                    Roles = roles,
                    User = user,

                });
            else
                return RedirectToAction("Index");
        }

        //   [Authorize(Policy = "AdminAccess")]
        [HttpPost]
        public async Task<IActionResult> AssignRole(string Id, string RoleName)
        {
            IdentityResult result;
            AppUser user = await userManager.FindByIdAsync(Id);

            if (user != null)
            {
                result = await userManager.AddToRoleAsync(user, RoleName);

                if (!result.Succeeded)
                    Errors(result);
            }
            else
                ModelState.AddModelError("", "User Not Found");

            return RedirectToAction("Index");
        }

        public class DisplayViewModel
        {
            public IEnumerable<string> Roles { get; set; }
            public IEnumerable<UsersViewModel> Users { get; set; }
        }
        public class UsersViewModel
        {
            //public string Email { get; set; }
            public string Id { get; set; }
            public IEnumerable<UsersRole> Roles { get; set; }
        }

        public class UsersRole
        {
            public string Name { get; set; }
        }

        public class RoleViewModel
        {
            public string Name { get; set; }
        }

        public class UpdateUserRoleViewModel
        {
            public IEnumerable<UsersViewModel> Users { get; set; }
            public IEnumerable<string> Roles { get; set; }

            public string UserEmail { get; set; }
            public string Role { get; set; }
            public bool Delete { get; set; }
        }
    }
}