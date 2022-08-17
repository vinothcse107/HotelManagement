using HotelManagement.HotelService;
using System;
using System.Collections.Generic;
using System.Data;
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
            if (!(IsPostBack))
            {
                AccountServiceClient accountService = new AccountServiceClient();
                DataTable Tables = accountService.GetRoles();
                //for (int i = 0; i < Tables.Rows.Count; i++)
                //{
                //    RolesDropDownList.Items.Insert(i, new ListItem(
                //        Tables.Rows[i].ItemArray[1].ToString(),
                //        Tables.Rows[i].ItemArray[0].ToString()
                //    ));
                //}
                //RolesDropDownList.DataBind();
            }
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

        protected void AddUserToList(object sender, EventArgs e)
        {
            AccountServiceClient accountService = new AccountServiceClient();
            Users user = new Users()
            {
                Username = username.Text.ToLower(),
                Password = password.Text.ToString(),
                Phone = phone.Text.ToString(),
                //Roleid = Convert.ToInt32(RolesDropDownList.SelectedItem.Value)
            };

            var x = accountService.AddAccount(user);
            Response.Write(x ? "User Added" : "User Not Added");
        }
    }
}