namespace CountryCRUD.Models
{
    public class City
    {
        public int CityId { get; set; }

        public string CityName { get; set; }

        public int StateId { get; set; }  //FK

        public State? State { get; set; }
    }
}
