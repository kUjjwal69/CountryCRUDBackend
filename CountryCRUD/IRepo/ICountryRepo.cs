using CountryCRUD.Models;

namespace CountryCRUD.IRepo
{
    public interface ICountryRepo
    {
        // Add Country
        Task<Country?> AddCountryAsync(Country country);

        // edit
        Task<bool> UpdateCountryDetails(Country country);


        // delete
        Task<bool> DeleteCountryAsync(int CountryId);

        //list
        Task<List<Country>> GetAllCountriesAsync();

        // get by id
        Task<Country> GetCountryByIdAsync(int CountryId);


    }
}
