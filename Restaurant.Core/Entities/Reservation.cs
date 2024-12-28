namespace Restaurant.Core.Entities
{
    public class Reservation
    {

        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime Date { get; set; }
        public string? Time { get; set; }
        public List<string>? SelectedFoods { get; set; } 
        public int NumberOfPeople { get; set; }

    }
}
