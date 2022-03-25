using Data.models;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class UMSDatabaseContext : DbContext
{
    public UMSDatabaseContext(DbContextOptions<UMSDatabaseContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
}