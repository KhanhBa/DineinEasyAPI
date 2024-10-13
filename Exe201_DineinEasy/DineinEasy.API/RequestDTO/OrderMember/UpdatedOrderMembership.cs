namespace DineinEasy.API.RequestDTO.OrderMember
{
    public class UpdatedOrderMembership
    {
        public DateTime ExpiredDate { get; set; }

        public int ValueDays { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public double Price { get; set; }

        public double Discount { get; set; }

        public bool Status { get; set; }
    }
}
