using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using HeroAgency.Domain.Entities;

namespace HeroAgency.Infrastructure.Mappings
{
    public class SuperHeroMapping : IEntityTypeConfiguration<SuperHero>
    {
        public void Configure(EntityTypeBuilder<SuperHero> builder)
        {
            builder.ToTable("SuperHeroes");
            builder.HasKey(sh => sh.Id);

            builder.Property(sh => sh.Id);
            builder.Property(sh => sh.Name);
            builder.Property(sh => sh.HeroName);
            builder.Property(sh => sh.BirthDate);
            builder.Property(sh => sh.Height);
            builder.Property(sh => sh.Weight);

            builder
                .HasMany(sh => sh.SuperHeroPowers)
                .WithOne(shp => shp.SuperHero)
                .HasForeignKey(shp => shp.SuperHeroId);
        }
    }
}
