using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DAL;

public class SchoolContext : DbContext
{
    public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
    {
    }

    // Entity Sets :
    public DbSet<Student> Students => Set<Student>(); // Entity set for Entity 'Student' ..
}