namespace WebApplication1.Model
{
    public class Country
    {
        public Country(int id, string name, string capital, string continent)
        {
            Id = id;
            Name = name;
            Capital = capital;
            Continent = continent;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Capital { get; set; }
        public string Continent { get; set; }
    }
}
