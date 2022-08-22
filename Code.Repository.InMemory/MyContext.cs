using Code.Repository.Model;
using Microsoft.EntityFrameworkCore;

namespace Code.Repository.InMemory
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options)
        : base(options)
        {

        }

        public DbSet<PatternResult> Customers { get; set; }


    }
}