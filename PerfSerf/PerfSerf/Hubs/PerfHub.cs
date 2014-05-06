using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace PerfSerf.Hubs
{
    public class PerfHub : Hub
    {
        public void Send(string message)
        {
            var userName = Context.User.Identity.Name;

            Clients.All.newMessage(userName + " says " + message);
        }
    }
}