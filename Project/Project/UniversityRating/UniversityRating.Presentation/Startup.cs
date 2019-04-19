using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UniversityRating.Data.Abstractions.Interfaces;
using UniversityRating.Data.Abstractions.Repositories;
using UniversityRating.Data.Context;
using UniversityRating.Data.Core.DomainModels.Identity;
using UniversityRating.Data.Repositories;
using UniversityRating.Presentation.Services;
using UniversityRating.Services;
using UniversityRating.Services.Abstractions;
using UniversityRating.Services.CommentService;
using UniversityRating.Services.TeacherService;
using UniversityRating.Services.UniversityService;

namespace UniversityRating.Presentation
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddIdentity<User, Role>(opt =>
                {
                    opt.Password.RequiredLength = 6;
                    opt.Password.RequireDigit = false;
                    opt.Password.RequireLowercase = false;
                    opt.Password.RequireNonAlphanumeric = false;
                    opt.Password.RequireUppercase = false;
                    opt.Password.RequireNonAlphanumeric = false;
                })
                .AddEntityFrameworkStores<UniversityRatingContext>()
                .AddDefaultTokenProviders();

                services.AddTransient<IEmailSender, EmailSender>();

            services.AddDbContext<UniversityRatingContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

//            services.AddDefaultIdentity<User>()
//                .AddDefaultUI(UIFramework.Bootstrap4)
//                .AddEntityFrameworkStores<UniversityRatingContext>();

            services.AddAutoMapper();
            //services.AddAutoMapper(additional => additional.AddProfiles(Assembly.Load("UniversityRating.Infrastructure")));


            services.AddScoped<DbContext, UniversityRatingContext>();
            services.AddTransient(typeof(ISpecification<>), typeof(Specification<>));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<ITeacherRepository, TeacherRepository>();
            services.AddScoped<IUniversityRepository, UniversityRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<IUniversityService, UniversityService>();
            services.AddScoped<ICommentService, CommentService>();

            services.AddMvc();

//            services.AddTransient<IEmailSender,EmailSender>();
//            services.AddTransient<IEmailSender,YourSmsSender>();

//            services.AddAuthentication().AddFacebook(facebookOptions =>
//            {
//                facebookOptions.AppId = "626492187709103";
//                facebookOptions.AppSecret = "60d9f4cdc0059c33b06daf1eaed953ed";
//            });

//            services.AddDefaultIdentity<IdentityUser>()
//                .AddDefaultUI(UIFramework.Bootstrap4)
//                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
