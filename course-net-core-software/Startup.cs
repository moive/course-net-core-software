using course_net_core_software.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace course_net_core_software
{
    public class Startup
    {
        private IConfiguration _configuration;

        public Startup( IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(_configuration.GetConnectionString("ConexionSQL")));
            services.AddRazorPages().AddRazorRuntimeCompilation();
            services.AddMvc(options => options.EnableEndpointRouting = false);
            //services.AddMvcCore(opt => opt.EnableEndpointRouting = false);
            //services.AddSingleton<IStockFriend, MockFriendRepository>();
            services.AddScoped<IStockFriend, SQLFriendRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                DeveloperExceptionPageOptions t = new DeveloperExceptionPageOptions {
                    SourceCodeLineCount = 2
                };
                app.UseDeveloperExceptionPage(t);
            }
            else if (env.IsProduction() || env.IsStaging()) {
                app.UseExceptionHandler("/Error");
            }

            app.UseRouting();

            DefaultFilesOptions d = new DefaultFilesOptions();
            d.DefaultFileNames.Clear();
            d.DefaultFileNames.Add("nodefault.html");

            //app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();

            app.Run(async context => {
                await context.Response.WriteAsync("Hello from non-Map delegate.");
            });
        }

    }
}
