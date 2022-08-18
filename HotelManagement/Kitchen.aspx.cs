using HotelManagement.HotelService;
using HotelManagement.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelManagement
{
    public partial class Kitchen : System.Web.UI.Page
    {

        List<KitchenOrderDTO> items;
        ItemsServiceClient ItemsService = new ItemsServiceClient();
        static int Order;
        HashSet<Orders> hs;

        protected void Page_Load(object sender, EventArgs e)
        {
            hs = (HashSet<Orders>)Session["OrderPlaced"];
            if (hs.Count > 0)
            {
                Order = hs.First().OrderId;
                Label1.Visible = false;
            }
            else
                Label1.Visible = true;

            if (!IsPostBack)
            {
                tableList.DataSource = hs.ToList();
                tableList.DataBind();
                Referesh_Table();
            }
        }

        protected void Ready_Click(object sender, EventArgs e)
        {
            foreach (var i in hs)
            {
                if (i.OrderId == Order)
                {
                    hs.Remove(i);
                    MenuList mt = new MenuList();
                    mt.OrderReady();
                    break;
                }
            }
            Session["OrderPlaced"] = hs;

            if (hs.Count > 0)
            {
                Order = hs.First().OrderId;
                tableList.DataSource = hs.ToList();
                tableList.DataBind();
                Referesh_Table();
            }
            else
            {
                Label1.Visible = true;
                tableList.DataSource = new List<Orders>();
            }
        }
        protected void TableNo(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as Button).NamingContainer as RepeaterItem;
            Order = Convert.ToInt32((item.FindControl("orderno") as Label).Text);

            Referesh_Table();
        }
        void Referesh_Table()
        {
            items = ItemsService.GetItemsByOrderIdList(Order).ToList();
            if (items.Count == 0)
            {
                Orderedlist.DataSource = new List<OrderListDTO>();
                Orderedlist.DataBind();
            }
            else
            {
                Orderedlist.DataSource = items;
                Orderedlist.DataBind();
            }
        }
    }
}