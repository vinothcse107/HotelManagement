using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelWCFService.DTO
{
    public class LoginDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class ResponseDTO
    {
        public int userId { get; set; }
        public string username { get; set; }
        public string role { get; set; }
        public bool access { get; set; }
        public string message { get; set; }
    }

}