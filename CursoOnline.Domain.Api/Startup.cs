using System;
using System.IO;
using System.Reflection;
using CursoOnline.Domain.Handlers;
using CursoOnline.Domain.Infra.Contexts;
using CursoOnline.Domain.Infra.Repositories;
using CursoOnline.Domain.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Cors;
using System.Collections.Generic;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.OpenApi.Models;

namespace CursoOnline.Domain.Api
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
            // Add CORS policy
            services.AddControllers();

            services.AddCors();

            //services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("Database"));
            services.AddDbContext<DataContext>(options => options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
            //services.AddDbContext<DataContext>(opt => opt.UseSqlServer("Database"));

            services.AddTransient<IAlunoRepository, AlunoRepository>();
            services.AddTransient<ICartaoRepository, CartaoRepository>();
            services.AddTransient<IPagamentoRepository, PagamentoRepository>();
            services.AddTransient<IMatriculaRepository, MatriculaRepository>();
            services.AddTransient<ICursoRepository, CursoRepository>();

            services.AddTransient<AlunoHandler, AlunoHandler>();
            services.AddTransient<CartaoHandler, CartaoHandler>();
            services.AddTransient<PagamentoHandler, PagamentoHandler>();
            services.AddTransient<CursoHandler, CursoHandler>();
            services.AddTransient<MatriculaHandler, MatriculaHandler>();
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Curso Online", Version = "v1" });
                x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. Enter 'Bearer' [space] and then your token in the text input below.
                    Example: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                x.AddSecurityRequirement(new OpenApiSecurityRequirement()
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

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                x.IncludeXmlComments(xmlPath);


            });

            services.AddControllersWithViews()
            .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services
               .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options =>
               {
                   options.Authority = "https://securetoken.google.com/cursoonlie";
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuer = true,
                       ValidIssuer = "https://securetoken.google.com/cursoonlie",
                       ValidateAudience = true,
                       ValidAudience = "cursoonlie",
                       ValidateLifetime = true
                   };
               });


        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // migrate any database changes on startup (includes initial db creation)

            /*
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService <DataContext> ();
                context.Database.Migrate();
            }*/

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(
                options =>
                options.
                AllowAnyOrigin().
                AllowAnyMethod().
                AllowAnyHeader()
            );

            // app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Curso Online - V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute(
                                            name: "default",
                                            pattern: "{controller=Home}/{action=Index}/{id?}");
            });


        }
    }
}
