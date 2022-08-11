using HotelManagement.HotelService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelManagement.Pages
{
    public partial class MenuList : System.Web.UI.Page
    {

        static ItemsServiceClient ItemsService = new ItemsServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = ItemsService.GetMenu();
            GridView1.DataSource = dt.DefaultView;
            GridView1.DataBind();
            //Items[] it = new Items[4];
            //it[0] = new Items() { ItemId = 25, ItemName = "Pizza", Price = 50, TotalQuantity = 0, ItemActive = 1 };
            //it[1] = new Items() { ItemId = 26, ItemName = "Burgir", Price = 150, TotalQuantity = 0, ItemActive = 1 };
            //it[2] = new Items() { ItemId = 27, ItemName = "Pasta", Price = 250, TotalQuantity = 0, ItemActive = 1 };
            //it[3] = new Items()
            //{
            //    ItemId = 28,
            //    ItemName = "Rice",
            //    Price = 350,
            //    TotalQuantity = 0,
            //    ItemActive = 1
            //};

            //menuList.DataSource = it.ToList(); 
            //menuList.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label1.Text = GridView1.SelectedRow.Cells[1].Text;
            Label2.Text = GridView1.SelectedRow.Cells[2].Text;
            Label3.Text = GridView1.SelectedRow.Cells[3].Text;
            TextBox1.Visible = true;


        }
    }
}