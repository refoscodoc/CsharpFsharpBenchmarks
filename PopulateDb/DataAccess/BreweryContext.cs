using CSharp.Models;

namespace PopulateDb.DataAccess;
using Microsoft.EntityFrameworkCore;

public class BreweryContext : DbContext
{
    public BreweryContext(DbContextOptions<BreweryContext> options) : base(options) {}
    
    public DbSet<BreweryModel> BreweriesTable { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<BreweryModel>().HasKey(m => m.Id);

        base.OnModelCreating(builder);
    }
}