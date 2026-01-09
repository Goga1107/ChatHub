using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using WebApplication8SignalR.Data;

namespace WebApplication8SignalR.Models
{
    public class ChatHub : Hub
    {
        private ApplicationDbContext _context;
        public ChatHub(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task SendMessage(string user, string message)
        {
            var msg = new ChatMessage
            {
                UserName = user,
                Message = message,
                SentAt = DateTime.UtcNow,
            };
            _context.ChatMessages.Add(msg);
          await  _context.SaveChangesAsync();
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
        public async Task<List<ChatMessage>> GetMessageHistory()
        {
            return await _context.ChatMessages
                .OrderBy(m => m.SentAt)
                .Take(50)
                .ToListAsync();
        }
    }
}
