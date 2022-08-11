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
      public partial class NewOrder : System.Web.UI.Page
      {
            ItemsServiceClient it = new ItemsServiceClient();
            HotelServiceClient dt = new HotelServiceClient();
            int count = 0;

            protected void Page_Load(object sender, EventArgs e)
            {
                  if (count == 0)
                  {
                        DropDownList();
                        count++;

                  }
            }
            private void DropDownList()
            {
                  if (TablesDropDownList.Items.Count <= 0 && ItemsDropDown.Items.Count <= 0)
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

                        //Items DropdownList
                        DataTable ItemTables = it.GetItems();
                        for (int i = 0; i < ItemTables.Rows.Count; i++)
                        {
                              ItemsDropDown.Items.Insert(i, new ListItem(
                                      ItemTables.Rows[i].ItemArray[1].ToString(),
                                      ItemTables.Rows[i].ItemArray[0].ToString())
                                  );
                        }
                        ItemsDropDown.DataBind();
                  }
            }

            // Generate New Order for CusTable
            protected void NewOrder_Click(object sender, EventArgs e)
            {
                  try
                  {
                        int x = it.NewOrderForTable(Convert.ToInt32(TablesDropDownList.SelectedItem.Text), Convert.ToInt32(Session["UserId"]));
                        Session["OrderNo"] = x;
                        ResponseShow.Text = "Your Order No is : " + x.ToString();
                        GridViewX.DataSource = new DataTable();
                        GridViewX.DataBind();
                  }
                  catch (Exception ex)
                  {
                        Response.Write(ex.Message);
                  }
            }

            // Adding New Item to Orders
            protected void AddItems(object sender, EventArgs e)
            {
                  Order_Items_Link od = new Order_Items_Link()
                  {
                        ItemId = Convert.ToInt32(ItemsDropDown.SelectedItem.Value),
                        OderId = Convert.ToInt32(Session["OrderNo"].ToString()),
                        Quantity = Convert.ToInt32(QuantityNo.Text)
                  };

                  if (it.AddItems(od))
                  {
                        Response.Write("Item Added");
                        GridViewX_SelectedIndexChanged(sender, e);
                  }
                  else
                        Response.Write("Item Not Added");

            }

            protected void GridViewX_SelectedIndexChanged(object sender, EventArgs e)
            {
                  // Get Items Ordered By a Table
                  int TabbleNum = Convert.ToInt32(TablesDropDownList.SelectedItem.Text);
                  DataTable dt = it.GetOrderItemsForTable(TabbleNum);


                  // Get OrderNo for Existing Table
                  int x = it.ExistingOrderForTable(Convert.ToInt32(TablesDropDownList.SelectedItem.Text));
                  Session["OrderNo"] = x;


                  // Grid View Controlling
                  if (dt.Rows.Count == 0)
                  {
                        ResponseShow.Text = "Data Not Found";
                        GridViewX.DataSource = new DataTable();
                        GridViewX.DataBind();
                  }
                  else
                  {
                        GridViewX.DataSource = dt.DefaultView;
                        GridViewX.DataBind();
                        ResponseShow.Text = "";
                  }
            }

      }
}