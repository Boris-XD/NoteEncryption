using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dev33.UltimateTeam.Api.Services.LoggerService;
using Dev33.UltimateTeam.Application.Contracts.Repositories;
using Dev33.UltimateTeam.Application.Contracts.Services;
using Dev33.UltimateTeam.Application.Services;
using Dev33.UltimateTeam.Infrastructure.Repositories;
using UltimateTeam.Infrastructure.Repositories;
using UltimateTeam.Application.Contracts.Services;
using UltimateTeam.Application.Services;
using Dev33.UltimateTeam.Infrastructure.Context;

namespace Dev33.UltimateTeam.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            services.AddCors(option =>
            {
                option.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });

            services.AddDbContext<SafeInformationDBContext>(options =>
              options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure();
                }
              )
              .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
              .EnableSensitiveDataLogging()
            );

            services.AddAutoMapper(typeof(Startup));

            services.AddSingleton<ILoggerManager, LoggerManager>();
            services.AddTransient(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IContainerRepository, ContainerRepository>();
            services.AddTransient<INoteRepository, NoteRepository>();
            services.AddTransient<IKeyService, KeyService>();
            services.AddTransient<ICredentialService, CredentialService>();
            services.AddTransient<ICreditCardService, CreditCardService>();
            services.AddTransient<IKeyRepository, KeyRepository>();
            services.AddTransient<IContactRepository, ContactRepository>();
            services.AddTransient<IContactService, ContactService>();
            services.AddTransient<IInformationRepository, InformationRepository>();
            services.AddTransient<IAuthenticateService, AuthenticateService>();
            services.AddTransient<IContainerService, ContainerService>();
            services.AddTransient<INoteService, NoteService>();
            services.AddTransient<ISharedInformation, SharedInformation>();
            services.AddTransient<ISearchService, SearchService>();
            services.AddTransient<IInformationRepository, InformationRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Authentication:Issuer"],
                    ValidAudience = Configuration["Authentication:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Authentication:SecretKey"])),
                    ClockSkew = TimeSpan.Zero
                };
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
