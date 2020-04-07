using System;
using System.Data.SqlClient;

namespace WebApplication.Services
{
    public class SQLser : ISQLser
    {
        public bool CheckIndex(string id) 
        {
            try
            {
                using (var con = new SqlConnection("Data Source=db-mssql;Initial Catalog=s19027;Integrated Security=True"))
                using (var com = new SqlCommand())
                {
                    com.Connection = con;
                    com.CommandText = "select * from Student where IndexNumber=\'"+id+"\'";
                    con.Open();
                    var dr = com.ExecuteReader();
                    if (dr.Read())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return false;
        }
    }
}