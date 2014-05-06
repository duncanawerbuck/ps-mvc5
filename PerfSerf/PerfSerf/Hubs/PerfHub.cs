﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace PerfSerf.Hubs
{
    public class PerfHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello("Hi!");
        }
    }
}