using Autofac;
using FinalTask.ComputerScience.ViewModels;
using System;
using System.Collections.Generic;
using Windows.ApplicationModel.Activation;

namespace FinalTask.ComputerScience
{
    public sealed partial class App
    {
        private IContainer container;

        public App()
        {
            Initialize();
        }

        protected override void Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule<ScenarioModule>();

            container = builder.Build();
        }

        protected override object GetInstance(Type service, string key)
        {
            return key == null
                       ? container.Resolve(service)
                       : container.ResolveNamed(key, service);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            var type = typeof(IEnumerable<>).MakeGenericType(service);

            return container.Resolve(type) as IEnumerable<object>;
        }

        protected override void BuildUp(object instance)
        {
            container.InjectProperties(instance);
        }
        
        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            DisplayRootViewFor<HomeViewModel>();
        }
    }
}