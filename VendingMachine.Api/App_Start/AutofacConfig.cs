using System;
using Autofac;
using Autofac.Integration.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VendingMachine.Services;
using VendingMachine.Data.Contracts;
using VendingMachine.Data.Repositories;
using System.Web.Mvc;
using VendingMachine.Data.Entities;
using VendingMachine.Models;
using VendingMachine.Models.enums;
using System.Reflection;
using Autofac.Integration.WebApi;
using System.Web.Http;

namespace VendingMachine.Api
{
    public static class AutofacConfig
    {
        
        public static void Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(WebApiApplication).Assembly);


            //builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));
           

            builder.RegisterType<DrinkCanService>().As<IDrinkCanService>().InstancePerLifetimeScope();
            builder.RegisterType<PaymentService>().As<IPaymentService>().InstancePerLifetimeScope();
            builder.RegisterType<MachineSerivce>().As<IMachineService>().InstancePerLifetimeScope();

            builder.RegisterInstance(DrinkCanRepository.Database).As<IDrinkCanRepository>().SingleInstance();
            builder.RegisterInstance(PaymentRepository.Database).As<IPaymentRepository>().SingleInstance();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterWebApiFilterProvider(GlobalConfiguration.Configuration);

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver =
                new AutofacWebApiDependencyResolver(container);

            //Demo Data
            Seed();
        }

        private static void Seed()
        {
            
            DrinkCanRepository.Database.Add(new DrinkCan()
            {
                Flavour = Flavour.Pineapple,
                Price = 2.50m,
                IsSold = false
            });


            DrinkCanRepository.Database.Add(new DrinkCan()
            {
                Flavour = Flavour.Pineapple,
                Price = 2.50m,
                IsSold = false
            });


            DrinkCanRepository.Database.Add(new DrinkCan()
            {
                Flavour = Flavour.Pineapple,
                Price = 2.50m,
                IsSold = false
            });


            DrinkCanRepository.Database.Add(new DrinkCan()
            {
                Flavour = Flavour.Apple,
                Price = 1.50m,
                IsSold = false
            });

            DrinkCanRepository.Database.Add(new DrinkCan()
            {
                Flavour = Flavour.Apple,
                Price = 1.50m,
                IsSold = false
            });


            DrinkCanRepository.Database.Add(new DrinkCan()
            {
                Flavour = Flavour.Banana,
                Price = 2.50m,
                IsSold = false
            });

            DrinkCanRepository.Database.Add(new DrinkCan()
            {
                Flavour = Flavour.Fruity,
                Price = 2.50m,
                IsSold = false
            });

            DrinkCanRepository.Database.Add(new DrinkCan()
            {
                Flavour = Flavour.Fruity,
                Price = 2.50m,
                IsSold = false
            });

            DrinkCanRepository.Database.Add(new DrinkCan()
            {
                Flavour = Flavour.Fruity,
                Price = 2.50m,
                IsSold = false
            });

            DrinkCanRepository.Database.Add(new DrinkCan()
            {
                Flavour = Flavour.Fruity,
                Price = 2.50m,
                IsSold = false
            });

            DrinkCanRepository.Database.Add(new DrinkCan()
            {
                Flavour = Flavour.Grape,
                Price = 3.50m,
                IsSold = false
            });

            DrinkCanRepository.Database.Add(new DrinkCan()
            {
                Flavour = Flavour.Grape,
                Price = 3.50m,
                IsSold = false
            });

            DrinkCanRepository.Database.Add(new DrinkCan()
            {
                Flavour = Flavour.Grape,
                Price = 3.50m,
                IsSold = false

            });

            DrinkCanRepository.Database.Add(new DrinkCan()
            {
                Flavour = Flavour.Orange,
                Price = 2.50m,
                IsSold = false
            });

            DrinkCanRepository.Database.Add(new DrinkCan()
            {
                Flavour = Flavour.Pear,
                Price = 2.50m
            });

            DrinkCanRepository.Database.Add(new DrinkCan()
            {
                Flavour = Flavour.Sugar,
                Price = 0.65m,
                IsSold = false
            });

            DrinkCanRepository.Database.Add(new DrinkCan()
            {
                Flavour = Flavour.Sugar,
                Price = 0.65m,
                IsSold = false
            });

            DrinkCanRepository.Database.Add(new DrinkCan()
            {
                Flavour = Flavour.Vanilla,
                Price = 1.35m,
                IsSold = false
            });

            DrinkCanRepository.Database.Add(new DrinkCan()
            {
                Flavour = Flavour.Vanilla,
                Price = 1.35m,
                IsSold = false
            });


            DrinkCanRepository.Database.Add(new DrinkCan()
            {
                Flavour = Flavour.Wintergreen,
                Price = 2.00m,
                IsSold = false
            });

            DrinkCanRepository.Database.Add(new DrinkCan()
            {
                Flavour = Flavour.Wintergreen,
                Price = 2.00m,
                IsSold = false
            });

        }
    }
}