using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.Web;
using HotelWCFService.Models;
using HotelWCFService.DTO;

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

                DataTable dt = GenCon.Executor(cmd);
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
        // Used in Admin Delete Menu Page
        public DataTable GetMenu()
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "Select ItemId, ItemName as Dish, Price from Items WHERE ItemActive = 1;";
                DataTable dt = GenCon.Executor(cmd);
                return dt;
            }
        }
        public DataTable GetCategory()
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "select * from FoodCategory;";
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
        public List<OrderListDTO> GetOrderItemsForTableList(int TableNo)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "dbo.GetAllOrderedItemsForTable";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@TableNo", TableNo);
                cmd.Parameters.Add(p);

                return GenConList<OrderListDTO>.ExecutorGen(cmd);
            }
        }
        public List<Tables> GetTableList()
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = $"Select TableId from CusTable;";
                return GenConList<Tables>.ExecutorGen(cmd);
            }
        }
        public List<Items> GetItemsList()
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = $"Select * from Items WHERE ItemActive = 1;";
                return GenConList<Items>.ExecutorGen(cmd);
            }
        }
        public List<Items> GetMenuByCategoryId(int CategoryId)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = $"Select * from Items i where i.FoodCategoryId = {CategoryId} AND i.ItemActive = 1;";
                return GenConList<Items>.ExecutorGen(cmd);
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
                cmd.CommandText = $"DELETE FROM Order_Items_Link WHERE OrderId = {order.OderId} AND ItemId = {order.ItemId}";
                return GenCon.NonQuery(cmd);
            }
        }

        public List<GroupByOrderList> OrderByWaiter(int WaiterId)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = $"OrdersPlacedByWaiter";
                cmd.Parameters.Add(new SqlParameter("@WaiterId", WaiterId));
                cmd.CommandType = CommandType.StoredProcedure;
                var list = GenConList<WaiterOrderList>.ExecutorGen(cmd);

                var y = list.GroupBy(i => i.OrderId).Select(s =>
                                new GroupByOrderList
                                {
                                    OrderId = s.Key,
                                    Items = s.Select(x =>
                                                    new OrderList
                                                    {
                                                        ItemName = x.ItemName,
                                                        Quantity = x.Quantity,
                                                        Price = x.Price
                                                    }).ToList()
                                }
                ).ToList();
                return y;
            }
        }
    }
}