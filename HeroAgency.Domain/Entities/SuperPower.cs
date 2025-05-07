namespace HeroAgency.Domain.Entities
{
    public class SuperPower
    {
        public int Id { get; set; }
        public string Power { get; set; }
        public string Description { get; set; }
        public List<SuperHeroPower> SuperHeroPowers { get; set; }
    }
}
