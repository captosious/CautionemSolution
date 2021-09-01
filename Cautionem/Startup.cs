using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Cautionem.Models;
using Cautionem.Data;
using Cautionem.Shared;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Security.Claims;
using Blazored.Toast;
using Microsoft.AspNetCore.Components.Authorization;

namespace Cautionem
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEmptyProviders();

            services.AddDbContext<CautionemContext>(options =>
            {
                options.UseMySQL(Configuration.GetConnectionString("MySQLConnectionString"));
                options.EnableSensitiveDataLogging(false);
            }
            );
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddBlazoredToast();
            //services.AddScoped<DialogService>();
            //services.AddScoped<NotificationService>();
            // Configuration
            services.AddSingleton<MyAppSettings>();
            services.AddSingleton<SharedLocalizer>();
            // Services
            services.AddScoped<Login>();
            services.AddTransient<CompanyService>();
            services.AddTransient<BankService>();
            services.AddTransient<PaymentTypeService>();
            services.AddTransient<CustomerService>();
            services.AddTransient<CustomerContactService>();
            services.AddScoped<AccessService>();
            services.AddScoped<CustomAuthenticationStateProvider>();

            // Add LocalLanguages.
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.AddScoped<MyBlocker>();
            //Blazorise
            services.AddBlazorise(options =>
            {
                options.ChangeTextOnKeyPress = false; options.ChangeSliderOnHold = true; // optional
            })
                .AddBootstrapProviders()
                .AddFontAwesomeIcons();

            //Autho & Authen
            services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
            services.AddAuthentication(options =>
            {

            }
            );
            services.AddAuthorization(options =>
            {
                options.AddPolicy("administrator", policy => policy.RequireClaim(ClaimTypes.Role, "0"));
                options.AddPolicy("manager", policy => policy.RequireClaim(ClaimTypes.Role, "1"));
                options.AddPolicy("operator", policy => policy.RequireClaim(ClaimTypes.Role, "2"));
                options.AddPolicy("guest", policy => policy.RequireClaim(ClaimTypes.Role, "3"));
            }
            );
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
                app.UseHsts();
            }

            // Globalization Init
            IList<CultureInfo> supportedCultures = new List<CultureInfo>
            {
                new CultureInfo("en-GB"),
                new CultureInfo("es-ES"),
                new CultureInfo("ca-ES"),
            };

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("es-ES"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
