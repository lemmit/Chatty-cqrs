using System;
using Autofac;
using Chatty.CQRSToolkit.CommandHandlers;
using Chatty.CQRSToolkit.Interfaces;
using Chatty.Domain;
using Topshelf;
using Topshelf.Autofac;

namespace Chatty.Service
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Create your container
            var builder = new ContainerBuilder();
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            builder.RegisterType<NewChatMessageCommandHandler>()
                .As<ICommandHandler<ICommand>>();


            builder.RegisterType<QueryHandlerService>();
            var container = builder.Build();


            HostFactory.Run(c =>
            {
                c.UseAutofacContainer(container);
                c.Service<QueryHandlerService>(s =>
                {
                    s.ConstructUsingAutofacContainer();
                    s.WhenStarted((service, control) => service.Start());
                    s.WhenStopped((service, control) => service.Stop());
                });
            });
        }
    }
}