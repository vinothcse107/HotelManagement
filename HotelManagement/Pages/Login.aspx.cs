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
        ItemsServiceClient it = new ItemsServiceClient();

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
                Session["Check"] = "Hi There !";
                if (rt.role.Equals("admin"))
                {
                    var ad = new SessionDTO()
                    {
                        userid = rt.userId,
                        username = rt.username,
                        role = rt.role,
                        sid = Session.SessionID
                    };
                    Session["admin"] = ad;
                    Response.Redirect("~/Admin/AdminMenu.aspx");
                }
                else if (rt.role.Equals("waiter"))
                {

                    var ses = new SessionDTO()
                    {
                        userid = rt.userId,
                        username = rt.username,
                        role = rt.role,
                        sid = Session.SessionID
                    };
                    HashSet<Orders> HashOrdersPlaced = new HashSet<Orders>();
                    Session["OrderPlaced"] = HashOrdersPlaced;

                    Session["user"] = ses;
                    Response.Redirect("~/Waiter/MenuList.aspx");
                }
            }
            else
                ResponseLabel.Text = rt.message.ToString();
        }
    }
}