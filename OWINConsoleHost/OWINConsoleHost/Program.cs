using System;
using System.Collections.Generic;
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
            using (WebApp.Start<Startup1>(uri))
            {
                Console.WriteLine("Started.");
                Console.ReadKey();
                Console.WriteLine("Stopping.");

            }
        }
    }

    public class Startup1
    {
        public void Configuration(IAppBuilder app)
        {
            app.Run(context =>
            {
                context.Response.ContentType = "text/plain";
                return context.Response.WriteAsync("Hello");
            });
        }
    }
}
