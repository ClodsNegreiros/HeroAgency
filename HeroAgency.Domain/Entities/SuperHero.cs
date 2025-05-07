namespace HeroAgency.Domain.Entities
{
    public class SuperHero
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string HeroName { get; set; }
        public DateTime BirthDate { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }

        public List<SuperHeroPower> SuperHeroPowers { get; set; }
    }
}
