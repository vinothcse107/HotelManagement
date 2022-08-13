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

       ItemsServiceClient ItemsService = new ItemsServiceClient();
        HotelServiceClient dt = new HotelServiceClient();
        static int Category=2;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                //DataTable dt = ItemsService.GetMenu();
                //GridView1.DataSource = dt.DefaultView;
                //GridView1.DataBind();
                DropDownList();
                List<Items> items = ItemsService.GetItemsList().ToList();
                menulist.DataSource = items;
                menulist.DataBind();
            }


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
            //Label1.Text = GridView1.SelectedRow.Cells[1].Text;
            //Label2.Text = GridView1.SelectedRow.Cells[2].Text;
            //Label3.Text = GridView1.SelectedRow.Cells[3].Text;
            //TextBox1.Visible = true;


        }
        private void DropDownList()
        {
            DataTable Tables = dt.GetTables();
            for (int i = 0; i < Tables.Rows.Count; i++)
            {
                TablesDropDownList.Items.Insert(i, new ListItem(
                          "Table "+Tables.Rows[i].ItemArray[0].ToString(),
                          Tables.Rows[i].ItemArray[0].ToString())
                      );
            }
            TablesDropDownList.DataBind();
        }

        //void sendCategory()
        //{
        //    ItemsService.
        //}
            protected void menulist_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            var id =Convert.ToInt32(e.CommandArgument);
            var quants = (menulist.FindControl("Quantity") as TextBox).Text;
            Label1.Text = quants;
            
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Category = 1;
        }
        protected void Button2_Click(object sender, EventArgs e)
        {

            Category = 2;
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            Category = 3;
        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            Category = 4;
        }

       
        protected void Order_Click(object sender, EventArgs e)
        {

        }

       
    }
}