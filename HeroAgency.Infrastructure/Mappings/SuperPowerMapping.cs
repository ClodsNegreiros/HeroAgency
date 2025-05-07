using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using HeroAgency.Domain.Entities;

namespace HeroAgency.Infrastructure.Mappings
{
    public class SuperPowerMapping : IEntityTypeConfiguration<SuperPower>
    {
        public void Configure(EntityTypeBuilder<SuperPower> builder)
        {
            builder.ToTable("SuperPowers");
            builder.HasKey(sp => sp.Id);

            builder.Property(sp => sp.Id);
            builder.Property(sp => sp.Power);
            builder.Property(sp => sp.Description);

            builder
                .HasMany(sp => sp.SuperHeroPowers)
                .WithOne(shp => shp.SuperPower)
                .HasForeignKey(shp => shp.SuperPowerId);

        }
    }
}
