using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BisiparişÇekirdek.Valıklar.Güvenlik;
using BisiparişWeb.Modeller.Güvenlik;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace BisiparişWeb
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
            services.AddDistributedMemoryCache();
            services.AddMemoryCache();
            services.AddSession(op =>
            {
                op.IdleTimeout = TimeSpan.FromSeconds(30);
                op.Cookie.HttpOnly = true; op.Cookie.IsEssential = true;
            });

            //services.AddIdentity<KullanıcıModel, KullanıcılarGrupModel>(/*op => op.Stores*/).AddSignInManager<KullanıcıModel>();
            services.AddRazorPages()
                .AddRazorPagesOptions(op => op.Conventions.AllowAnonymousToPage("/SistemGüvenlik/Giriş"));

            services.AddMvc(options => options.EnableEndpointRouting = false)
                .AddNewtonsoftJson(op => op.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver())
                .AddJsonOptions(op => op.JsonSerializerOptions.PropertyNameCaseInsensitive = true);

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(op =>
                {
                    op.LoginPath = new PathString("/SistemGüvenlik/Giriş");
                    //op.Cookie.Name = ".Bisipariş.AuthenticationCookie";
                });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                //app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            //app.UseCookiePolicy();
            app.UseRouting();
            //app.UseAuthentication();
            //app.UseAuthorization();
            app.UseSession();
            app.UseMvcWithDefaultRoute();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
