namespace DineinEasy.API.RequestDTO.TimeFrame
{
    public class CreatedTimeFrame
    {
        public string Day { get; set; }

        public TimeOnly OpenedTime { get; set; }

        public TimeOnly ClosedTime { get; set; }

        public int RestaurantId { get; set; }
    }
}
