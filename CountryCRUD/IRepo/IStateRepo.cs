using CountryCRUD.Models;

namespace CountryCRUD.IRepo
{
    public interface IStateRepo
    {
        // Add Country
        Task<State?> AddStateAsync(State states);

        // edit
        Task<bool> UpdateStateDetails(State states);


        // delete
        Task<bool> DeleteStateAsync(int StateId);

        //list
        Task<List<State>> GetAllStateAsync();

        // get by id
        Task<State> GetStateByIdAsync(int StateId);
    }
}
