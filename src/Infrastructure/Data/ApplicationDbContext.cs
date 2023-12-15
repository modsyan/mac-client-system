using System.Reflection;
using MacClientSystem.Application.Common.Interfaces;
using MacClientSystem.Domain.Entities;
using MacClientSystem.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MacClientSystem.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    // public DbSet<TodoList> TodoLists => Set<TodoList>();
    // public DbSet<TodoItem> TodoItems => Set<TodoItem>();
    
    public DbSet<Account> Accounts => Set<Account>();
    public DbSet<LicenseCategory> LicenseCategories => Set<LicenseCategory>();
    public DbSet<LicenseOrder> LicenseOrders => Set<LicenseOrder>();
    public DbSet<TripTickOrder> TripTickOrders => Set<TripTickOrder>();
    public DbSet<UploadedFile> FileUploads => Set<UploadedFile>();
    public DbSet<Country> Countries => Set<Country>();
    public DbSet<City> Cities => Set<City>();
    public DbSet<VehicleType> VehicleTypes => Set<VehicleType>();
    
    public DbSet<IssuedLicense> IssuedLicenses => Set<IssuedLicense>();
    
    public DbSet<ExternalIssuedLicense> ExternalIssuedLicenses => Set<ExternalIssuedLicense>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }

}
