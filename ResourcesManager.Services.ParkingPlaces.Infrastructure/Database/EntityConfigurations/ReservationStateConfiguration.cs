using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResourcesManager.Services.ParkingPlaces.Core.Domain;
using ResourcesManager.Services.ParkingPlaces.Core.Domain.ValueObjects;

namespace ResourcesManager.Services.ParkingPlaces.Infrastructure.Database.EntityConfigurations
{
    internal class ReservationStateConfiguration : IEntityTypeConfiguration<ReservationState>
    {
        public void Configure(EntityTypeBuilder<ReservationState> builder)
        {
            builder.ToTable("ReservationStates");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasDefaultValueSql("uuid_generate_v1()");
            builder.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now() at time zone 'utc'").IsRequired();
            builder.Property(e => e.Name)
                .HasConversion(c => c.Value, c => new Name(c))
                .HasMaxLength(Name.MaxLength).IsRequired();
        }
    }
}
