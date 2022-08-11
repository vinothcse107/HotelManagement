using HotelManagement.HotelService;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelManagement
{
    public partial class _Default : Page
    {
        static HotelServiceClient HotelService = new HotelServiceClient();
        static ItemsServiceClient ItemsService = new ItemsServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(IsPostBack))
            {
                DropDownList();
            }
        }
        protected void GridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            int TableNo = Convert.ToInt32(DropDownList1.SelectedItem.Text);
            DataTable dt = ItemsService.GetOrderItemsForTable(TableNo);
            if (dt.Rows.Count == 0)
            {
                Label2.Text = "Data Not Found";
                GridView.DataSource = new DataTable();
                GridView.DataBind();
            }
            else
            {
                GridView.DataSource = dt.DefaultView;
                GridView.DataBind();
                Label2.Text = "";
            }
        }

        // Bill Amt Generator
        protected void BillButton_Click(object sender, EventArgs e)
        {
            int sum = 0;
            foreach (GridViewRow r in GridView.Rows)
            {
                int x = Convert.ToInt32(r.Cells[1].Text) * Convert.ToInt32(r.Cells[2].Text);
                sum += x;
            }
            Label2.Text = "Total = " + sum.ToString();
        }

        private void DropDownList()
        {
            DataTable Tables = HotelService.GetTables();
            for (int i = 0; i < Tables.Rows.Count; i++)
            {
                DropDownList1.Items.Insert(i, new ListItem(
                    Tables.Rows[i].ItemArray[0].ToString(),
                    Tables.Rows[i].ItemArray[0].ToString())
                    );
            }
            DropDownList1.DataBind();

        }
    }
}