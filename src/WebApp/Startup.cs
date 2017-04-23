using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using UrlMinifier.Repository;
using UrlMinifier.Repository.Implementation;
using UrlMinifier.Repository.Interfaces;
using UrlMinifier.Services.Implementations;
using UrlMinifier.Services.Interfaces;
using UrlMinifier.WebApp.Managers;

namespace UrlMinifier.WebApp
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            if (env.IsDevelopment())
            {
                builder.AddApplicationInsightsSettings(true);
            }

            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Adds a default in-memory implementation of IDistributedCache.
            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                options.IdleTimeout = TimeSpan.FromMinutes(15);
                options.CookieHttpOnly = true;
            });

            services.AddApplicationInsightsTelemetry(Configuration);
            services.AddMvc();

            DiSettings(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "node_modules")),
                RequestPath = "/node_modules"
            });

            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(
                    name: "shorturl",
                    template: "{shortUrl}",
                    defaults: new { controller = "Url", action = "Index" });

                routes.MapSpaFallbackRoute("spa-fallback", new { controller = "home", action = "index" });
            });
        }

        private void DiSettings(IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped(typeof(IMinifiedUrlRepository), typeof(MinifiedUrlRepository));
            services.AddScoped(typeof(IUserRepository), typeof(UserRepository));

            services.AddScoped(typeof(IMinifiedUrlService), typeof(MinifiedUrlService));
            services.AddScoped(typeof(IUserService), typeof(UserService));

            services.AddScoped(typeof(IUserManager), typeof(UserManager));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}
