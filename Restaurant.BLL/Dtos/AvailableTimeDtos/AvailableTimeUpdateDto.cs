namespace Restaurant.BLL.Dtos.AvaiableTimeDtos
{
    public class AvailableTimeUpdateDto
    {

        public int Id { get; set; } 
        public DateTime Date { get; set; }
        public string Time { get; set; } = null!;

    }
}
