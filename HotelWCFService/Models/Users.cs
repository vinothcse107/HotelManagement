using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelWCFService.Models
{
    public class Users
    {
        [Key]
        public string UserId {get;set;}
	    public string Username {get;set;}
	    public string Password {get;set;}
	    public string Phone {get;set;}
	    public int Roleid { get; set; }

    }

    public class Role {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
    }

}