using Autofac;
using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Security.Jwt;
using DataAccess.Absract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.Autofac
{
    public class AutoBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EfAboutDal>().As<IAboutDal>();
            builder.RegisterType<AboutManager>().As<IAboutService>();

            builder.RegisterType<ClmOneExperienceManager>().As<IClmOneExperienceService>();
            builder.RegisterType<EfClmOneExperinceDal>().As<IClmOneExperinceDal>();

            builder.RegisterType<EfClmTwoExperienceDal>().As<IClmTwoExperinceDal>();
            builder.RegisterType<ClmTwoExperienceManager>().As<IClmTwoExperinceService>();

            builder.RegisterType<EfClmOneSkillDal>().As<IClmOneSkillDal>();
            builder.RegisterType<ClmOneSkillManager>().As<IClmOneSkillService>();

            builder.RegisterType<EfClmTwoSkillDal>().As<IClmTwoSkillDal>();
            builder.RegisterType<ClmTwoSkillManager>().As<IClmTwoSkillService>();

            builder.RegisterType<EfContactDal>().As<IContactDal>();
            builder.RegisterType<ContactManager>().As<IContactService>();

            builder.RegisterType<EfServiceDal>().As<IServiceDal>();
            builder.RegisterType<ServiceManager>().As<IServiceService>();

            builder.RegisterType<EfUserDal>().As<IUserDal>();
            builder.RegisterType<UserManager>().As<IUserService>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

        }
    }
}
