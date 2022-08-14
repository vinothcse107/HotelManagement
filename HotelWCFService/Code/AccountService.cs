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
        public enum roles
        {
            Admin = 1,
            Waiter = 2,
            User = 3
        }
        public ResponseDTO Login(LoginDTO user)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = $"SELECT TOP 1 * FROM Users u WHERE  u.Username = '{user.Username}';";
                DataTable dt = GenCon.Executor(cmd);
                if (dt.Rows.Count > 0)
                {
                    var id = Convert.ToInt32(dt.Rows[0][0]);
                    var usr = dt.Rows[0][1].ToString().ToLower();
                    var pwd = dt.Rows[0][2].ToString();
                    var role = ((roles)Convert.ToInt32(dt.Rows[0][4])).ToString();


                    if (user.Username.Equals(usr) && user.Password.Equals(pwd))
                    {
                        ResponseDTO rt = new ResponseDTO()
                        {
                            userId = id,
                            username = usr,
                            role = role,
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
                            message = "Invalid Password"
                        };
                        return rt;
                    }
                }
                else
                {
                    ResponseDTO rt = new ResponseDTO()
                    {
                        userId = -1,
                        access = false,
                        message = "Invalid Username | Password"
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