using CountryCRUD.Data;
using CountryCRUD.IRepo;
using CountryCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace CountryCRUD.Reposiotry
{
    public class CountryRepo : ICountryRepo
    {
        private readonly ApplicationDbContext _context;
        public CountryRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Country?> AddCountryAsync(Country country)
        {
            await _context.Countries.AddAsync(country);
            await _context.SaveChangesAsync();
            return country;
        }

        public async Task<bool> DeleteCountryAsync(int CountryId)
        {
            var isExist = await _context.Countries.FirstOrDefaultAsync(x=>x.CountryId == CountryId);

            if(isExist == null)
            {
                return false;
            }
            _context.Countries.Remove(isExist);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Country>> GetAllCountriesAsync()
        {
            return await _context.Countries.ToListAsync();
        }

        public async Task<Country> GetCountryByIdAsync(int CountryId)
        {
            return await _context.Countries.FirstOrDefaultAsync(x => x.CountryId == CountryId);
        }
        public async Task<bool> UpdateCountryDetails(Country country)
        {
            var isExist = await _context.Countries
                .FirstOrDefaultAsync(x => x.CountryId == country.CountryId);

            if (isExist == null)
            {
                return false;
            }

            isExist.CountryName = country.CountryName;
            isExist.CountryCode = country.CountryCode;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
