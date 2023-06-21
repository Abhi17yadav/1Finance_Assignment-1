using Assignment_1.Models;
using Assignment_1.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace Assignment_1.Context
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoginVM>().HasNoKey();
        }
        public DbSet<Category> categories { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Register> registers { get; set; }
        public DbSet<Assignment_1.Models.DTO.LoginVM>? LoginVM { get; set; }
    }
}
