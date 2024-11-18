using Application.Services;
using Core.Repositories;
using Core.Services;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using Presentation.Services;
using Infrastructure.Services;

namespace Presentation
{
    public class Program
    {
        private static void ConfigureSwagger(IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
                        {
                            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Gabini API", Version = "v1" });
                            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                            {
                                Name = "Authorization",
                                Type = SecuritySchemeType.Http,
                                Scheme = "Bearer",
                                BearerFormat = "JWT",
                                In = ParameterLocation.Header
                            });
                            c.AddSecurityRequirement(new OpenApiSecurityRequirement
                            {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
                        });
        }

        private static void InjectRepositoryDependency(IHostApplicationBuilder builder)
        {
            string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<GabiniDbContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
            );
        }

        private static void AddControllersAndDependencies(IHostApplicationBuilder builder)
        {
            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);

            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();

            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IAddressService, AddressService>();

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IAddressRepository, AddressRepository>();

            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IAuthRepository, AuthRepository>();

            builder.Services.AddScoped<ITokenService, TokenService>();

            builder.Services.AddScoped<IImageService, ImageService>();
        }

        private static void InitializeSwagger(WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        private static void SeedOnInitialize(WebApplication app)
        {
            // Configura o banco de dados com dados de seed
            using (IServiceScope scope = app.Services.CreateScope())
            {
                IServiceProvider services = scope.ServiceProvider;
                try
                {
                    GabiniDbContext context = services.GetRequiredService<GabiniDbContext>();
                    SeedData.Initialize(services);
                }
                catch (Exception ex)
                {
                    ILogger<Program> logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }
        }

        private static void Authentication(IHostApplicationBuilder builder)
        {
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SECRET_KEY"]!))
                    };
                });
            builder.Services.AddAuthorization();
        }

        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            ConfigureSwagger(builder.Services);
            InjectRepositoryDependency(builder);
            AddControllersAndDependencies(builder);
            Authentication(builder);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: "AllowOrigin", policy =>
                {
                    policy.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            WebApplication app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                InitializeSwagger(app);
            }

            SeedOnInitialize(app);

            app.UseCors("AllowOrigin");

            app.MapControllers();

            app.UseStaticFiles();

            app.Run();
        }
    }
}
