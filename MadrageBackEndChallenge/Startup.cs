using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LightInject;
using MadrageBackEndChallenge.Business;
using MadrageBackEndChallenge.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace MadrageBackEndChallenge.Web
{
    public class Startup
    {
        private IConfigurationRoot _configuration;
        private IServiceContainer _container;
        private IConfigurationSection _customConfig;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearerOptions =>
            {
                var paramsValidation = bearerOptions.TokenValidationParameters;

                paramsValidation.IssuerSigningKey = _container.GetInstance<SecurityKey>();
                paramsValidation.ValidAudience = "MadrageBackEndChallengeAudience";
                paramsValidation.ValidIssuer = "MadrageBackEndChallengeIssuer";

                paramsValidation.ValidateIssuerSigningKey = true;

                paramsValidation.ValidateLifetime = true;

                paramsValidation.ClockSkew = TimeSpan.Zero;
            });

            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser().Build());
            });

            services.AddDbContext<DaoContext>(options =>
            {
                options.UseSqlServer(_customConfig.GetValue<string>("ConnectionString"));
            });

            services.AddLocalization(options => options.ResourcesPath = "Resources");

            services.AddMvc().AddControllersAsServices();
        }
        public void ConfigureContainer(IServiceContainer container)
        {
            _container = container;
            _container.Register(f => f.GetInstance<IStringLocalizerFactory>().Create("Shared", "MadrageBackEndChallenge.Web"), new PerContainerLifetime());

            _container.Register<SecurityKey>(f => 
                new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_customConfig.GetValue<string>("SymmetricSecurityKey"))), new PerContainerLifetime());

            _container.Register(f => new SigningCredentials(f.GetInstance<SecurityKey>(), SecurityAlgorithms.HmacSha256), new PerContainerLifetime());

            _container.RegisterFrom<BusinessRoot>();
            _container.RegisterFrom<PersistenceRoot>();
        }
        
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).Build();

            _customConfig = _configuration.GetSection("CustomConfig");
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("pt-BR")
            });
            
            app.UseMiddleware(typeof(ErrorHandlingMiddleware));
            
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            
            _container.AdjustValidationLanguageManager();
        }
    }
}