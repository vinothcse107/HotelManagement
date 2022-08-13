using HotelManagement.HotelService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelManagement.Admin
{
    public partial class AddWaiter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Add_Waiter(object sender, EventArgs e)
        {
            AccountServiceClient accountService = new AccountServiceClient();
            Users user = new Users()
            {
                Username = username.Text.ToLower(),
                Password = password.Text.ToString(),
                Phone = phone.Text.ToString(),
                Roleid = 1
            };

            var x = accountService.AddAccount(user);
            Response.Write(x ? "User Added" : "User Not Added");
        }
    }
}