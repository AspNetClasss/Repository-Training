using HomeTrainingRepository.Models.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace HomeTrainingRepository.Models
{
    public class ProjectDbContext : DbContext
    {

        public ProjectDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Person>? Person { get; set; }
    }
}

