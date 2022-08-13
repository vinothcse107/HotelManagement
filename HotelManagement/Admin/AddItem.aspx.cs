using HotelManagement.HotelService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelManagement.Admin
{
    public partial class AddItem : System.Web.UI.Page
    {
        AdminServiceClient ad = new AdminServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void AddItemsToMenu_Click(object sender, EventArgs e)
        {
            Items i = new Items
            {
                ItemId = -1,
                ItemName = ItemName.Text,
                Price = Convert.ToInt32(Price.Text)
            };
            bool b = ad.AddItemsToMenu(i);
            Response.Write(b ? "Item Added To Menu" : "Item Not Add , Error !!!");
        }

        protected void Add_Table_Click(object sender, EventArgs e)
        {
            if(ad.AddTables())
            {
                TableLabel.Text = "Table Added";
            }
            else
            {
                TableLabel.Text = "Something Went Wrong !!! ...Error";
            }
        }
    }
}