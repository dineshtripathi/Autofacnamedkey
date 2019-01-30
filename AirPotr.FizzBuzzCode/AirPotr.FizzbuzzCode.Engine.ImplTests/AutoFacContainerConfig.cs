using AirPotr.FizzbuzzCode.Engine.Impl;
using AirPotr.FizzbuzzCode.Engine.Interface;
using Autofac;

namespace AirPotr.FizzbuzzCode.Engine.ImplTests
{
    public static class AutoFacContainerConfig
    {
        public static ILifetimeScope RegisterLifetimeScope()
        {
            var builder = new ContainerBuilder();
            RegisterTypeWithContrainer(builder);
            ILifetimeScope containerLifetimeScope = builder.Build();
            return containerLifetimeScope;
        }

        private static void RegisterTypeWithContrainer(ContainerBuilder builder)
        {
            builder.RegisterType<FizzBuzzScenarioOne>().As<IProvideFizzBuzz>().InstancePerLifetimeScope().Named<IProvideFizzBuzz>("ScenarioOne").PropertiesAutowired();
            builder.RegisterType<FizzBuzzScenarioTwo>().As<IProvideFizzBuzz>().InstancePerLifetimeScope().Named<IProvideFizzBuzz>("ScenarioTwo").PropertiesAutowired();
            builder.RegisterType<FizzBuzzScenarioThree>().As<IProvideFizzBuzz>().InstancePerLifetimeScope().Named<IProvideFizzBuzz>("ScenarioThree").PropertiesAutowired();

        }
    }
}