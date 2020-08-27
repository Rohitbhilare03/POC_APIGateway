using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Ordering.API.RabbitMQ;
using Microsoft.Extensions.DependencyInjection;

namespace Ordering.API.Extentions
{
    public static class ApplicationBuilderExtention
    {
        public static EventBusRabbitMQConsumer Listner { get; set; }

        public static IApplicationBuilder UseRabbitLister(this IApplicationBuilder app)
        {
            Listner = app.ApplicationServices.GetService<EventBusRabbitMQConsumer>();
            var life = app.ApplicationServices.GetService<IHostApplicationLifetime>();

            life.ApplicationStarted.Register(OnStarted);
            life.ApplicationStopped.Register(OnStopping);

            return app;
        }

        public static void OnStarted()
        {
            Listner.Consume();
        }

        public static void OnStopping()
        {
            Listner.Disconnect();
        }
    }
}
