using HotelManagement.HotelService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelManagement
{
      public partial class AdminControls : System.Web.UI.Page
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

            protected void DeleteItemFromMenu_Click(object sender, EventArgs e)
            {
                  int x = Convert.ToInt32(DeleteItemId.Text);
                  var t = ad.DeleteItemsFromMenu(x) ?
                                  "Item Removed" : "Error !! item Not Removed";
                    Response.Write(t);
            }

            protected void AddExtraTables_Click(object sender, EventArgs e)
            {
                  Response.Write(ad.AddTables() ?
                                 "Table Added" : "Error !! Table Not Added !");
            }

      }
}