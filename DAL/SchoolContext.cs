using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DAL;

public class SchoolContext : DbContext
{
    public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<StudentAddress>()
            .HasIndex(sa => sa.StudentId)
            .IsUnique();
    }


    // Entity Sets :
    public DbSet<Student> Students => Set<Student>(); // Entity set for Entity 'Student' ..
    public DbSet<StudentAddress> StudentAddresses => Set<StudentAddress>();
}