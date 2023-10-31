using ExamenORM.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamenORM.Data
{
    public class LoginContext : DbContext
    {
        public LoginContext(DbContextOptions options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Habit> Habits{get;set;}
        public DbSet<Category> Categories{get;set;}
        public DbSet<Like> Likes{get;set;}
    }
}
