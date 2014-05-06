using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using PerfSerf.Counters;

namespace PerfSerf.Hubs
{
    public class PerfHub : Hub
    {
        public PerfHub()
        {
            StartCounterCollection();
        }

        private void StartCounterCollection()
        {
            var task = Task.Factory.StartNew(async () =>
            {
                var perfService = new PerfCounterService();
                while (true)
                {
                    var results = perfService.GetResults();
                    Clients.All.newCounters(results);
                    await Task.Delay(2000);
                }
            }, TaskCreationOptions.LongRunning);
        }

        public void Send(string message)
        {
            var userName = Context.User.Identity.Name;

            Clients.All.newMessage(userName + " says " + message);
        }
    }
}