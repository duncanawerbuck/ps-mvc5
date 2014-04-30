using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin.Hosting;
using Owin;

namespace OWINConsoleHost
{
    using AppFunc = Func<IDictionary<string, object>, Task>;

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        var uri = "http://localhost:8082";
    //        using (WebApp.Start<Startup>(uri))
    //        {
    //            Console.WriteLine("Started.");
    //            Console.ReadKey();
    //            Console.WriteLine("Stopping.");

    //        }
    //    }
    //}

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Use(async (environment, next) =>
            {
                // This executes when the request is coming in
                Console.WriteLine("Requesting: " + environment.Request.Path);
                await next();

                // This executes when the response is going out
                Console.WriteLine("Response: " + environment.Response.StatusCode);
            });

            ConfigureWebApi(app);

            app.UseHelloWorld();
        }

        private void ConfigureWebApi(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                "DefaultApiRoute",
                "api/{controller}/{id}",
                new {id = RouteParameter.Optional}
                );

            app.UseWebApi(config);
        }
    }

    public static class AppBuilderExtensions
    {
        public static void UseHelloWorld(this IAppBuilder app)
        {
            app.Use<HellowWorldComponent>();
        }
    }

    public class HellowWorldComponent
    {
        AppFunc _next;

        public HellowWorldComponent(AppFunc next)
        {
            _next = next;
        }

        public Task Invoke(IDictionary<string, object> environment )
        {
            var response = environment["owin.ResponseBody"] as Stream;

            using (var writer = new StreamWriter(response))
            {
                return writer.WriteAsync("Hello!!");
            }
        }
    }
}
