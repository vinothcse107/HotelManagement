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
    public partial class AddItem : System.Web.UI.Page
    {
        AdminServiceClient ad = new AdminServiceClient();
        ItemsServiceClient items = new ItemsServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CategoryDropDownList();
            }
        }
        private void CategoryDropDownList()
        {
            DataTable Tables = items.GetCategory();
            for (int i = 0; i < Tables.Rows.Count; i++)
            {
                CategoryList.Items.Insert(i, new ListItem(
                          Tables.Rows[i].ItemArray[1].ToString(),
                          Tables.Rows[i].ItemArray[0].ToString())
                      );
            }
            CategoryList.DataBind();
        }
        protected void AddItemsToMenu_Click(object sender, EventArgs e)
        {
            if (ItemName.Text.Trim() != "" && Price.Text.Trim() != "")
            {
                Items i = new Items
                {
                    ItemId = -1,
                    ItemName = ItemName.Text.Trim(),
                    Price = Convert.ToInt32(Price.Text),
                    FoodCategoryId = Convert.ToInt32(CategoryList.SelectedItem.Value),
                    TotalQuantity = 0,
                    ItemActive = 1
                };
                bool b = ad.AddItemsToMenu(i);
                Response.Write(b ? "Item Added To Menu" : "Item Not Add , Error !!!");
            }
            else
            {
                Response.Write("Fill All Required Fields");
            }
        }

        protected void Add_Table_Click(object sender, EventArgs e)
        {
            TableLabel.Text = ad.AddTables() ? "Table Added"
                               : "Something Went Wrong !!! ...Error";
        }
    }
}