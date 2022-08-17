using HotelManagement.HotelService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelManagement.Waiter
{
    public partial class ItemList : System.Web.UI.Page
    {
        ItemsServiceClient ItemsService = new ItemsServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            var ses = (SessionDTO)Session["user"];
            if (!(ses != null && ses.role.Equals("waiter") && ses.sid != null))
            {
                Response.Redirect("~/https://localhost:44341/Waiter/ItemList.aspx.csPages/Login.aspx");
            }
            var x = ItemsService.OrderByWaiter(4).ToList();


            //foreach (var v in x)
            //{
            //    Response.Write(v.OrderId + " ");
            //    for (int i = 0; i < v.ItemName.Length; i++)
            //    {
            //        Response.Write(v.ItemName[i] + " ");
            //        Response.Write(v.Price[i] + " ");
            //        Response.Write(v.Quantity[i] + " ");
            //    }
            //}
        }

    }
}