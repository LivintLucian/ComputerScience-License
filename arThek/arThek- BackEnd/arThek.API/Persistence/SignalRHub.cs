using arThek.Entities.Entities;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace arThek.Persistence.API
{
    public class SignalRHub : Hub
    {
        public async Task NewMessage(ChatMessage msg)
        {
            await Clients.All.SendAsync("MessageReceived", msg);
        }
    }
}
