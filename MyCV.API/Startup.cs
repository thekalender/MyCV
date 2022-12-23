using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Security.Encyption;
using Core.Utilities.Security.Jwt;
using DataAccess.Absract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCV.API
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
            services.AddControllers();
            services.AddMvcCore().AddApiExplorer();

            // Burası önemli.bu portun dışındakilere cevap verme demektir.
            services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin",
                    builder => builder.WithOrigins("http://localhost:4371"));
            });

            //appsettings.jsonda ki TokenOptions jsona erişmemizi sağlıyor.
            var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();

            //JwtBearerDefaults kulananabilmek için nugetten "Microsoft.AspNetCore.Authentication.JwtBearer" 5 sürümünü indirmek lazım.
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(option =>
            {
                option.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = tokenOptions.Issuer,
                    ValidAudience = tokenOptions.Audience,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
                };
            });

            services.AddSwaggerDocument(config => {
                config.PostProcess = (doc =>
                {
                    doc.Info.Title = "All Hotel Api";
                    doc.Info.Version = "1.0.13";
                    doc.Info.Contact = new NSwag.OpenApiContact()
                    {
                        Name = "Ahmet Kalender",
                        Url = "https://github.com/thekalender",
                        Email = "ahmet@ksoft.com"

                    };
                });
            });//Swagger => Swagger için nugetten Nswag.AspNetCore indirmemiz lazýmdýr.
        
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Swagger_start
            app.UseOpenApi();
            app.UseSwaggerUi3();
            //Swagger_end

            app.UseCors(builder => builder.WithOrigins("http://localhost:4371").AllowAnyHeader()); // Bu hosttan gelen isteklere cevap ver demektir.(CRUD işlemlerine yani cevap ver demek)
            app.UseRouting();

            app.UseAuthentication(); // Bir yere girmek için anahtar diye düşünebiliriz. ortama giriş anahtarıda diyebiliriz.

            app.UseAuthorization(); // içeri girdiğimiz herhangi bir yerde ne yapabiliriz. elinde anahtar var ama istediğimiz koşulları yapar demek

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
