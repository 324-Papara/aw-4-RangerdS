using Autofac;
using AutoMapper;
using MediatR;
using Microsoft.Data.SqlClient;
using Pa.Api.MiddleWares;
using Pa.Api.Services;
using Pa.Business.Command.FactoryPhoneCommand;
using Pa.Business.MapperConfig;
using Pa.Data.DapperRepository;
using Pa.Data.UnitOfWork;
using System.Data;

namespace Pa.Api.Dependencies
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Register LogService as a singleton
            builder.RegisterType<LogService>().AsSelf().SingleInstance();

            // Register ErrorHandlerMiddleware
            builder.RegisterType<ErrorHandlerMiddleware>().AsSelf();

            // Register MediatR
            builder.RegisterAssemblyTypes(typeof(IMediator).Assembly).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(typeof(DeleteFactoryPhoneCommandHandler).Assembly).AsClosedTypesOf(typeof(IRequestHandler<,>));
            builder.Register<Func<Type, object>>(context =>
            {
                var c = context.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });

            // Register IUnitOfWork
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();

            // Register AutoMapper
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MapperConfig());
            });
            builder.RegisterInstance(config.CreateMapper()).As<IMapper>().SingleInstance();

            // Register Dapper IDbConnection
            builder.Register<IDbConnection>(c =>
            {
                var connectionString = c.Resolve<IConfiguration>().GetConnectionString("MsSqlConStr");
                return new SqlConnection(connectionString);
            }).InstancePerLifetimeScope();

            // Register FactoryRepository
            builder.RegisterType<FactoryRepository>().AsSelf().InstancePerLifetimeScope();
        }
    }
}
