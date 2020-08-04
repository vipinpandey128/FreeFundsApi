using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FreeFundsApi.Common;
using FreeFundsApi.Concrete;
using FreeFundsApi.Interface;
using FreeFundsApi.Mappings;
using FreeFundsApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace FreeFundsApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        private Dictionary<string, List<string>> CorsPolicies { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            #region MyRegion
            var connection = Configuration.GetConnectionString("DatabaseConnection");
            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connection));

            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // configure jwt authentication
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


            services.AddSingleton<IConfiguration>(Configuration);
            services.AddTransient<ISchemeMaster, SchemeMasterConcrete>();
            services.AddTransient<IRole, RoleConcrete>();
            services.AddTransient<IUsers, UsersConcrete>();
            services.AddTransient<IUsersInRoles, UsersInRolesConcrete>();
            services.AddTransient<IRenewal, RenewalConcrete>();
            services.AddTransient<IReports, ReportsMaster>();
            services.AddTransient<IGenerateRecepit, GenerateRecepitConcrete>();
            services.AddTransient<IGenerateRecepit, GenerateRecepitConcrete>();
            services.AddTransient<IAllGame, AllGameConcrete>();
            services.AddTransient<IAllTransaction, AllTransactionConcrete>();
            services.AddTransient<ITransactionType, TransactionTypeConcrete>();
            services.AddTransient<IBet, BetsConcrete>();
            services.AddTransient<IWinning, WinningConcrete>();
            services.AddTransient<IWithdrawalLimit, WithdrawalLimitConcrete>();
            services.AddTransient<ILoginStatus, LoginStatusConcrete>();
            services.AddTransient<IAgent, AgentUserConcrete>();
            services.AddTransient<IUserProfile, UserProfileConcrete>();
            services.AddTransient<IAgentTransaction, AgentTransactionConcrete>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddScoped<IUrlHelper>(implementationFactory =>
            {
                var actionContext = implementationFactory.GetService<IActionContextAccessor>().ActionContext;
                return new UrlHelper(actionContext);
            });
            #endregion

            services.AddControllers();
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapping());
            });


            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);


            //End Registering and Initializing AutoMapper

            services.AddMvc(options => { options.Filters.Add(typeof(CustomExceptionFilterAttribute)); })
            .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
                options.JsonSerializerOptions.DictionaryKeyPolicy = null;
            });
            //adding cors

            CorsPolicies = Configuration.GetSection("CORS.Policies").Get<Dictionary<string, List<string>>>();

            services.AddCors(options =>
            {
                foreach (var policy in CorsPolicies)
                {
                    options.AddPolicy(
                        name: policy.Key,
                        builder =>
                        {
                            builder.WithOrigins(policy.Value.ToArray())
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .SetIsOriginAllowed(origin => true)
                            .AllowCredentials();
                        }
                        );
                }
            });

            services.AddSwaggerGen(c =>
            {
                // sepcify our operation filter here.  
                // c.OperationFilter<AddCommonParameOperationFilter();

                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1.0.0",
                    Title = $"v1 API",
                    Description = "v1 API",

                    Contact = new OpenApiContact
                    {
                        Name = "Catcher Wong",
                        Email = "catcher_hwq@outlook.com",
                    }
                });
            });


            services.AddSwaggerDocumentation();
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwaggerDocumentation();
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Test API V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                var builder = endpoints.MapControllers();
                foreach (var policy in CorsPolicies)
                {
                    builder.RequireCors(policy.Key);
                }
            });
        }

    }

    public static class SwaggerServiceExtensions
    {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1.0", new OpenApiInfo { Title = "Main API v1.0", Version = "v1.0" });

                //Locate the XML file being generated by ASP.NET...
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.XML";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                if (File.Exists(xmlPath))
                {
                    //... and tell Swagger to use those XML comments.
                    c.IncludeXmlComments(xmlPath);
                }


                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                        {
                            {
                                new OpenApiSecurityScheme
                                {
                                    Reference = new OpenApiReference
                                    {
                                        Type = ReferenceType.SecurityScheme,
                                        Id = "Bearer"
                                    },
                                    Scheme = "oauth2",
                                    Name = "Bearer",
                                    In = ParameterLocation.Header,

                                },
                                new List<string>()
                            }
                        });

            });
            return services;
        }
        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
        {

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1.0/swagger.json", "FreeFunds Web API v1.0");
                c.DocumentTitle = "Title Documentation";
                c.RoutePrefix = string.Empty;
            });

            return app;
        }
    }
}



