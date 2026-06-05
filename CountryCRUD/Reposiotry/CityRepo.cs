using CountryCRUD.Data;
using CountryCRUD.IRepo;
using CountryCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace CountryCRUD.Reposiotry
{
    public class CityRepo : ICityRepo
    {
        private readonly ApplicationDbContext _context;

        public CityRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<City?> AddCityAsync(City cities)
        {
            await _context.Cities.AddAsync(cities);
            await _context.SaveChangesAsync();
            return cities;
        }

        public async Task<bool> DeleteCityAsync(int CityId)
        {
            var isExist = _context.Cities.FirstOrDefault(a => a.CityId == CityId);

            if (isExist == null)
            {

                return false;
            }
             _context.Cities.Remove(isExist);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<City>> GetAllCityAsync()
        {
            return await _context.Cities.ToListAsync();
        }

        public async Task<City> GetCityByIdAsync(int CityId)
        {
            return await _context.Cities.FirstOrDefaultAsync(a => a.CityId == CityId);
        }

        public async Task<bool> UpdateCityDetails(City cities)
        {
           var isExist = _context.Cities
                .FirstOrDefault(a => a.CityId == cities.CityId);
            if (isExist == null)
            {
                return false;
            }
            isExist.CityName = cities.CityName;
            isExist.StateId = cities.StateId;
           await _context.SaveChangesAsync();
            return true;
        }
    }
}
