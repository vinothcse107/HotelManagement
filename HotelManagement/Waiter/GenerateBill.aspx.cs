using HotelManagement.HotelService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelManagement.Waiter
{
    public partial class GenerateBill : System.Web.UI.Page

    {
        List<OrderListDTO> items;
        ItemsServiceClient ItemsService = new ItemsServiceClient();
        static int Table = 1;
        static int OrderNoForTable;

        protected void Page_Load(object sender, EventArgs e)
        {
            var ses = (SessionDTO)Session["user"];
            if (!(ses != null && ses.role.Equals("waiter") && ses.sid != null))
            {
                Response.Redirect("~/Pages/Login.aspx");
            }
            if (!IsPostBack)
            {
                List<Tables> tables = ItemsService.GetTableList().ToList();
                tableList.DataSource = tables;
                tableList.DataBind();
                Table = 1; ;
                Referesh_Table();
            }
        }

        void Referesh_Table()
        {
            items = ItemsService.GetOrderItemsForTableList(Table).ToList();
            int sum = 0;
            if (items.Count == 0)
            {
                Label2.Text = "Data Not Found";
                Orderedlist.DataSource = new List<OrderListDTO>();
                Orderedlist.DataBind();
                Amount.Text = "Total = " + sum.ToString();
            }
            else
            {
                Orderedlist.DataSource = items;
                Orderedlist.DataBind();
                Label2.Text = "";

                sum = 0;
                foreach (OrderListDTO r in items)
                {
                    int x = (r.Price) * (r.Quantity);
                    sum += x;
                }
                Amount.Text = "Total = " + sum.ToString();
            }
        }

        protected void Del_Click(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as Button).NamingContainer as RepeaterItem;
            var id = Convert.ToInt32((item.FindControl("ItemId") as Label).Text);

            bool res = ItemsService.DeleteItemsFromCustomerOrder(
                new Order_Items_Link
                {
                    ItemId = id,
                    OderId = OrderNoForTable
                });

            Label2.Text = res ? "Item Deleted Successfully" : "Error !! Item Not Deleted ";
            Referesh_Table();
        }

        protected void TableNo(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as Button).NamingContainer as RepeaterItem;
            Table = Convert.ToInt32((item.FindControl("tableno") as Label).Text);
            OrderNoForTable = ItemsService.ExistingOrderForTable(Table);

            Referesh_Table();

        }
    }
}