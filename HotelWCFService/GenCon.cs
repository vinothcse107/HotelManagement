using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.Web;

namespace HotelWCFService
{
    public static class GenCon
    {
        public static DataTable Executor(SqlCommand cmd)
        {
            DataTable dt = null;
            SqlDataAdapter adapter = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString))
                {
                    cmd.Connection = connection;
                    adapter = new SqlDataAdapter(cmd);
                    dt = new DataTable("Table");
                    adapter.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }

        }

        public static bool NonQuery(SqlCommand cmd)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString))
                {
                    cmd.Connection = connection;
                    connection.Open();
                    return cmd.ExecuteNonQuery() <= 0 ? false : true;
                }
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }
    }

    public static class GenConList<T> where T : new()
    {
        public static List<T> ExecutorGen(SqlCommand cmd)
        {
            List<T> list = new List<T>();
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString))
                {
                    cmd.Connection = connection;
                    connection.Open();

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            // Method 1
                            //Type Type = typeof(T);
                            //var extendedObject = Activator.CreateInstance(Type);

                            // Method 2
                            Type Type = typeof(T);
                            T t = new T();
                            PropertyInfo[] properties = t.GetType().GetProperties();
                            foreach (var p in properties)
                            {
                                Type.GetProperty(p.Name)
                                      .SetValue(t, rdr[p.Name], null);
                            }
                            list.Add((T)t);
                        };
                    }
                    return list;

                }
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }
    }
}