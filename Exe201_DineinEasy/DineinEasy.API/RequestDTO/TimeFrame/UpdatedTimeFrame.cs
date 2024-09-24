namespace DineinEasy.API.RequestDTO.TimeFrame
{
    public class UpdatedTimeFrame
    {
        public string Day { get; set; }

        public TimeOnly OpenedTime { get; set; }

        public TimeOnly ClosedTime { get; set; }

    }
}
