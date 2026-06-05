using CountryCRUD.Data;
using CountryCRUD.IRepo;
using CountryCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace CountryCRUD.Reposiotry
{
    public class StateRepo : IStateRepo
    {
        private readonly ApplicationDbContext _context;

        public StateRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<State?> AddStateAsync(State states)
        {
            await _context.States.AddAsync(states);
            await _context.SaveChangesAsync();
            return states;
        }

        public async Task<bool> DeleteStateAsync(int StateId)
        {
            var isExist = await _context.States.FirstOrDefaultAsync(a=>a.StateId == StateId);

            if(isExist == null)
            {
                return false;
            }
             _context.States.Remove(isExist);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<State>> GetAllStateAsync()
        {
            return await _context.States.ToListAsync();
        }

        public async Task<State> GetStateByIdAsync(int StateId)
        {
            return await _context.States.FirstOrDefaultAsync(a => a.StateId == StateId);
        }

        public async Task<bool> UpdateStateDetails(State states)
        {
            var isExist = _context.States
                .FirstOrDefault(a => a.StateId == states.StateId);

            if(isExist == null)
            {
                return false;
            }

            isExist.StateName = states.StateName;
            isExist.CountryId = states.CountryId;
            await _context.SaveChangesAsync();
            return true;

        }
    }
}
