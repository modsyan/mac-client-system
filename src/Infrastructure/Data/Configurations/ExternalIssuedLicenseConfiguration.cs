using MacClientSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MacClientSystem.Infrastructure.Data.Configurations;

public class ExternalIssuedLicenseConfiguration: IEntityTypeConfiguration<ExternalIssuedLicense>
{
    public void Configure(EntityTypeBuilder<ExternalIssuedLicense> builder)
    {
        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(e => e.Serial).IsRequired();
        builder.Property(e => e.Issued).IsRequired();
        builder.Property(e => e.ExpiryDate).IsRequired();
        builder.Property(e => e.UserId).IsRequired();
        builder.Property(e => e.AccountId).IsRequired();

        builder.HasOne(e => e.LicenseImagePath)
            .WithOne()
            .IsRequired()
            .HasForeignKey<ExternalIssuedLicense>(e => e.LicenseImagePathId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
