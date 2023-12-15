using System.ComponentModel;
using MacClientSystem.Application.Common.Models;
using MacClientSystem.Domain.Entities;

namespace MacClientSystem.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    // DbSet<TodoList> TodoLists { get; }

    // DbSet<TodoItem> TodoItems { get; }

    DbSet<Account> Accounts { get; } 
    DbSet<LicenseCategory> LicenseCategories { get; }

    DbSet<LicenseOrder> LicenseOrders { get; }
    DbSet<TripTickOrder> TripTickOrders { get; }
    
    DbSet<UploadedFile> FileUploads { get; }
    DbSet<Country> Countries { get; }
    DbSet<City> Cities { get; }
    DbSet<VehicleType> VehicleTypes { get; }
    
    public DbSet<IssuedLicense> IssuedLicenses { get;}
    
    public DbSet<ExternalIssuedLicense> ExternalIssuedLicenses { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
