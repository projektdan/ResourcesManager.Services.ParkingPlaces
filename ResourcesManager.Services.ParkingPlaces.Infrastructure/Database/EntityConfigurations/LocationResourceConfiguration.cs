using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResourcesManager.Services.ParkingPlaces.Core.Domain;
using ResourcesManager.Services.ParkingPlaces.Core.Domain.ValueObjects;

namespace ResourcesManager.Services.ParkingPlaces.Infrastructure.Database.EntityConfigurations
{
    internal class LocationResourceConfiguration : IEntityTypeConfiguration<LocationResource>
    {
        public void Configure(EntityTypeBuilder<LocationResource> builder)
        {
            builder.ToTable("LocationResources");
            builder.HasKey(e => e.Id);
            builder.HasAlternateKey("LocationId", "ResourceId");

            builder.Property(e => e.Id)
                .HasDefaultValueSql("uuid_generate_v1()");
            builder.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now() at time zone 'utc'").IsRequired();
            builder.Property(e => e.ResourceQuantity)
                .HasConversion(x => x.Value, x => new ResourceQuantity(x));

            builder.HasOne(e => e.Location).WithMany(e => e.Resources).HasForeignKey("LocationId").IsRequired();
            builder.HasOne(e => e.Resource).WithMany().HasForeignKey("ResourceId").IsRequired();
        }
    }
}
