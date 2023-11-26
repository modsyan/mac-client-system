using MacClientSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MacClientSystem.Infrastructure.Data.Configurations;

public class LicenseOrderConfiguration : IEntityTypeConfiguration<LicenseOrder>
{
    public void Configure(EntityTypeBuilder<LicenseOrder> builder)
    {
        builder.HasOne(l => l.Account)
            .WithMany(a => a.LicenseOrders)
            .HasForeignKey(l => l.AccountId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(l => l.PersonalPhoto)
            .WithOne()
            .HasForeignKey<LicenseOrder>(l => l.PersonalPhotoId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(l => l.LocalDrivingLicense)
            .WithOne()
            .HasForeignKey<LicenseOrder>(l => l.LocalDrivingLicenseId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(l => l.PassportImage)
            .WithOne()
            .HasForeignKey<LicenseOrder>(l => l.PassportImageId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(l => l.BloodType)
            .HasConversion<string>();

        builder.Property(l => l.Gander)
            .HasConversion<string>();
        
        builder.Property(l=>l.LicenseType)
            .HasConversion<string>();

        // builder.HasOne(l => l.SourceOfLocalLicense)
        //     .WithMany()
        //     .HasForeignKey(l => l.SourceOfLocalLicenseId)
        //     .OnDelete(DeleteBehavior.Restrict);
    }
}
