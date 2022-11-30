using Business.Abstract;
using Business.Concrete;
using DataAccess.Absract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
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

            services.AddSingleton<IAboutDal, EfAboutDal>();
            services.AddSingleton<IAboutService, AboutManager>();

            services.AddSingleton<IClmOneExperinceDal, EfClmOneExperinceDal>();
            services.AddSingleton<IClmOneExperienceService, ClmOneExperienceManager>();

            services.AddSingleton<IClmTwoExperinceDal, EfClmTwoExperienceDal>();
            services.AddSingleton<IClmTwoExperinceService, ClmTwoExperienceManager>();

            services.AddSingleton<IClmOneSkillDal, EfClmOneSkillDal>();
            services.AddSingleton<IClmOneSkillService, ClmOneSkillManager>();

            services.AddSingleton<IClmTwoSkillDal, EfClmTwoSkillDal>();
            services.AddSingleton<IClmTwoSkillService, ClmTwoSkillManager>();

            services.AddSingleton<IContactDal, EfContactDal>();
            services.AddSingleton<IContactService, ContactManager>();

            services.AddSingleton<IServiceDal, EfServiceDal>();
            services.AddSingleton<IServiceService, ServiceManager>();
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

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
