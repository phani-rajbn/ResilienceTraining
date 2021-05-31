using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace SampleMvcApp.Models
{
    public class ADOComponent
    {
        static String strCon = ConfigurationManager.ConnectionStrings["myCon"].ConnectionString;
        public DataTable GetAll()
        {
            var con = new SqlConnection(strCon);
            var cmd = new SqlCommand("SELECT * FROM TBLEMPLOYEE", con);
            try
            {
                con.Open();
                var data = cmd.ExecuteReader();
                var table = new DataTable();
                table.Load(data);
                return table;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }
    }
}