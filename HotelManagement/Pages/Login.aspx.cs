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
            HashSet<Orders> HashOrdersPlaced = new HashSet<Orders>();
            Session["OrderPlaced"] = HashOrdersPlaced;
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

                    Session["user"] = ses;
                    Response.Redirect("~/Waiter/MenuList.aspx");
                }
            }
            else
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ToastrNotification", CallToastr(rt.message.ToString(), "error", ""), true);
        }
        private string CallToastr(string msg, string status, string func)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("$(document).ready(function () {");
            sb.Append("ToastrNotification('");
            sb.Append(msg);
            sb.Append("','");
            sb.Append(status);
            sb.Append("','");
            sb.Append(func);
            sb.Append("');");
            sb.Append("})");
            return sb.ToString();
        }
    }
}