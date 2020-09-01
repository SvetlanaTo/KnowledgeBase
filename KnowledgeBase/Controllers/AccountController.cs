using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using KnowledgeBase.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KnowledgeBase.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<AppUser> userManager;
        private SignInManager<AppUser> signInManager;

        public AccountController(UserManager<AppUser> userMgr, SignInManager<AppUser> signinMgr)
        {
            userManager = userMgr;
            signInManager = signinMgr;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            Login login = new Login();
            login.ReturnUrl = returnUrl;
            return View(login);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Login model)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = await userManager.FindByEmailAsync(model.Email);
                if (appUser != null)
                {
                    //await signInManager.SignOutAsync();
                    //Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(appUser, login.Password, false, false);
                    //if (result.Succeeded)
                    //    return Redirect(login.ReturnUrl ?? "/");

                    //0109
                    var claims = new List<Claim>();

                    claims.Add(new Claim(ClaimTypes.Name, appUser.UserName));

                    //string[] roles = appUser.Roles.Split(",");
                    List<string> roles = (List<string>)await userManager.GetRolesAsync(appUser);

                    foreach (string role in roles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, role));
                    }

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var principal = new ClaimsPrincipal(identity);

                    var props = new AuthenticationProperties();
                    props.IsPersistent = model.RememberMe;

                    //HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props).Wait();

                    //testirati bez - VRATI SE
                    await signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(appUser, model.Password, model.RememberMe, false);
                    if (result.Succeeded)
                        return Redirect(model.ReturnUrl ?? "/");

                    //return RedirectToAction("Index", "Home");
                }
                //else
                //{
                //    ViewData["message"] = "Invalid UserName or Password!";
                //}
                ModelState.AddModelError(nameof(model.Email), "Login Failed: Invalid Email or password");
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            //testirati
            await signInManager.SignOutAsync();
            //HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
            //return RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult GoogleLogin()
        {
            string redirectUrl = Url.Action("GoogleResponse", "Account");
            var properties = signInManager.ConfigureExternalAuthenticationProperties("Google", redirectUrl);
            return new ChallengeResult("Google", properties);
        }

        [AllowAnonymous]
        public async Task<IActionResult> GoogleResponse()
        {
            ExternalLoginInfo info = await signInManager.GetExternalLoginInfoAsync();
            if (info == null)
                return RedirectToAction(nameof(Login));

            var result = await signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, false);
            string[] userInfo = { info.Principal.FindFirst(ClaimTypes.Name).Value, info.Principal.FindFirst(ClaimTypes.Email).Value };
            if (result.Succeeded)
            {
                AppUser user = await userManager.FindByNameAsync(userInfo[0]);
                //await AssignRole(user.Id, "User"); 
                return View(userInfo);
            }
            else
            {
                AppUser user = new AppUser
                {
                    Email = info.Principal.FindFirst(ClaimTypes.Email).Value,
                    UserName = info.Principal.FindFirst(ClaimTypes.Email).Value,

                };

                IdentityResult identResult = await userManager.CreateAsync(user);
                if (identResult.Succeeded)
                {
                    await AssignRole(user.Id, "User");
                    identResult = await userManager.AddLoginAsync(user, info);
                    if (identResult.Succeeded)
                    {
                        await signInManager.SignInAsync(user, false);
                        return View(userInfo);
                    }
                }
                return AccessDenied();
            }
        }

        [HttpPost]
        public async Task<AppUser> AssignRole(string Id, string RoleName)
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

            return user;
        }

        void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }
    }
}
