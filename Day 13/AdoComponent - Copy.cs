using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
/*
 * ClassLibrary project type should be choosen for creating DLLs. 
 * DLL Projects dont execute. They are pre-compiled Units, so its not an EXE. It will be used in other EXEs.
 * The Classes inside the Project will be public(Not always). If U dont mention public, the class will be available only within the current Project, in this case, the purpose is lost if U dont make a class public. The reason is DLLs are designed to be consumed by other Projects(Apps). 
 * However, U might abstract a class by not making it public and expose it thro' Factory pattern as an interface object.
 * For setting ConnectionStrings, it is recommended to use Config file which is an XML based file and read the CS from it. 
 */
namespace SampleDll
{
    public interface IDBComponent
    {
        void AddEmployee(int id, string name, string address, string contact, double salary, int deptId);
        void UpdateEmployee(int id, string name, string address, string contact, double salary, int deptId);
        void DeleteEmployee(int id);
        DataTable GetAllEmployees();
    }

    public static class ComponentFactory
    {
        public static IDBComponent GetComponent()
        {
            return new DatabaseComponent();
        }
    }
    class DatabaseComponent : IDBComponent
    {
        static string strCon = ConfigurationManager.ConnectionStrings["myCon"].ConnectionString;
        const string STRSELECT = "SELECT * FROM TBLEMPLOYEE";
        const string STRINSERT = "INSERT INTO TBLEMPLOYEE VALUES(@id, @name, @address, @contact, @salary, @dept)";
        const string STRDELETE = "DELETE FROM TBLEMPLOYEE WHERE EMPID = @empId";
        const string STRUPDATE = "DO IT URSELF!!!!";

        //Helper Function used to perform common operations. This function is used for Insert, Delete and Update only
        private void Execute(SqlCommand cmd)
        {
            SqlConnection con = new SqlConnection(strCon);
            cmd.Connection = con;
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public void AddEmployee(int id, string name, string address, string contact, double salary, int deptId)
        {
            SqlCommand cmd = new SqlCommand(STRINSERT);//No association with Connection as of now....
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@address", address);
            cmd.Parameters.AddWithValue("@contact", contact);
            cmd.Parameters.AddWithValue("@salary", salary);
            cmd.Parameters.AddWithValue("@dept", deptId);
            Execute(cmd);
        }

        public void DeleteEmployee(int id)
        {
            SqlCommand cmd = new SqlCommand(STRDELETE);//No association with Connection as of now....
            cmd.Parameters.AddWithValue("@id", id);
            Execute(cmd);
        }

        public DataTable GetAllEmployees()
        {
            SqlConnection con = new SqlConnection(strCon);
            SqlCommand cmd = new SqlCommand(STRSELECT, con);
            try
            {
                con.Open();
                var reader = cmd.ExecuteReader();
                DataTable table = new DataTable("AnyName");
                table.Load(reader);//This will internally read all the records and store it in the table.
                return table;
            }
            catch(SqlException ex)
            {
                throw new Exception("Get All Records have failed");
            }
            finally
            {
                con.Close();
            }
        }

        public void UpdateEmployee(int id, string name, string address, string contact, double salary, int deptId)
        {
            SqlCommand cmd = new SqlCommand(STRUPDATE);//No association with Connection as of now....
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@address", address);
            cmd.Parameters.AddWithValue("@contact", contact);
            cmd.Parameters.AddWithValue("@salary", salary);
            cmd.Parameters.AddWithValue("@dept", deptId);
            Execute(cmd);
        }
    }
}
