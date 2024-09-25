using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DineinEasy.Service.Models
{
    public class SignInModel<T>
    {
        public string AccessToken { get; set; }
        public string RefreshToken {  get; set; }

        public T Data { get; set; }
    }
}
