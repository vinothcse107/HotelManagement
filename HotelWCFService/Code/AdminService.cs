using HotelWCFService.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HotelWCFService
{
    public partial class HotelService
    {
        public bool AddItemsToMenu(Items Item)
        {
            bool x = false;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "dbo.AddItemToMenu";
                cmd.Parameters.Add(new SqlParameter("@ItemName", Item.ItemName));
                cmd.Parameters.Add(new SqlParameter("@Price", Item.Price));
                cmd.Parameters.Add(new SqlParameter("@CategoryId", Item.FoodCategoryId));

                cmd.CommandType = CommandType.StoredProcedure;

                x = GenCon.NonQuery(cmd);
            }
            return x;
        }

        public bool DeleteItemsFromMenu(int ItemId)
        {
            // DeleteItem
            bool x = false;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "dbo.DeleteItem";
                cmd.Parameters.Add(new SqlParameter("@ItemId", ItemId));
                cmd.CommandType = CommandType.StoredProcedure;

                x = GenCon.NonQuery(cmd);
            }
            return x;
        }

        public bool AddTables()
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = @" declare @i int; 
                                    set @i = (select count(*) from CusTable)+ 1;
                                    INSERT INTO CusTable values ( @i , 0);";
                bool x = GenCon.NonQuery(cmd);
                return x;
            }
        }
    }
}