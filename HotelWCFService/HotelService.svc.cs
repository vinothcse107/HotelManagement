using HotelWCFService.DTO;
using HotelWCFService.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace HotelWCFService
{
    [ServiceContract]
    public interface IAccountService
    {
        [OperationContract]
        ResponseDTO Login(LoginDTO user);

        [OperationContract]
        bool AddAccount(Users user);

        [OperationContract]
        DataTable GetRoles();
    }
    [ServiceContract]
    public interface IHotelService
    {
        [OperationContract]
        DataTable GetTables();
    }

    [ServiceContract]
    public interface IItemsService
    {
        [OperationContract]
        DataTable GetOrderItemsForTable(int TableNo);

        [OperationContract]
        int NewOrderForTable(int TableNo, int WaiterId); // Returns Order Nummber

        [OperationContract]
        int ExistingOrderForTable(int TableNo);

        [OperationContract]
        bool AddItems(Order_Items_Link order);

        [OperationContract]
        DataTable GetItems();

    }

    [ServiceContract]
    public interface IAdminService
    {

        [OperationContract]
        bool AddItemsToMenu(Items Item);
        [OperationContract]
        bool DeleteItemsFromMenu(int ItemId);
        [OperationContract]
        bool AddTables();
    }

    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public partial class HotelService : IHotelService, IItemsService, IAdminService, IAccountService
    {
        public DataTable GetTables()
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "select c.TableId as Value , c.TableId as Data from CusTable c;";
                DataTable dt = GenCon.Executor(cmd);
                return dt;
            }
        }
    }
}

