using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;
using Owin;

namespace OWINConsoleHost
{
    using AppFunc = Func<IDictionary<string, object>, Task>;

    class Program
    {
        static void Main(string[] args)
        {
            var uri = "http://localhost:8082";
            using (WebApp.Start<Startup>(uri))
            {
                Console.WriteLine("Started.");
                Console.ReadKey();
                Console.WriteLine("Stopping.");

            }
        }
    }

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Use low level custom component instead of app.UserWelcomePage() or app.Run...
            app.Use<HellowWorldComponent>();

            /*
            
            app.UseWelcomePage();

            app.Run(context =>
            {
                context.Response.ContentType = "text/plain";
                return context.Response.WriteAsync("Hello");
            });
            
             */
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
