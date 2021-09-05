using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using ResourcesManager.Services.ParkingPlaces.Core.Domain;
using ResourcesManager.Services.ParkingPlaces.Core.Domain.ValueObjects;
using System.Collections.Generic;
using System.Linq;

namespace ResourcesManager.Services.ParkingPlaces.Infrastructure.Database.EntityConfigurations
{
    internal class LocationEntityConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.ToTable("Locations");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasDefaultValueSql("uuid_generate_v1()");
            builder.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now() at time zone 'utc'").IsRequired();
            builder.Property(e => e.Name)
                .HasConversion(c => c.Value, c => new Name(c))
                .HasMaxLength(Name.MaxLength).IsRequired();
            builder.Property(e => e.Address)
                .HasConversion(c => c.Value, c => new Address(c))
                .HasMaxLength(Address.MaxLength).IsRequired();

            builder.Property(e => e.Resources)
                //.HasColumnType("jsonb")
                .HasConversion(
                    x => JsonConvert.SerializeObject(x),
                    x => x == null
                        ? new Dictionary<Resource, int>()
                        : JsonConvert.DeserializeObject<Dictionary<Resource, int>>(x)
                );
        }
    }
}
