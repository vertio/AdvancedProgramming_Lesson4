using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using AdvancedProgramming_Lesson4.Data;
using AdvancedProgramming_Lesson4.Hubs;


//start pipeline that handles client-server communication.
namespace AdvancedProgramming_Lesson4.Hubs
{
    public class ChatHub : Hub
    {
        private readonly ApplicationDbContext _context;
        public ChatHub(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
            var authenticated = Context.User.Identity.IsAuthenticated;

            if (authenticated)
            {
                System.Diagnostics.Debug.WriteLine("tak", Context.User.Identity.Name);
                ChatMessage msg = new ChatMessage();
                msg.UserName = Context.User.Identity.Name;
                msg.Message = message;
                msg.Authorizated = authenticated;
                _context.ChatMessage.Add(msg);
                _context.SaveChanges();
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("nie");
                ChatMessage msg = new ChatMessage();
                msg.UserName = user;
                msg.Message = message;
                msg.Authorizated = authenticated;
                _context.ChatMessage.Add(msg);
                _context.SaveChanges();
            }

        }
    }
}