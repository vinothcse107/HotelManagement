using HotelWCFService.DTO;
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
        public ResponseDTO Login(LoginDTO user)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = $"SELECT TOP 1 * FROM Users u WHERE  u.Username = '{user.Username}';";
                DataTable dt = GenCon.Executor(cmd);
                var x = dt.Rows[0][1].ToString();
                var y = dt.Rows[0][2].ToString();
                var Id = Convert.ToInt32(dt.Rows[0][0]);

                if (user.Username.Equals(x) && user.Password.Equals(y))
                {
                    ResponseDTO rt = new ResponseDTO()
                    {
                        userId = Id,
                        access = true,
                        message = "Access Allowed"
                    };
                    return rt;
                }
                else
                {
                    ResponseDTO rt = new ResponseDTO()
                    {
                        userId = -1,
                        access = false,
                        message = "Invalid Access"
                    };
                    return rt;
                }
            }
        }

        public bool AddAccount(Users user)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = $"INSERT INTO Users VALUES ('{user.Username}' , '{user.Password}' , '{user.Phone}' , {user.Roleid});";
                return GenCon.NonQuery(cmd);
            }
        }

        public DataTable GetRoles()
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = $"SELECT * FROM ROLE";
                return GenCon.Executor(cmd);
            }
        }

        public bool DeleteAccount(string username)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = $"DeleteUser";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("username", username);
                cmd.Parameters.Add(p);

                DataTable dt = GenCon.Executor(cmd);
                var x = Convert.ToInt32(dt.Rows[0][0]) > 0 ? true : false;
                return x;
            }
        }
    }
}