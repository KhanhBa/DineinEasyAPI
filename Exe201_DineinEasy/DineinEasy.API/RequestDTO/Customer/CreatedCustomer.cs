using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DineinEasy.API.RequestDTO.Customer
{
    public class CreatedCustomer 
    {


        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string ImageUrl { get; set; }

        public bool Status { get; set; }


    }
}
