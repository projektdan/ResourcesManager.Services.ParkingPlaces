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
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Username);

            builder.Property(x => x.Id).HasDefaultValueSql("uuid_generate_v1()");
            builder.Property(x => x.CreatedAt).HasDefaultValueSql("now() at time zone 'utc'").IsRequired();
            builder.Property(x => x.Username)
                .HasConversion(c => c.Value, c => new Username(c))
                .HasMaxLength(Username.MaxLength).IsRequired();
            builder.Property(x => x.Hash).IsRequired();
            builder.Property(x => x.Firstname)
                .HasConversion(c => c.Value, c => new Firstname(c))
                .HasMaxLength(Firstname.MaxLength).IsRequired();
            builder.Property(x => x.Lastname)
                .HasConversion(c => c.Value, c => new Lastname(c))
                .HasMaxLength(Lastname.MaxLength).IsRequired();
            builder.Property(x => x.Email)
                .HasConversion(c => c.Value, c => new Email(c))
                .HasMaxLength(128).IsRequired();
        }
    }
}
