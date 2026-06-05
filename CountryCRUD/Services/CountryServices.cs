using CountryCRUD.IRepo;
using CountryCRUD.IServices;
using CountryCRUD.Models;

namespace CountryCRUD.Services
{
    public class CountryServices : ICountryServices
    {
        private readonly ICountryRepo _repo;

        public CountryServices(ICountryRepo repo)
        {
            _repo = repo;
        }
        public async Task<Country?> AddCountryAsync(Country country)
        {
            await _repo.AddCountryAsync(country);
            return country;
        }

        public async Task<bool> DeleteCountryAsync(int CountryId)
        { 
        await _repo.DeleteCountryAsync(CountryId);
            return true;
        }

        public async Task<List<Country>> GetAllCountriesAsync()
        {
            return await _repo.GetAllCountriesAsync();
        }

        public async Task<Country> GetCountryByIdAsync(int CountryId)
        {
            return  await _repo.GetCountryByIdAsync(CountryId);
        }

        public async Task<bool> UpdateCountryDetails(Country country)
        {
            await _repo.UpdateCountryDetails(country);
            return true;
        }
    }
}
