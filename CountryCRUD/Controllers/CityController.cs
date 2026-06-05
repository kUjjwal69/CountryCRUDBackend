namespace CountryCRUD.Controllers
{
    using CountryCRUD.IServices;
    using CountryCRUD.Models;
    using Microsoft.AspNetCore.Mvc;

        [Route("api/[controller]")]
        [ApiController]
        public class CityController : ControllerBase
        {
            private readonly ICityServices _service;

            public CityController(ICityServices service)
            {
                _service = service;
            }

            [HttpGet]
            public async Task<IActionResult> GetAllCities()
            {
                var cities = await _service.GetAllCityAsync();
                return Ok(cities);
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetCityById(int id)
            {
                var city = await _service.GetCityByIdAsync(id);

                if (city == null)
                    return NotFound("City not found");

                return Ok(city);
            }

            [HttpGet("by-state/{stateId}")]
            public async Task<IActionResult> GetCitiesByStateId(int stateId)
            {
                var cities = await _service.GetCityByIdAsync(stateId);

                return Ok(cities);
            }

            [HttpPost]
            public async Task<IActionResult> AddCity([FromBody] City city)
            {
                var result = await _service.AddCityAsync(city);

                return CreatedAtAction(
                    nameof(GetCityById),
                    new { id = result.CityId },
                    result);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> UpdateCity(int id, [FromBody] City city)
            {
                if (id != city.CityId)
                    return BadRequest("Id mismatch");

                var result = await _service.UpdateCityDetails(city);

                if (!result)
                    return NotFound("City not found");

                return Ok("City updated successfully");
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteCity(int id)
            {
                var result = await _service.DeleteCityAsync(id);

                if (!result)
                    return NotFound("City not found");

                return Ok("City deleted successfully");
            }
        }
    }
