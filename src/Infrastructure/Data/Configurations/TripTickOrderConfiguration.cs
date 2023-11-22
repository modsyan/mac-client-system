using MacClientSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MacClientSystem.Infrastructure.Data.Configurations;

public class TripTickOrderConfiguration: IEntityTypeConfiguration<TripTickOrder>
{
    public void Configure(EntityTypeBuilder<TripTickOrder> builder)
    {
        builder.HasOne(t => t.Account)
            .WithMany(a => a.TripTickOrders)
            .HasForeignKey(l => l.AccountId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(t=>t.VehicleRegistrationCopyDocument)
            .WithOne()
            .HasForeignKey<TripTickOrder>(t => t.VehicleRegistrationCopyDocumentId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(t=>t.PassportDocument)
            .WithOne()
            .HasForeignKey<TripTickOrder>(t => t.PassportDocumentId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(t=>t.PersonalGovernmentalIdentityDocument)
            .WithOne()
            .HasForeignKey<TripTickOrder>(t => t.PersonalGovernmentalIdentityDocumentId)
            .OnDelete(DeleteBehavior.Restrict);
        
        
        builder.Property(t=>t.VehiclePrice)
            .HasColumnType("decimal(18,2)");

        builder.Property(t => t.VehicleLicenseType)
            .HasConversion<string>();
        
        builder.Property(t => t.CurrencyType)
            .HasConversion<string>();

        builder.Property(t => t.UpholsteryType)
            .HasConversion<string>();
        
        // builder.HasOne(t=>t.ResidenceCountry)
        //     .WithMany()
        //     .HasForeignKey(t => t.ResidenceCountryId)
        //     .OnDelete(DeleteBehavior.Restrict);
        //
        // builder.HasOne(t=>t.Nationality)
        //     .WithMany()
        //     .HasForeignKey(t => t.NationalityId)
        //     .OnDelete(DeleteBehavior.Restrict);
        //
        // builder.HasOne(t=>t.VehicleRegistrationCountry)
        //     .WithMany()
        //     .HasForeignKey(t => t.VehicleRegistrationCountryId)
        //     .OnDelete(DeleteBehavior.Restrict);
    }
}
