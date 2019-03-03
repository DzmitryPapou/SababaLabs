using Autofac;
using Caliburn.Micro;
using FinalTask.ComputerScience.Logic.Facebook;
using FinalTask.ComputerScience.Logic.Interfaces;
using FinalTask.ComputerScience.Models;

namespace FinalTask.ComputerScience
{
    public class ScenarioModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(ThisAssembly)
                   .AssignableTo<Screen>()
                   .AsSelf();
            builder.RegisterType<FacebookSocialNetwork>().As<IAuthenticateService>();
            builder.RegisterType<FacebookFriends>().As<IFacebookFriends>();
            builder.RegisterType<FacebookMusic>().As<IFacebookMusic>();
            builder.RegisterType<RestClient>().As<IRestClient>();
            builder.RegisterType<LocalSettings>().AsSelf().SingleInstance();
            builder.RegisterType<FacebookSession>().AsSelf().SingleInstance();
        }
    }
}
