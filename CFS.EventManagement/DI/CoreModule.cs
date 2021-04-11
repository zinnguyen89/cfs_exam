using Autofac;
using CFS.Common.BusinessRules;
using CFS.Common.CQRS.Command;
using CFS.Common.CQRS.Query;
using CFS.EventManagement.Context;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CFS.EventManagement.DI
{
    public class CoreModule : Autofac.Module
    {
        private IConfiguration _configuration;

        public CoreModule(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            var assemblies = new[]
            {
                typeof(Startup).Assembly,
                Assembly.GetCallingAssembly()
            };
            var commonAssemblies = new[]
            {
                typeof(QueryExecutor).Assembly,
                Assembly.GetCallingAssembly()
            };
            var asses = assemblies.Concat(commonAssemblies);
            RegisterBusinessRule(builder, asses);
            RegisterQueryHandlers(builder, asses);
            RegisterCommandHandler(builder, asses);
            RegisterCommon(builder);
        }



        public void RegisterQueryHandlers(ContainerBuilder builder, IEnumerable<Assembly> assemblies)
        {
            var queryHandlers =
                assemblies.SelectMany(s => s.GetTypes().Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IQueryHandler<,>)))).ToArray();

            builder.RegisterTypes(queryHandlers).AsImplementedInterfaces();
            builder.RegisterType<QueryExecutor>().As<IQueryExecutor>();
        }

        public void RegisterCommandHandler(ContainerBuilder builder, IEnumerable<Assembly> assemblies)
        {
            var commandHandlers =
                assemblies.SelectMany(s => s.GetTypes().Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ICommandHandler<,>)))).ToArray();

            builder.RegisterTypes(commandHandlers).AsImplementedInterfaces();
            builder.RegisterType<CommandExecutor>().As<ICommandExecutor>();
        }

        public void RegisterBusinessRule(ContainerBuilder builder, IEnumerable<Assembly> assemblies)
        {
            var businessRules =
                assemblies.SelectMany(s => s.GetTypes().Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IBusinessRule<>)))).ToArray();

            builder.RegisterTypes(businessRules);
        }



        public void RegisterCommon(ContainerBuilder builder)
        {


            builder.RegisterType<CfsApiContext>().As<ICfsApiContext>().InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(BusinessRuleSet<>)).As(typeof(IBusinessRuleSet<>));
            #region Query



            #endregion Query
        }
    }
}
