using Code.Repository.Model;
using Microsoft.EntityFrameworkCore;

namespace Code.Repository.SqlLite
{
    public class MyContext : DbContext
    {

        public DbSet<ResultEntity> ResultEntity { get; set; }

        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=..\InterviewDB.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ResultEntity>().ToTable("ResultEntity");
        }
    }
}