namespace CountryCRUD.Models
{
    public class State
    {

        public int StateId { get; set; }    

        public string StateName { get; set; }

        public int CountryId { get; set; }  //FK

        public Country? Country { get; set; }

        public ICollection<City>? Cities { get; set; } = new List<City>();
    }
}
