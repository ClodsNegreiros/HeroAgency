namespace HeroAgency.Application.Requests.SuperHero
{
    public class CreateSuperHeroRequest
    {
        public string Name { get; set; }
        public string HeroName { get; set; }
        public DateTime BirthDate { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }

        public List<int> SuperHeroPowersIds { get; set; }
    }
}
