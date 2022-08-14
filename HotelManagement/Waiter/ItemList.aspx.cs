using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelManagement.Waiter
{
    public partial class ItemList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var ses = (SessionDTO)Session["user"];
            if (!(ses != null && ses.role.Equals("waiter") && ses.sid != null))
            {
                Response.Redirect("~/Pages/Login.aspx");
            }
        }
    }
}