using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace arThek.Services
{
    public class SignalRHub : Hub
    {
        public async Task SendMessage1(string user, string message, string category, string userType, string messageDate)
        {
            await Clients.All.SendAsync("ReceiveOne", user, message, category, userType, messageDate);
        }
    }
}
