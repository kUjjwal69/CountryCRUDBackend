using CountryCRUD.IRepo;
using CountryCRUD.IServices;
using CountryCRUD.Models;

namespace CountryCRUD.Services
{
    public class StateServices : IStateServices
    {
        private readonly IStateRepo _repo;

        public StateServices(IStateRepo repo)
        {
            _repo = repo;
        }
        public async Task<State?> AddStateAsync(State states)
        {
            await _repo.AddStateAsync(states);
            return states;
        }

        public async Task<bool> DeleteStateAsync(int StateId)
        {
            await _repo.DeleteStateAsync(StateId);
            return true;
        }

        public async Task<List<State>> GetAllStateAsync()
        {
            return await _repo.GetAllStateAsync();
        }

        public async Task<State> GetStateByIdAsync(int StateId)
        {
            return await _repo.GetStateByIdAsync(StateId);
        }

        public async Task<bool> UpdateStateDetails(State states)
        {
            await _repo.UpdateStateDetails(states);
            return true;
        }
    }
}
