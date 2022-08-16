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

            if (usr != "" && pwd != "" && ph != "")
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
                if(x)
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ToastrNotification", CallToastr("User Added successfully", "success", ""), true);
                else
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ToastrNotification", CallToastr("User Not Added", "error", ""), true);
            }
            else
            {
                Response.Write("Fill All Required Fields");
                Response.Write("UserName Length > 8 && < 10 Character && Password Length >8 && <16 && Phone Length = 10 Characters");
            }
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