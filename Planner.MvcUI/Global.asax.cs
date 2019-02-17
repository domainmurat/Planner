using Autofac;
using Autofac.Integration.Mvc;
using Planner.Business.Abstract;
using Planner.Business.Concrete;
using Planner.DataAccess.Concrete;
using Planner.DataAccess.Context;
using Planner.DataAccess.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Planner.MvcUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // MVC setup documentation here:
            // https://autofac.readthedocs.io/en/latest/integration/mvc.html
            // WCF setup documentation here:
            // https://autofac.readthedocs.io/en/latest/integration/wcf.html
            //
            // First we'll register the MVC/WCF stuff...
            var builder = new ContainerBuilder();

            // MVC - Register your MVC controllers.
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            //// MVC - OPTIONAL: Register model binders that require DI.
            //builder.RegisterModelBinders(typeof(MvcApplication).Assembly);
            //builder.RegisterModelBinderProvider();

            //// MVC - OPTIONAL: Register web abstractions like HttpContextBase.
            //builder.RegisterModule<AutofacWebTypesModule>();

            //// MVC - OPTIONAL: Enable property injection in view pages.
            //builder.RegisterSource(new ViewRegistrationSource());

            //// MVC - OPTIONAL: Enable property injection into action filters.
            //builder.RegisterFilterProvider();

            //// WCF - Register channel factory and channel for service clients.
            //builder
            //  .Register(c => new ChannelFactory<IService>("BasicHttpBinding_IService"))
            //  .SingleInstance();
            //builder
            //  .Register(c => c.Resolve<ChannelFactory<IService>>().CreateChannel())
            //  .As<IService>()
            //  .UseWcfSafeRelease();

            // Register application dependencies.
            builder.RegisterType<SubjectManager>().As<ISubjcetService>()
                .WithParameter(new TypedParameter(typeof(PlannerContext), new PlannerContext()))
                .WithParameter(new TypedParameter(typeof(ISubjectRepository), new SubjectRepository(new PlannerContext())));
            

            // MVC - Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
