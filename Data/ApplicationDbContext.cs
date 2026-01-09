using Microsoft.EntityFrameworkCore;
using WebApplication8SignalR.Models;

namespace WebApplication8SignalR.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        } 
        public DbSet<ChatMessage> ChatMessages { get; set; } 
    }
}
