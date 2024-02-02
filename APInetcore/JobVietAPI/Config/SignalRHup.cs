using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace JobVietAPI.Config
{
    public class SignalRHup : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
