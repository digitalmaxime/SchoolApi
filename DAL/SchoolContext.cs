using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DAL;

public class SchoolContext : DbContext
{
    public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
    {
    }
    
     // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
     // {
     //     optionsBuilder.UseMySQL("Server=localhost;Port=3306;Uid=root;Database=School;Pwd=Alpha&Omega1*;SSL Mode=None");
     // }


    // Entity Sets :
    public DbSet<Student> Students => Set<Student>(); // Entity set for Entity 'Student' ..
}