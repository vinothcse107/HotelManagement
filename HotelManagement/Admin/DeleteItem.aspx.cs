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
        static ItemsServiceClient ItemsService = new ItemsServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = ItemsService.GetMenu();
            GridView1.DataSource = dt.DefaultView;
            GridView1.DataBind();
        }


        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            
        }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
        }
         protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

}