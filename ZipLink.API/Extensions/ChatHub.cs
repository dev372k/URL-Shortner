using Microsoft.AspNetCore.SignalR;

namespace ZipLink.API.Extensions
{
    public sealed class ChatHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("RecieveMessage", $"{Context.ConnectionId} is connected.");
        }
    }
}
