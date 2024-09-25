namespace DineinEasy.API.RequestDTO.User
{
    public class CreatedUser
    {

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int Role { get; set; }

        public string Password { get; set; }

        public DateTime CreateAt { get; set; } = DateTime.Now;

        public bool Status { get; set; }
    }
}
