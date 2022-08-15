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
        protected void Page_Load(object sender, EventArgs e)
        {


            var ses = (SessionDTO)Session["user"];
            if (!(ses != null && ses.role.Equals("waiter") && ses.sid != null))
            {
                Response.Redirect("~/Pages/Login.aspx");
            }
            if(!IsPostBack)
            {
                List<Tables> tables = ItemsService.GetTableList().ToList();
                tableList.DataSource = tables;
                tableList.DataBind();

                CallOrderdList();

            }
            
        }
        void getAmount()
        {
            int sum = 0;
            foreach (OrderListDTO r in items)
            {
                int x = (r.Price) * (r.Quantity);
                sum += x;
            }
            Amount.Text = "Total = " + sum.ToString();
        }

        void CallOrderdList()
        {
           items= ItemsService.GetOrderItemsForTableList(1).ToList();
            Orderedlist.DataSource = items;
            Orderedlist.DataBind();
            getAmount();
           

        }
        protected void Del_Click( object sender, EventArgs e )
        {
            RepeaterItem item = (sender as Button).NamingContainer as RepeaterItem;
            var id = Convert.ToInt32((item.FindControl("ItemId") as Label).Text);

            bool res = ItemsService.DeleteItemsFromCustomerOrder(
                new Order_Items_Link
                {
                    ItemId = id,
                    
                    OderId = Convert.ToInt32(Session["OrderNo"])
                });

            Label2.Text = res ? "Item Deleted Successfully" : "Error !! Item Not Deleted ";
            CallOrderdList();
        }

        protected void TableNo(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as Button).NamingContainer as RepeaterItem;
            var id = Convert.ToInt32((item.FindControl("tableno") as Label).Text); 
            List<OrderListDTO> dt = ItemsService.GetOrderItemsForTableList(id).ToList();
            if (dt.Count == 0)
            {
                Label2.Text = "Data Not Found";
                Orderedlist.DataSource = new List<OrderListDTO>();
                Orderedlist.DataBind();
            }
            else
            {
                Orderedlist.DataSource = dt;
                Orderedlist.DataBind();
                Label2.Text = "";
            }
            getAmount();


        }
        protected void tableList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }
    }
}