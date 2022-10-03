namespace WebApplication1.Model
{
    public class CountryRepository : ICountryRepository
    {

        private Dictionary<int, Country> data=new Dictionary<int, Country>();

        public CountryRepository()
        {
            data.Add(1, new Country(1, "België", "Brussel", "Europa"));
            data.Add(2, new Country(2, "Peru", "Lima", "Zuid-Amerika"));
            data.Add(3, new Country(3, "Duitsland", "Berlijn", "Europa"));
            data.Add(4, new Country(4, "Zweden", "Stockholm", "Europa"));
            data.Add(5, new Country(5, "Noorwegen", "Oslo", "Europa"));
        }
        void ICountryRepository.AddCountry(Country country)
        {
            if (!data.ContainsKey(country.Id))
                data.Add((int)country.Id, country);
            else
                throw new CountryException("AddCountry - id already exists");
        }

        IEnumerable<Country> ICountryRepository.GetAll()
        {
            return data.Values;
        }

        Country ICountryRepository.GetCountry(int id)
        {
            if (data.ContainsKey(id))
                return data[id];
            else
                throw new CountryException("GetCountry - id not found");
        }

        void ICountryRepository.RemoveCountry(Country country)
        {
            if (data.ContainsKey(country.Id))
                data.Remove(country.Id);
            else
                throw new CountryException("RemoveCountry - id not found");

        }

        void ICountryRepository.UpdateCountry(Country country)
        {
            if (data.ContainsKey(country.Id))
                data[country.Id] = country;
            else
                throw new CountryException("UpdateCountry - id not found");
        }

        IEnumerable<Country> ICountryRepository.GetAll(string continent, string capital)
        {
            return data.Values.Where(x => x.Continent==continent && x.Capital==capital);
        }

        public bool ExistsCountry(int id)
        {
            return data.ContainsKey(id);
        }
    }
}
