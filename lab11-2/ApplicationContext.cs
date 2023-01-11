using Microsoft.EntityFrameworkCore;

namespace lab11_2;

public class ApplicationContext: DbContext
{
    public DbSet<Region> Region { get; set; }

    public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options)
    {
        Database.EnsureCreated();
    }
    
}