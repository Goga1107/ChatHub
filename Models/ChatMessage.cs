namespace WebApplication8SignalR.Models
{
    public class ChatMessage
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Message { get; set; }
        public DateTime SentAt { get; set; } = DateTime.Now;
    }
}
