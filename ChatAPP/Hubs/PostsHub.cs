using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Cors;

namespace ChatAPP.Hubs
{
    [EnableCors("AllowSpecificOrigin")]

    public class PostsHub : Hub
    {
        public void HelloServer()
        {
            Clients.All.hello("Hello message to all clients");
        }
    }
}


