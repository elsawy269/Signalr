using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Hubs;

namespace chat.Hubs
{
    [HubName("chat")]
        [EnableCors("AllowSpecificOrigin")]

    public class ChatHub:Hub
    {
        public void Join()
        {
            Clients.All.join($"{Context.ConnectionId} has joined to room ................");
        }
    }
}
