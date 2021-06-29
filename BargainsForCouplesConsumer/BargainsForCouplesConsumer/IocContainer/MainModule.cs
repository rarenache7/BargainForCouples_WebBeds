using Autofac;
using BargainsForCouplesConsumer.Interfaces;
using BargainsForCouplesConsumer.Services;

namespace BargainsForCouplesConsumer.IocContainer
{
    public class MainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ConsumerService>().As<IConsumerService>()
                .InstancePerRequest();
        }
    }
}