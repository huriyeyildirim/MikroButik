using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MikroButik.Data;
using MikroButik.Data.Business;
using MikroButik.Data.Business.Abstract;
using MikroButik.Data.Business.Concrete;
using MikroButik.Data.DataAccess.Abstract;
using MikroButik.Data.DataAccess.Concrete;
using Miktobutik.Models.EntityModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
/// <summary>
/// 
/// </summary>
namespace MikroButik.RestApi
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
            string conn = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<MikroButik.Data.ApplicationDbContext>(op => op.UseSqlServer(conn, op2 => op2.MigrationsAssembly("MikroButik.RestApi")));
            services.AddJsonSettings();

            services.AddSwaggerGen(c =>
            {

                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MikroButik.auth.api", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    {
                        AuthorizationCode = new OpenApiOAuthFlow
                        {
                            AuthorizationUrl = new Uri($"https://localhost:44340/connect/authorize"),
                            TokenUrl = new Uri($"https://localhost:44340/connect/token"),
                            Scopes = new Dictionary<string, string>() { { "openid", "OpenID Service" } }
                        }
                    },
                    Description = "Auth Api"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement(){
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

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

            });
            //services.AddControllers().AddNewtonsoftJson(opt =>
            //{
            //    opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            //});

            services.AddScoped<ICategoryDAL, EFCategoryDAL>();
            services.AddScoped<IProductDAL, EFProductDAL>();
            services.AddScoped<IOrderDAL, EFOrderDAL>();
            services.AddScoped<IUserDAL, EFUserDAL>();
            services.AddScoped<IPhotoDAL, EFPhotoDAL>();
            services.AddScoped<IAuthService, AuthManager>();


            services.AddRazorPages();
            services.AddFromAsm<IRegister>(typeof(ApplicationDbContext).Assembly, ServiceTypes.Scoped);


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



            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Butik v1");
                c.OAuthClientId("ButikBackClient");
                c.OAuthClientSecret("fa153-xf98-trs26-mm74");
                c.OAuthAppName("Butik Api");
                c.OAuthScopeSeparator(" ");
                c.OAuthUsePkce();
            });


            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });

            app.Use(async (context, next) =>
            {
                if (!Directory.Exists(Path.Combine(env.ContentRootPath, "wwwroot/ProductImages")))
                    Directory.CreateDirectory(Path.Combine(env.ContentRootPath, "wwwroot/ProductImages"));

                await next.Invoke();

            });



            app.UseStaticFiles(new StaticFileOptions
            {

                FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "wwwroot/ProductImages")),
                RequestPath = "/wwwroot/ProductImages"
            });
        }
    }
}
