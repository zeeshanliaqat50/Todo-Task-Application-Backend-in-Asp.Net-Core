using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TodoAppBackend.Models;

namespace TodoAppBackend.Data
{
    public class TodoAppContext : IdentityDbContext<ApplicationUser>
    {
        public TodoAppContext(DbContextOptions<TodoAppContext> options) : base(options)
        {

        }
        public DbSet<Tasks> Tasks { get; set; }


       /* 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsbuilder)
        {
            optionsbuilder.UseSqlServer("connectionstring");
            base.OnConfiguring(optionsbuilder);
        } */
        /*
         * 
         * migration commands in package console manager
         * 1. add-migration init
         * 2. update-database
         */
    }
}
