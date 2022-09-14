using DSLabW03CRRUD.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DSLabW03CRRUD.Services;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Person> People => Set<Person>();
}
