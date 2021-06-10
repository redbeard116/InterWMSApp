using InterWMSApp.Models;
using InterWMSApp.Models.AppSettings;
using InterWMSApp.Services.AuthServices;
using InterWMSApp.Services.ContractService;
using InterWMSApp.Services.CounterpartyService;
using InterWMSApp.Services.DB;
using InterWMSApp.Services.DictionaryService;
using InterWMSApp.Services.OperationService;
using InterWMSApp.Services.ProductPriceService;
using InterWMSApp.Services.ProductService;
using InterWMSApp.Services.ProductStorageService;
using InterWMSApp.Services.StorageAreaService;
using InterWMSApp.Services.UserService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace InterWMSApp
{
    public class Startup
    {
        private AppSettings _appSettings;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            _appSettings = new AppSettings();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.RequireHttpsMetadata = false;
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            // укзывает, будет ли валидироваться издатель при валидации токена
                            ValidateIssuer = true,
                            // строка, представляющая издателя
                            ValidIssuer = AuthOptions.ISSUER,

                            // будет ли валидироваться потребитель токена
                            ValidateAudience = true,
                            // установка потребителя токена
                            ValidAudience = AuthOptions.AUDIENCE,
                            // будет ли валидироваться время существования
                            ValidateLifetime = true,

                            // установка ключа безопасности
                            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                            // валидация ключа безопасности
                            ValidateIssuerSigningKey = true,
                        };
                    });
            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });

            services.AddAuthorization(options =>
            {
                foreach (var role in Enum.GetValues(typeof(UserRole)).Cast<UserRole>())
                {
                    options.AddPolicy(role.ToString(),
                   authBuilder =>
                   {
                       authBuilder.RequireRole(role.ToString());
                   });
                }
            });

            Configuration.GetSection("AppSettings").Bind(_appSettings);
            services.AddDbContext<DBContext>(ServiceLifetime.Transient);
            services.AddSingleton<IAuthService, AuthService>();
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IDictionaryService, DictionaryService>();
            services.AddSingleton<IContractService, ContractService>();
            services.AddSingleton<ICounterpartyService, CounterpartyService>();
            services.AddSingleton<IOperationService, OperationService>();
            services.AddSingleton<IProductService, ProductService>();
            services.AddSingleton<IProductStorageService, ProductStorageService>();
            services.AddSingleton<IStorageAreaService, StorageAreaService>();
            services.AddSingleton<IProductPriceService, ProductPriceService>();
            services.AddSingleton(_appSettings);
            services.AddSignalR();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
