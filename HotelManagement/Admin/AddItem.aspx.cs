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
        ItemsServiceClient ItemsService = new ItemsServiceClient();
        AdminServiceClient AdminService = new AdminServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            var ses = (SessionDTO)Session["user"];
            if (ses != null && ses.role.Equals("admin") && ses.sid != null)
            {
                if (!IsPostBack)
                {
                    CategoryDropDownList();
                    RefreshGrid(sender, e);
                }
            }
            else
                Response.Redirect("~/Pages/Login.aspx");
        }
        private void CategoryDropDownList()
        {
            DataTable Tables = ItemsService.GetCategory();
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
                    ItemActive = true
                };
                bool b = AdminService.AddItemsToMenu(i);

                ItemName.Text = "";
                Price.Text = "";
                RefreshGrid(sender, e);
                if (b)
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ToastrNotification", CallToastr("Item Added To Menu successfully", "success", ""), true);
                else
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ToastrNotification", CallToastr("Item Not Added, Error !!!", "error", ""), true);
            }
            else
            {
                Response.Write("Fill All Required Fields");
            }
        }

        protected void Add_Table_Click(object sender, EventArgs e)
        {
            var t = AdminService.AddTables();
            if (t)
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ToastrNotification", CallToastr("Table Added successfully", "success", ""), true);
            else
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ToastrNotification", CallToastr("Something Went Wrong !!! ...Error", "error", ""), true);
        }

        protected void RefreshGrid(object sender, EventArgs e)
        {
            DataTable dt = ItemsService.GetMenu();
            GridView1.DataSource = dt.DefaultView;
            GridView1.DataBind();
        }
        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int x = Convert.ToInt32(e.Values[0]);
            var t = AdminService.DeleteItemsFromMenu(x);

            RefreshGrid(sender, e);
            if (t)
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ToastrNotification", CallToastr("Item Removed successfully", "success", ""), true);
            else
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ToastrNotification", CallToastr("Error !! Item Not Removed", "error", ""), true);
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private string CallToastr(string msg, string status, string func)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("$(document).ready(function () {");
            sb.Append("ToastrNotification('");
            sb.Append(msg);
            sb.Append("','");
            sb.Append(status);
            sb.Append("','");
            sb.Append(func);
            sb.Append("');");
            sb.Append("})");
            return sb.ToString();
        }
    }
}