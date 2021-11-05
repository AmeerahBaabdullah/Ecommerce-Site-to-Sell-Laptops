using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using Dapper;
using System.Data.SqlClient;
namespace sell_laptop.Models
{
    public class SqlDataAccess
    {

        public static string GetConnectionString(string connectionName = "LaptopWeb")
        {
            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;

        }
        public static bool CheckData(string sql)
        {

            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return true;
            }
        }


        public static List<T> LoadProduct<T>(string sql)
        {

            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Query<T>(sql).ToList();
            }
        }
        public static List<T> LoadData<T>(string sql)
        {

            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Query<T>(sql).ToList();
            }
        }

        public static int SaveData<T>(string sql, T data)
        {

            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Execute(sql, data);
            }

        }
    }
}