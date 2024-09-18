namespace DineinEasy.API.RequestDTO.Package
{
    public class UpdatedPackage
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public int ValueDays { get; set; }

        public double Price { get; set; }

        public double Discount { get; set; }

        public bool Status { get; set; }
    }
}
