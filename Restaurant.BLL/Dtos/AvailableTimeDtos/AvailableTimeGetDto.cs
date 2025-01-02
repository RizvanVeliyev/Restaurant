using Restaurant.BLL.Abstractions.Dtos;

namespace Restaurant.BLL.Dtos.AvaiableTimeDtos
{
    public class AvailableTimeGetDto : IDto
    {
        public int Id { get; set; } 
        public DateTime Date { get; set; }
        public string Time { get; set; } = null!;
    }
}
