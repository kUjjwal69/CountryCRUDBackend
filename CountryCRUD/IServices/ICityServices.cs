using CountryCRUD.Models;

namespace CountryCRUD.IServices
{
    public interface ICityServices
    {
        // Add Country
        Task<City?> AddCityAsync(City cities);

        // edit
        Task<bool> UpdateCityDetails(City cities);


        // delete
        Task<bool> DeleteCityAsync(int CityId);

        //list
        Task<List<City>> GetAllCityAsync();

        // get by id
        Task<City> GetCityByIdAsync(int CityId);
    }
}
