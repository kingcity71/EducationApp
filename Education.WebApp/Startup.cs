using Education.Interfaces;
using Education.Services;
using Education.WebApp.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using VueCliMiddleware;
using Education.Data;

namespace Education
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
            //services.AddCors();
            services.AddControllers();
            services.AddDbContext<EduContext>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<ITutorService, TutorService>();
            services.AddTransient<IGroupService, GroupService>();
            services.AddTransient<ILessonService, LessonService>();
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "client-app";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<JwtMiddleware>();
            //app.UseCors(
            //    options => options.WithOrigins("*").AllowAnyMethod()
            //);
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");

                // Add MapRazorPages if the app uses Razor Pages. Since Endpoint Routing includes support for many frameworks, adding Razor Pages is now opt -in.
                // endpoints.MapRazorPages();
            });
            
            app.UseSpa(spa =>
                {
                    if (env.IsDevelopment())
                        spa.Options.SourcePath = "client-app";
                    else
                        spa.Options.SourcePath = "dist";
                    if (env.IsDevelopment())
                    {
                        spa.UseVueCli(npmScript: "serve");
                    }
                }
            );

        }
    }
}
