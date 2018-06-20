using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kw.Web.Controllers;
using Kw.Web.Filters;
using Kw.Web.Log;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
namespace Kw.Web
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
            services.AddMvc(options =>
            {
                options.Filters.Add(new AddHeaderAttribute("GlobalAddHeader",
                       "Result filter added to MvcOptions.Filters")); // an instance
                options.Filters.Add(typeof(SampleAsyncActionFilter)); // by type
                //options.Filters.Add(new SampleGlobalActionFilter()); // an instanc});
            });
            services.AddLogging();

            services.AddScoped(typeof(ILogFac ), typeof(LogFac ));
            services.AddTransient(typeof(IService ), typeof(Service));
            //services..AddTransient(typeof(ILogFac<>), typeof(LogFac<>));
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {

            // 添加日志支持
             loggerFactory.AddConsole();
             loggerFactory.AddDebug();

            // 添加NLog日志支持
            loggerFactory.AddNLog();

            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
