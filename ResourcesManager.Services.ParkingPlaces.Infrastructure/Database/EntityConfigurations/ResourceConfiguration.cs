using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResourcesManager.Services.ParkingPlaces.Core.Domain;
using ResourcesManager.Services.ParkingPlaces.Core.Domain.ValueObjects;

namespace ResourcesManager.Services.ParkingPlaces.Infrastructure.Database.EntityConfigurations
{
    internal class ResourceConfiguration : IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> builder)
        {
            builder.ToTable("Resources");
            builder.HasKey(e => e.Id);
            builder.HasIndex(e => e.UniqueResourceIdentifier);

            builder.Property(e => e.Id)
                .HasDefaultValueSql("uuid_generate_v1()");
            builder.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now() at time zone 'utc'").IsRequired();
            builder.Property(e => e.UniqueResourceIdentifier)
                .HasConversion(c => c.Value, c => new UniqueResourceIdentifier(c))
                .HasMaxLength(UniqueResourceIdentifier.MaxLength).IsRequired();
            builder.Property(e => e.Name)
                .HasConversion(c => c.Value, c => new Name(c))
                .HasMaxLength(Name.MaxLength).IsRequired();
        }
    }
}
