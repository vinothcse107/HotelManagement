using HotelManagement.HotelService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelManagement.Admin
{
    public partial class DeleteItem : System.Web.UI.Page
    {
        ItemsServiceClient ItemsService = new ItemsServiceClient();
        AdminServiceClient AdminService = new AdminServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            var ses = (SessionDTO)Session["admin"];
            if (ses != null && ses.role.Equals("admin") && ses.sid != null)
            {
                if (!IsPostBack)
                    RefreshGrid(sender, e);
            }
            else
                Response.Redirect("~/Pages/Login.aspx");
        }
        protected void RefreshGrid(object sender, EventArgs e)
        {
            DataTable dt = ItemsService.GetMenu();
            GridView1.DataSource = dt.DefaultView;
            GridView1.DataBind();
        }
        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int x = Convert.ToInt32(e.Values[0]);
            var t = AdminService.DeleteItemsFromMenu(x) ?
                            "Item Removed" : "Error !! item Not Removed";
            Response.Write(t);
            RefreshGrid(sender, e);
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }

}