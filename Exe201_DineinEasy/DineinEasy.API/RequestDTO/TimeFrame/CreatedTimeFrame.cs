namespace DineinEasy.API.RequestDTO.TimeFrame
{
    public class CreatedTimeFrame
    {
        public string Day { get; set; }

        public string OpenedTime { get; set; }

        public string ClosedTime { get; set; }

        public int RestaurantId { get; set; }

        public TimeOnly GetOpenedTime() => TimeOnly.Parse(OpenedTime);

        public TimeOnly GetClosedTime() => TimeOnly.Parse(ClosedTime);
    }

}
