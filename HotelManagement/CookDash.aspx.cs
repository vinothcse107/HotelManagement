﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelManagement
{
    public partial class CookDash : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Logout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/Pages/Login");
        }

    }
}