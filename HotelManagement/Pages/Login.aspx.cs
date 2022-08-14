using HotelManagement.HotelService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelManagement
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            AccountServiceClient ac = new AccountServiceClient();
            LoginDTO loginDTO = new LoginDTO()
            {
                Username = username.Text.ToLower().ToString(),
                Password = password.Text.ToString()
            };

            ResponseDTO rt = ac.Login(loginDTO);
            if (rt.access)
            {
                Session["userid"] = rt.userId;
                Session["username"] = rt.username;
                if (rt.role.Equals("Admin"))
                    Response.Redirect("~/Admin/AddItem.aspx");
                else if (rt.role.Equals("Waiter"))
                    Response.Redirect("~/Waiter/MenuList.aspx");
            }
            else
                ResponseLabel.Text = rt.message.ToString();
        }
    }
}