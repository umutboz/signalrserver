using Microsoft.AspNetCore.SignalR;

namespace ChatSample.Hubs
{
    public class ChatHub : Hub
    {
        public void Send(string name, string message)
        {
            // Call the broadcastMessage method to update clients.
            Clients.All.SendAsync("broadcastMessage", name, "from server " +message );
        }


        public void SayHello(string name)
        {
            Clients.All.SendAsync("listenHello", "Hoşgeldin " + name  +
         " con id " + Context.ConnectionId);
        }
    }
}