using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.Web;
using HotelWCFService.Models;

namespace HotelWCFService
{
    public partial class HotelService
    {
        public DataTable GetOrderItemsForTable(int TableNo)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "dbo.GetAllOrderedItemsForTable";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@TableNo", TableNo);
                cmd.Parameters.Add(p);

                DataTable dt = GenCon.Executor(cmd); // Calling a Common Executor method !
                return dt;
            }
        }

        public int NewOrderForTable(int TableNo, int WaiterId)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "dbo.CreateNewOrder";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@TableNo", TableNo);
                SqlParameter o = new SqlParameter("@WaiterId", 4);

                cmd.Parameters.Add(p);
                cmd.Parameters.Add(o);


                DataTable dt = GenCon.Executor(cmd);
                int OrderId = 0;

                if (!(dt.Rows[0][0] is DBNull))
                {
                    OrderId = Convert.ToInt32(dt.Rows[0][0]);
                    return OrderId;
                }
                else
                    return OrderId;
            }
        }


        public int ExistingOrderForTable(int TableNo)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                int x = 0;
                cmd.CommandText = $"SELECT c.OrderId as OrderId from CusTable c WHERE c.TableId = {TableNo}";
                DataTable dt = GenCon.Executor(cmd);
                if (!(dt.Rows[0][0] is DBNull))
                {
                    x = Convert.ToInt32(dt.Rows[0][0]);
                    return x;
                }
                else
                    return x;

            }
        }

        public DataTable GetMenu()
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "Select ItemId, ItemName as Dish, Price from Items WHERE ItemActive = 1;";
                DataTable dt = GenCon.Executor(cmd);
                return dt;
            }

        }
        public DataTable GetItems()
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "Select * from Items WHERE ItemActive = 1;";
                DataTable dt = GenCon.Executor(cmd);
                return dt;
            }
        }

        public bool AddItems(Order_Items_Link order)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "dbo.AddItemstoOrder";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(new SqlParameter[] {
                        new SqlParameter("@ItemId", order.ItemId) ,
                        new SqlParameter("@OrderId", order.OderId),
                        new SqlParameter("@Quantity", order.Quantity)
                    });

                cmd.CommandType = CommandType.StoredProcedure;

                return GenCon.NonQuery(cmd);
            }
        }

        public bool DeleteItemsFromCustomerOrder(Order_Items_Link order)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = $"DELETE FROM Order_Items_Link WHERE OrderId = {order.OderId}  AND ItemId = {order.ItemId}";
                return GenCon.NonQuery(cmd);
            }
        }
    }
}