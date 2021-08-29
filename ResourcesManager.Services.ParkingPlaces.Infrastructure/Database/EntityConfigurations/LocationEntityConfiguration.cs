using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResourcesManager.Services.ParkingPlaces.Core.Domain;

namespace ResourcesManager.Services.ParkingPlaces.Infrastructure.Database.EntityConfigurations
{
    internal class LocationEntityConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.ToTable("Locations");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasDefaultValueSql("uuid_generate_v1()");
            builder.Property(x => x.CreatedAt).HasDefaultValueSql("now() at time zone 'utc'").IsRequired();
            builder.Property(x => x.Address).HasMaxLength(128).IsRequired();


            builder.HasOne(x => x.Resources).WithMany().HasForeignKey("ResourceId").IsRequired();
        }
    }
}
