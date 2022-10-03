namespace WebApplication1.Model
{
    public interface ICountryRepository
    {
        void AddCountry(Country country);
        Country GetCountry(int id);
        IEnumerable<Country> GetAll();
        void UpdateCountry(Country country);
        void RemoveCountry(Country country);

        IEnumerable<Country> GetAll(string continent, string capital);
    }
}
