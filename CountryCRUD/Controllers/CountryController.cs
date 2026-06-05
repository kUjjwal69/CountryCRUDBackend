namespace CountryCRUD.Controllers
{
    using CountryCRUD.IServices;
    using CountryCRUD.Models;
    using Microsoft.AspNetCore.Mvc;

        [Route("api/[controller]")]
        [ApiController]
        public class CountryController : ControllerBase
        {
            private readonly ICountryServices _service;

            public CountryController(ICountryServices service)
            {
                _service = service;
            }

            [HttpGet]
            public async Task<IActionResult> GetAllCountries()
            {
                var countries = await _service.GetAllCountriesAsync();
                return Ok(countries);
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetCountryById(int id)
            {
                var country = await _service.GetCountryByIdAsync(id);

                if (country == null)
                    return NotFound();

                return Ok(country);
            }

            [HttpPost]
            public async Task<IActionResult> AddCountry(Country country)
            {
                var result = await _service.AddCountryAsync(country);

                return Ok(result);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> UpdateCountry(int id, Country country)
            {
                if (id != country.CountryId)
                    return BadRequest();

                var result = await _service.UpdateCountryDetails(country);

                if (!result)
                    return NotFound();

                return Ok("Country Updated Successfully");
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteCountry(int id)
            {
                var result = await _service.DeleteCountryAsync(id);

                if (!result)
                    return NotFound();

                return Ok("Country Deleted Successfully");
            }
        }
    }

