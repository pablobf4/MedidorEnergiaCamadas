﻿using MedidorEnergia.IOC;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Advanced;
using SimpleInjector.Integration.Web.Mvc;
using WebActivator;
using MedidorEnergia.App_Start;




[assembly: PostApplicationStartMethod(typeof(SimpleInjectorInitializer), "Initialize")]
namespace MedidorEnergia.App_Start
{
    public static class SimpleInjectorInitializer
    {
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            // Chamada dos módulos do Simple Injector
            InitializeContainer(container);

            // Necessário para registrar o ambiente do Owin que é dependência do Identity
            // Feito fora da camada de IoC para não levar o System.Web para fora
            container.Register(() =>
            {
                if (HttpContext.Current != null && HttpContext.Current.Items["owin.Environment"] == null && container.IsVerifying())
                {
                    return new OwinContext().Authentication;
                }
                return HttpContext.Current.GetOwinContext().Authentication;

            }, Lifestyle.Scoped);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }

        private static void InitializeContainer(Container container)
        {
            BootStrapper.RegisterServices(container);
        }
    }
}