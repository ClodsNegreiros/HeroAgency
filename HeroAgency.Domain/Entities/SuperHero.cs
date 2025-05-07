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

        public SuperHero(string name, string heroName, DateTime birthDate, decimal height, decimal weight)
        {
            Name = name;
            HeroName = heroName;
            BirthDate = birthDate;
            Height = height;
            Weight = weight;
        }

        public dynamic ToJson()
        {
            return new
            {
                Id,
                Name,
                HeroName,
                BirthDate,
                Height,
                Weight,
                SuperHeroPower = SuperHeroPowers.Select(shp => shp.SuperPowerId)
            };
        }
    }
}
