using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using HeroAgency.Domain.Entities;

namespace HeroAgency.Infrastructure.Mappings
{
    public class SuperHeroPowerMapping : IEntityTypeConfiguration<SuperHeroPower>
    {
        public void Configure(EntityTypeBuilder<SuperHeroPower> builder)
        {
            builder.ToTable("SuperHeroPowers");

            builder.HasKey(shp => new { shp.SuperHeroId, shp.SuperPowerId });

            builder
                .HasOne(shp => shp.SuperHero)
                .WithMany(sh => sh.SuperHeroPowers)
                .HasForeignKey(shp => shp.SuperHeroId);

            builder
                .HasOne(shp => shp.SuperPower)
                .WithMany(sp => sp.SuperHeroPowers)
                .HasForeignKey(shp => shp.SuperPowerId);
        }
    }
}
