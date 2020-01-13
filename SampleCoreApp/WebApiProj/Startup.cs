using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using WebApiProj.Business;
using WebApiProj.Business.Contract;
using WebApiProj.Client.Models;
using WebApiProj.Repository;
using WebApiProj.Repository.Contract;
using WebApiProj.Repository.WebApiDBContext;

namespace WebApiProj
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
            JwtSettings settings = GetJwtSettings();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "JwtBearer";
                options.DefaultChallengeScheme = "JwtBearer";
            }).AddJwtBearer("JwtBearer", jwtBearerOptions =>
            {
                jwtBearerOptions.TokenValidationParameters =
                          new TokenValidationParameters
                          {
                              ValidateIssuerSigningKey = true,
                              IssuerSigningKey = new SymmetricSecurityKey(
                              Encoding.UTF8.GetBytes(settings.Key)),
                              ValidateIssuer = true,
                              ValidIssuer = settings.Issuer,

                              ValidateAudience = true,
                              ValidAudience = settings.Audience,

                              ValidateLifetime = true,
                              ClockSkew = TimeSpan.FromMinutes(
                                     settings.MinutesToExpiration)
                          };
            });

            services.AddDbContext<WebApiDBContext>(opt => opt.UseInMemoryDatabase("UsersInfo"));
            services.AddScoped<IWebApiBusiness, WebApiBusiness>();
            services.AddScoped<IWebApiRepo, WebApiRepo>();
            //AutoMapper
            var mappingConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

        }

        /// <summary>
        /// Gets the JWT settings.
        /// </summary>
        /// <returns>jwt settings</returns>
        private JwtSettings GetJwtSettings()
        {
            JwtSettings settings = new JwtSettings
            {
                Key = Configuration["JwtSettings:key"],
                Audience = Configuration["JwtSettings:audience"],
                Issuer = Configuration["JwtSettings:issuer"],
                MinutesToExpiration = Convert.ToInt32(Configuration["JwtSettings:minutesToExpiration"])
            };

            return settings;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
