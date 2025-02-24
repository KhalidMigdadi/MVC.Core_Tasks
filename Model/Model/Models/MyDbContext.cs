using Microsoft.EntityFrameworkCore;

namespace Model.Models
{
    // database
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) // contrctor
            : base(options)
        { }


        // Represents the "Users" table in the database
        public DbSet<User> Users { get; set; }

        public DbSet<Department> Departments { get; set; }
    }
}
