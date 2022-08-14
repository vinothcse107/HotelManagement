﻿using HotelManagement.HotelService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelManagement.Pages
{
    public partial class MenuList : System.Web.UI.Page
    {

        ItemsServiceClient ItemsService = new ItemsServiceClient();
        HotelServiceClient dt = new HotelServiceClient();
        static int Category = 1;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                DropDownList(); //Add Dynamic Table Values to DropDown

                // Bind Items To Repeter List
                List<Items> items = ItemsService.GetMenuByCategoryId(Category).ToList();
                menulist.DataSource = items;
                menulist.DataBind();

                // Get the Current Active Order For Table Add Set the Order Id 
                GetCurrentOrderId(sender, e);
            }
        }

        protected void GetCurrentOrderId(object sender, EventArgs e)
        {
            int x = ItemsService.ExistingOrderForTable(Convert.ToInt32(TablesDropDownList.SelectedItem.Text));
            Session["OrderNo"] = x;
        }
        private void DropDownList()
        {
            DataTable Tables = dt.GetTables();
            for (int i = 0; i < Tables.Rows.Count; i++)
            {
                TablesDropDownList.Items.Insert(i, new ListItem(
                          Tables.Rows[i].ItemArray[0].ToString(),
                          Tables.Rows[i].ItemArray[0].ToString())
                      );
            }
            TablesDropDownList.DataBind();
        }
        protected void Order_Click(object sender, EventArgs e)
        {
        }
        protected void Add_Click(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as Button).NamingContainer as RepeaterItem;
            var id = Convert.ToInt32((item.FindControl("ItemId") as Label).Text);
            var Qty = Convert.ToInt32((item.FindControl("Quantity") as TextBox).Text);


            bool res = ItemsService.AddItems(
                new Order_Items_Link
                {
                    ItemId = id,
                    Quantity = Qty,
                    OderId = Convert.ToInt32(Session["OrderNo"])
                });

            Label2.Text = res ? "Item Added" : "Error !! Item Not Added";
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

        protected void NewOrder_Click(object sender, EventArgs e)
        {
            try
            {
                int x = ItemsService.NewOrderForTable(
                                Convert.ToInt32(TablesDropDownList.SelectedItem.Text),
                                Convert.ToInt32(Session["UserId"]));
                Session["OrderNo"] = x;
                Label2.Text = "Your Order No is : " + x.ToString();
            }
            catch (FaultException ex)
            {
                Label2.Text = ex.Message;
            }
        }
    }
}