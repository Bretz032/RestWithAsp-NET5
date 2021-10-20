using Microsoft.EntityFrameworkCore;
using RestWithAsp.Model;

namespace RestWithASP.Model.Context
{
    public class PostgreSQLContext : DbContext
    {
        public PostgreSQLContext()
        {

        }
        public PostgreSQLContext(DbContextOptions<PostgreSQLContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }

        public DbSet<Person> Persons {get; set;}

        public DbSet<User> Users { get; set; }

    }
}
