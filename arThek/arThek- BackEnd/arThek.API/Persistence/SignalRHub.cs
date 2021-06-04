using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace arThek.Services
{
    public class SignalRHub : Hub
    {
        public async Task SendMessage1(string user, string message, string category, string userType, string messageDate)
        {
            await Clients.All.SendAsync("ReceiveOne", user, message, category, userType, messageDate);
        }

        public async Task<string> SendMessage2(string user, string sender, string receiver, string message, string messageDate)
        {
            await Clients.All.SendAsync("ReceiveTwo", user, sender, receiver, message, messageDate);
            return "Recived Data!";
        }
    }
}
