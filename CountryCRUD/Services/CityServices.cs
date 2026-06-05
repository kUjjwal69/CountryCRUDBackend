using CountryCRUD.IRepo;
using CountryCRUD.IServices;
using CountryCRUD.Models;

namespace CountryCRUD.Services
{
    public class CityServices : ICityServices
    {
        private readonly ICityRepo _repo;

        public CityServices(ICityRepo repo)
        {
            _repo = repo;
        }
        public async Task<City?> AddCityAsync(City cities)
        {
            await _repo.AddCityAsync(cities);
            return cities;
        }

        public async Task<bool> DeleteCityAsync(int CityId)
        {
           await _repo.DeleteCityAsync(CityId);
            return true;
        }

        public async Task<List<City>> GetAllCityAsync()
        {
          return await _repo.GetAllCityAsync();
          
        }

        public async Task<City> GetCityByIdAsync(int CityId)
        {
            return await _repo.GetCityByIdAsync(CityId);
        }

        public async Task<bool> UpdateCityDetails(City cities)
        {
            await _repo.UpdateCityDetails(cities);
            return true;
        }
    }
}
