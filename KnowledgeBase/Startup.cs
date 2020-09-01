using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KnowledgeBase.DAL.Repo;
using KnowledgeBase.IdentityPolicy;
using KnowledgeBase.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using KnowledgeBase.Models;
using Microsoft.Extensions.DependencyInjection.Extensions;
using KnowledgeBase.Business.ApplicationSettings;
using KnowledgeBase.Business.Articles;
using KnowledgeBase.Business.Categories;
using KnowledgeBase.Helpers;

namespace KnowledgeBase
{
    public class Startup
    {
        //public Startup(IConfiguration configuration) => Configuration = configuration; 
        public IWebHostEnvironment _env;

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSession();

            services.AddDbContext<KnowledgeBaseContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IPasswordValidator<AppUser>, CustomPasswordPolicy>();
            services.AddTransient<IUserValidator<AppUser>, CustomUsernameEmailPolicy>();

            services.AddTransient<IAuthorizationHandler, AllowUsersHandler>();
            services.AddTransient<IAuthorizationHandler, AllowPrivateHandler>();
            services.AddTransient<KbVaultLuceneHelper>();
            services.AddTransient<KbVaultAttachmentHelper>();


            services.AddAuthorization(opts =>
            {
                opts.AddPolicy("AdminAccess", policy =>
                {
                    policy.RequireRole("Admin");
                    //policy.RequireClaim("Coding-Skill", "ASP.NET Core MVC");
                });
                opts.AddPolicy("ManagerAccess", policy =>
                    policy.RequireAssertion(context =>
                                context.User.IsInRole("Admin")
                                || context.User.IsInRole("Manager")));

                opts.AddPolicy("UserAccess", policy =>
                    policy.RequireAssertion(context =>
                                context.User.IsInRole("Admin")
                                || context.User.IsInRole("Manager")
                                || context.User.IsInRole("User")));
            });


            //NACIN autorizovanja!!!
            services.AddAuthorization(opts =>
            {
                opts.AddPolicy("AllowTom", policy =>
                {
                    policy.AddRequirements(new AllowUserPolicy("tom"));
                });
            });
            services.AddAuthorization(opts =>
            {
                opts.AddPolicy("PrivateAccess", policy =>
                {
                    policy.AddRequirements(new AllowPrivatePolicy());
                });
            });

            services.AddAuthentication().AddGoogle(opts =>
            {
                opts.ClientId = "280902487776-8re3f4rmntj07sl8ikd3k4vmkfi339kv.apps.googleusercontent.com";
                opts.ClientSecret = "0VY64UmrEsbBgizNNkgN9xw_";
                //opts.ClientId = "174861462797-s3fdn0kqn6egf8a4n13sdrdr2vblroc2.apps.googleusercontent.com";
                //opts.ClientSecret = "cwrRKYDgsRA7bTJAHpQnZH35";
                //opts.CallbackPath = "/Account/GoogleResponse";
            });

            //services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<AppIdentityDbContext>().AddDefaultTokenProviders();
            services.AddIdentity<AppUser, IdentityRole>(opts =>
            {
                opts.User.RequireUniqueEmail = true;
                //opts.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyz";
                opts.Password.RequiredLength = 4;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<KnowledgeBaseContext>().AddDefaultTokenProviders();
            services.AddMvc();

            services.ConfigureApplicationCookie(config =>
            {
                config.Cookie.Name = "Identity.Cookie";
                config.LoginPath = "/Account/Login";
                //config.AccessDeniedPath = "/Home/AccessDenied";
            });

            //TODO
            //CookieBanner
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                //CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //https://docs.microsoft.com/en-us/aspnet/core/data/ef-rp/sort-filter-page?view=aspnetcore-3.1
            services.AddRazorPages();

            //services.AddMailKit(config => config.UseMailKit(Configuration.GetSection("Email").Get<MailKitOptions>()));

            services.AddControllersWithViews();

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //posle AddControllersWithViews 
            services.AddHttpContextAccessor();


            // serviceCollection.AddSingleton(typeof(IArticleRepository), typeof(ArticleRepository));
            //serviceCollection.AddSingleton<IArticleRepository, ArticleRepository>();

            // best practice  TODO: GenericRepo 
            // services.AddTransient(typeof(IGenericRepository<Article>), typeof(GenericRepository<Article>));
            //container.RegisterType<DbContext, AuthContext>(new HierarchicalLifetimeManager());

            services.AddTransient(typeof(IArticleRepository), typeof(ArticleRepository));
            services.AddTransient(typeof(ICategoryRepository), typeof(CategoryRepository));
            services.AddTransient(typeof(ISettingsRepository), typeof(SettingsRepository));
            services.AddTransient(typeof(ITagRepository), typeof(TagRepository));
            services.AddTransient(typeof(IUserRepository), typeof(UserRepository));
            services.AddTransient(typeof(IActivityRepository), typeof(ActivityRepository));


            services.AddTransient(typeof(ISettingsFactory), typeof(SettingsFactory));
            services.AddTransient(typeof(ISettingsService), typeof(SettingsService));
            services.AddTransient(typeof(IArticleFactory), typeof(ArticleFactory));
            services.AddTransient(typeof(ICategoryFactory), typeof(CategoryFactory));



        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSession();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Admin/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();

            app.UseStatusCodePages();
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            //CookieBanner
            app.UseCookiePolicy();
            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();

            //app.UseMvcWithDefaultRoute();
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapDefaultControllerRoute();
            //});

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
