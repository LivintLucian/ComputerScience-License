using arThek.ServiceAbstraction;
using Microsoft.AspNetCore.SignalR;
using System.Linq;
using System.Threading.Tasks;

namespace arThek.Services
{
    public class SignalRHub : Hub
    {
        private readonly IFollowService _followService;
        public SignalRHub(IFollowService followService)
        {
            _followService = followService;
        }
        public async Task SendMessage1(string user, string message, string category, string userType, string messageDate)
        {
            await Clients.All.SendAsync("ReceiveOne", user, message, category, userType, messageDate);
        }

        public async Task<string> SendMessage2(string user, string sender, string receiver, string message, string messageDate)
        {
            await Clients.All.SendAsync("ReceiveTwo", user, sender, receiver, message, messageDate);
            return "Recived Data!";
        }

        public async Task<string> SendNotification(string mentorId, string content)
        {
            var followerList = (await _followService.GetAllFollowers()).ToList();
            var menteeListFromFollowers = followerList.Where(x => x.MentorId.ToString().ToLower() == mentorId.ToLower()).Distinct().Select(x => x.MenteeId.ToString()).ToList();

            menteeListFromFollowers.ForEach(async (menteeFollower) =>
            {
                await Clients.All.SendAsync("ReceiveNotification", menteeFollower, content);
            });
            return "Recieved Notification";
        }
    }
}
