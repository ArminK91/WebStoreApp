using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModels.Context;
using DomainModels.DbModels;
using DomainModels.Other;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using WebStoreAPP.BLL.CategoryService;
using WebStoreAPP.BLL.HelperService;
using WebStoreAPP.BLL.IdentityService;
using WebStoreAPP.BLL.ImageService;
using WebStoreAPP.BLL.Interfaces;
using WebStoreAPP.BLL.ProductService;

namespace WebStoreApp.API
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

            // services.AddSingleton(Configuration);

            // Add framework services.
            // services.AddDbContext<AdvOpDbContext>();
             services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            
            services.AddMvc().AddJsonOptions(opt => {
                opt.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            }).AddXmlSerializerFormatters();

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = false;
            });
            //.AddEntityFrameworkStores<ServiceProviderServiceExtensions..Database.EFProvider.DataContext>()
            //.AddDefaultTokenProviders();

            services.AddCors();

            services.AddTransient<IIdentity, IdentityService>();
             services.AddTransient<IProduct, ProductService>();
             services.AddTransient<ICategory, CategoryService>();
             services.AddTransient<IHelper, HelperService>();
            services.AddTransient<IImage, ImageService>();

            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x => x
              .AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials());
            //        app.UseCors(builder =>
            //builder.WithOrigins("http://localhost:4200/")
            //       .AllowAnyHeader()
            //);
            app.UseIdentity();

           // app.UseAuthentication();

            app.UseMvc();
        }
    }
}
