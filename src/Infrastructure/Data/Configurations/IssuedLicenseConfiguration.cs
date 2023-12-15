using MacClientSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MacClientSystem.Infrastructure.Data.Configurations;

public class IssuedLicenseConfiguration: IEntityTypeConfiguration<IssuedLicense>
{
    public void Configure(EntityTypeBuilder<IssuedLicense> builder)
    {
        builder.HasOne(i=>i.LicenseOrder)
            .WithOne()
            .HasForeignKey<IssuedLicense>(i=>i.LicenseOrderId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(i => i.UploadedFile)
            .WithOne()
            .HasForeignKey<IssuedLicense>(i => i.UploadedFileId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }
}
