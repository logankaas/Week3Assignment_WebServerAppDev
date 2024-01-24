using Assignment2_WebServerAppDev.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment2_WebServerAppDev.Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) 
        {
        }

        public DbSet<Hobbies> hobbies { get; set; }
        public DbSet<Person> person { get; set; }
    }
}
