using DataBaseWorkingLib.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBaseWorkingLib.Context
{
    public class ContentTableContext : DbContext
    {
        public DbSet<ContentTable> Translations { get; set; }
        public ContentTableContext(DbContextOptions<ContentTableContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContentTable>();
        }
    }
}
