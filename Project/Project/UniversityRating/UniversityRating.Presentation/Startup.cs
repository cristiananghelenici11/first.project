using AutoMapper;
using Microsoft.AspNetCore.Authentication.Facebook;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI;
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
using UniversityRating.Infrastructure.Profiles;
using UniversityRating.Presentation.Profiles;
using UniversityRating.Presentation.Services;
using UniversityRating.Services.Abstractions;
using UniversityRating.Services.CommentService;
using UniversityRating.Services.CourseService;
using UniversityRating.Services.MarkService;
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

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
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

            services.AddAutoMapper(expression =>
            {
                expression.AddProfile<DomainToDtoProfile>();
                expression.AddProfile<DtoProfileToDomain>();
                expression.AddProfile<DtoToViewModelProfile>();
                expression.AddProfile<ViewModelToDtoProfile>();
            });

            services.AddScoped<DbContext, UniversityRatingContext>();
            services.AddTransient(typeof(ISpecification<>), typeof(Specification<>));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<ITeacherRepository, TeacherRepository>();
            services.AddScoped<IUniversityRepository, UniversityRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IMarkRepository, MarkRepository>();

            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<IUniversityService, UniversityService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IMarkService, MarkService>();

            services.AddAuthentication()
                .AddFacebook(facebookOptions =>
                {
                    facebookOptions.AppId = "2232887083694227";
                    facebookOptions.AppSecret = "ad6f3e428f65726e97f67a9f1e8e23ad";
                })
                .AddGoogle(optionGoogle =>
                {
                    optionGoogle.ClientSecret = "rZ5jBk-ajgb0MGDPSuJwCDZ-";
                    optionGoogle.ClientId = "971621963125-h61fl2jbqnh5ugce3dfi6gc7dlfhvrip.apps.googleusercontent.com";
                });


            services.AddMvc();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

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
