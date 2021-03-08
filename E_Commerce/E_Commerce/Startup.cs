using E_Commerce.Data;
using E_Commerce.Data.interfaces;
using E_Commerce.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940



        private IConfigurationRoot _configurationRoot;

        public Startup(IHostingEnvironment hostingEnvironment)
        {
            _configurationRoot = new ConfigurationBuilder().SetBasePath(hostingEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json").Build();

        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            

            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(_configurationRoot.GetConnectionString("DefaultConnection")));

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IBuyListReository, BuyListRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ILikedListRepository, LikedListRepository>();
            services.AddSession();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});

            app.UseMvc();
            app.UseStaticFiles();
            app.UseSession();

            app.UseMvc(Route=> {
                Route.MapRoute("CleanRoute",
                "Home/{Action}",
                new { controller = "Home", action = "List" });

                Route.MapRoute(
                           name: "document",
                           template: "Main/{Action}/{Id?}"
                           );


                Route.MapRoute(name: "Default", template: "{Controller=Home}/{Action=List.cshtml}/{id?}");
               
            });
        }
    }
}
