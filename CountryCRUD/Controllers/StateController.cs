using CountryCRUD.IServices;
using CountryCRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace CountryCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IStateServices _service;

        public StateController(IStateServices service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStates()
        {
            return Ok(await _service.GetAllStateAsync());
        }

        [HttpGet("by-country/{countryId}")]
        public async Task<IActionResult> GetStatesByCountryId(int countryId)
        {
            return Ok(await _service.GetStateByIdAsync(countryId));
        }

        [HttpPost]
        public async Task<IActionResult> AddState(State state)
        {
            return Ok(await _service.AddStateAsync(state));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateState(int id, State state)
        {
            if (id != state.StateId)
                return BadRequest();

            return Ok(await _service.UpdateStateDetails(state));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteState(int id)
        {
            return Ok(await _service.DeleteStateAsync(id));
        }
    }
}
