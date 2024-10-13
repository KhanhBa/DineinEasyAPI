namespace DineinEasy.API.RequestDTO.Customer
{
    public class UpdatedCustomer
    {
        public Guid Id { get; set; } 

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string ImageUrl { get; set; }

        public bool Status { get; set; }

    }
}
