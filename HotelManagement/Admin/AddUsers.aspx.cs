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
            var ses = (SessionDTO)Session["user"];
            if (!(ses != null && ses.role.Equals("admin") && ses.sid != null))
            {
                Response.Redirect("~/Pages/Login.aspx");
            }

        }

        protected void Add_Waiter(object sender, EventArgs e)
        {
            var usr = username.Text.Trim().ToLower();
            var pwd = password.Text.Trim().ToString();
            var ph = phone.Text.Trim().ToString();

            if (usr != "" && pwd != "" && ph != ""
                && usr.Length >= 6 && usr.Length <= 10
                && pwd.Length >= 6 && pwd.Length <= 16
                && ph.Length == 10)
            {
                AccountServiceClient accountService = new AccountServiceClient();
                Users user = new Users()
                {
                    Username = usr,
                    Password = pwd,
                    Phone = ph,
                    Roleid = Convert.ToInt32(DropDownList1.SelectedItem.Value)
                };

                var x = accountService.AddAccount(user);
                Response.Write(x ? "User Added" : "User Not Added");
            }
            else
            {
                Response.Write("Fill All Required Fields");
                Response.Write("UserName Length > 8 && < 10 Character && Password Length >8 && <16 && Phone Length = 10 Characters");
            }
        }
    }
}