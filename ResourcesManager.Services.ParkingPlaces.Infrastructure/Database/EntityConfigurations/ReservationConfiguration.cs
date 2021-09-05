using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResourcesManager.Services.ParkingPlaces.Core.Domain;

namespace ResourcesManager.Services.ParkingPlaces.Infrastructure.Database.EntityConfigurations
{
    internal class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.ToTable("Reservations");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasDefaultValueSql("uuid_generate_v1()");
            builder.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now() at time zone 'utc'").IsRequired();
            builder.HasOne(e => e.User)
                .WithMany().HasForeignKey(nameof(User) + "Id").IsRequired();
            builder.HasOne(e => e.Resource)
                .WithMany().HasForeignKey(nameof(Resource) + "Id").IsRequired();
            builder.Property(e => e.ResourceQuantity).IsRequired();
            builder.HasOne(e => e.Location)
                .WithMany().HasForeignKey(nameof(Location) + "Id").IsRequired();
            builder.HasOne(e => e.State)
                .WithMany().HasForeignKey(nameof(ReservationState) + "Id").IsRequired();
            builder.Property(e => e.BeginDate).IsRequired();
            builder.Property(e => e.EndDate).IsRequired();


        }
    }
}
