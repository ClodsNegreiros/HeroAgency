namespace HeroAgency.Domain.Entities
{
    public class SuperHeroPower
    {
        public int SuperPowerId { get; set; }
        public SuperPower SuperPower { get; set; }
        public int SuperHeroId { get; set; }
        public SuperHero SuperHero { get; set; }
    }
}
