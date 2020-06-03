using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using System.Reflection;
using IdentityServer.API.Repositories;
using IdentityServer.API.Authentication;
using IdentityServer4.Services;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Identity;
using IdentityServer.API.Repositories.Dtos;

namespace IdentityServer.API.Infrastructure.AutofacModules
{
    public class ApplicationModule: Autofac.Module
    {
       

        

        protected override void Load(ContainerBuilder builder)
        {


            builder.RegisterType<UserRepository>()
                .As<IUserRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<IdentityRepository>()
               .As<IIdentityRepository>()
               .InstancePerLifetimeScope();
                      


            builder.RegisterType<ResoureOwmerPasswordValidator>()
               .As<IResourceOwnerPasswordValidator>()
               .InstancePerLifetimeScope();

            builder.RegisterType<ProfileService>()
               .As<IProfileService>()
               .InstancePerLifetimeScope();

            //builder.RegisterAssemblyTypes(typeof(PatientsDetailsMessageReceivedEventHandler).GetTypeInfo().Assembly)
            //     .AsClosedTypesOf(typeof(IIntegrationEventHandler<>));

            //builder.Register(c => new RegistrationGRPCClientService(GRPCRegistrationURL))
            //    .As<IRegistrationGRPCClientService>()
            //    .InstancePerLifetimeScope();



        }
    }
}
