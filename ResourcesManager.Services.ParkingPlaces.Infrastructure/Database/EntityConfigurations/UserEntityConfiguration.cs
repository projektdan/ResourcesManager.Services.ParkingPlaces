using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResourcesManager.Services.ParkingPlaces.Core.Domain;
using ResourcesManager.Services.ParkingPlaces.Core.Domain.ValueObjects;

namespace ResourcesManager.Services.ParkingPlaces.Infrastructure.Database.EntityConfigurations
{
    internal class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(e => e.Id);
            builder.HasIndex(e => e.Username);

            builder.Property(e => e.Id)
                .HasDefaultValueSql("uuid_generate_v1()");
            builder.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now() at time zone 'utc'").IsRequired();
            builder.Property(e => e.Username)
                .HasConversion(c => c.Value, c => new Username(c))
                .HasMaxLength(Username.MaxLength).IsRequired();
            builder.Property(e => e.Hash).IsRequired();
            builder.Property(e => e.Firstname)
                .HasConversion(c => c.Value, c => new Firstname(c))
                .HasMaxLength(Firstname.MaxLength).IsRequired();
            builder.Property(e => e.Lastname)
                .HasConversion(c => c.Value, c => new Lastname(c))
                .HasMaxLength(Lastname.MaxLength).IsRequired();
            builder.Property(e => e.Email)
                .HasConversion(c => c.Value, c => new Email(c))
                .HasMaxLength(128).IsRequired();
            builder.Property(e => e.Password)
                .HasConversion(c => c.Value, c => new Password(c))
                .IsRequired();
        }
    }
}
