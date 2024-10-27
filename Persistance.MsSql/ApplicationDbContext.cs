using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistance.MsSql;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        var entries = 
            ChangeTracker.Entries<BaseEntity>()
                .Where(e => e.State is EntityState.Modified)
                .ToList();
        
        foreach (var entityEntry in entries)
        {
            entityEntry.Entity.Updated = DateTime.Now;
        }
        
        return await base.SaveChangesAsync(cancellationToken);
    }
}