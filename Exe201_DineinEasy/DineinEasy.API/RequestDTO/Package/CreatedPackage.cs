namespace DineinEasy.API.RequestDTO.Package
{
    public class CreatedPackage
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public int ValidDays { get; set; }

        public double Price { get; set; }

        public double Discount { get; set; }

    }
}
