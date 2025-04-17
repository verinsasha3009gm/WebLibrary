using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using Microsoft.OpenApi.Models;

namespace WebLibrary.API
{
    /// <summary>
    /// Дополнительный класс конфигурации API -шки
    /// </summary>
    public static class Startup
    {
        /// <summary>
        /// метод настройки swagger для разработчика
        /// </summary>
        /// <param name="services"></param>
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddApiVersioning().AddApiExplorer(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0, "Beta");
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
            });
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Version = "v1",
                    Title = "WebLibrary.Api",
                    Description = "This is version 1.0",
                    TermsOfService = new Uri("https://www.youtube.com/"),
                    Contact = new OpenApiContact()
                    {
                        Name = "My Contact",
                        Url = new Uri("https://www.youtube.com/")
                    }
                });
                opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    In = ParameterLocation.Header,
                    Description = "Введите валидный токен ",
                    Name = "Authorize",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                opt.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme()
                        {
                            Reference = new OpenApiReference()
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        Array.Empty<string>()
                    }
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                opt.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFile));
            });
        }
    }
}
