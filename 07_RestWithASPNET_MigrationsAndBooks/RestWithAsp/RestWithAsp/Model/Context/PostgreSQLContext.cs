using Microsoft.EntityFrameworkCore;
using RestWithAsp.Model;

namespace RestWithASPNETUdemy.Model.Context
{
    public class PostgreSQLContext : DbContext
    {
        public PostgreSQLContext()
        {

        }
        public PostgreSQLContext(DbContextOptions<PostgreSQLContext> options) : base(options) { }

        public DbSet<Person> Persons {get; set;}

        public DbSet<Book> Books { get; set; }

    }
}
