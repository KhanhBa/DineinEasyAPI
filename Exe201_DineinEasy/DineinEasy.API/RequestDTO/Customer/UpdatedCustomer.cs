namespace DineinEasy.API.RequestDTO.Customer
{
    public class UpdatedCustomer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public DateTime CreateAt { get; set; }

        public string ImageUrl { get; set; }

        public bool Status { get; set; } 
    }
}
