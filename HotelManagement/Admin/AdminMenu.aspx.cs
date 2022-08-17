using HotelManagement.HotelService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelManagement.Admin
{
    public partial class AdminMenu : System.Web.UI.Page
    {

        ItemsServiceClient ItemsService = new ItemsServiceClient();
        AdminServiceClient AdminService = new AdminServiceClient();
        HotelServiceClient dt = new HotelServiceClient();
        static int Category = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            var ses = (SessionDTO)Session["admin"];
            if (!(ses != null && ses.role.Equals("admin") && ses.sid != null))
            {
                Response.Redirect("~/Pages/Login.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    List<Items> items = ItemsService.GetMenuByCategoryId(Category).ToList();
                    menulist.DataSource = items;
                    menulist.DataBind();
                }
            }
        }
        protected void Update_Click(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as Button).NamingContainer as RepeaterItem;
            var id = Convert.ToInt32((item.FindControl("ItemId") as Label).Text);
            var Qty = Convert.ToInt32((item.FindControl("Quantity") as TextBox).Text);


            bool res = AdminService.UpdateItemTotalQuantity(id, Qty);
            if (res)
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ToastrNotification", CallToastr("Item Updated successfully", "success", ""), true);
            else
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ToastrNotification", CallToastr("Error !! Item Not Updated ", "error", ""), true);


        }
        protected void ItemsByCategory(object sender, CommandEventArgs e)
        {
            if (e.CommandName.Equals("veg"))
                Category = Convert.ToInt32(Button1.CommandArgument);
            else if (e.CommandName.Equals("nonveg"))
                Category = Convert.ToInt32(Button2.CommandArgument);
            else if (e.CommandName.Equals("dessert"))
                Category = Convert.ToInt32(Button3.CommandArgument);
            else if (e.CommandName.Equals("soup"))
                Category = Convert.ToInt32(Button4.CommandArgument);
            else
                Category = Convert.ToInt32(5);


            List<Items> items = ItemsService.GetMenuByCategoryId(Category).ToList();
            menulist.DataSource = items;
            menulist.DataBind();
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