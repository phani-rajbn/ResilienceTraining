using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SampleMvcApp.Models
{
    public class EmployeeApi
    {
        public int EmpId { get; set; }
        public String EmpName { get; set; }

        public String EmpAddress { get; set; }
        public String EmpPhone { get; set; }

        public double EmpSalary { get; set; }
        public int DeptId { get; set; }

    }

    public class Dept
    {
        public int DeptId { get; set; }
        public String DeptName { get; set; }
    }
    class ADOApiComponent
    {
        const string STRCONNECTION = @"Data Source=AKSHAY-PC\SQLEXPRESS;Initial Catalog=CSharpProject;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework";
        const string STRSELECT = "SELECT * FROM TBLEMPLOYEE";
        const string STRDEPT = "SELECT * FROM TBLDEPT";
        const string STRFIND = "SELECT * FROM TBLEMPLOYEE WHERE EMPID = @id";
        const string STRINSERT = "INSERT INTO TBLEMPLOYEE VALUES(@id, @name, @address, @phone, @salary,@dept)";
        const string STRUPDATE = "UPDATE TBLEMPLOYEE SET EmpName = @name, EmpAddress = @address, EmpSalary = @salary, EmpPhone = @phone, DeptId = @dept WHERE EmpID = @id";

        //Refer MS ApplicationBlocks SqlHelper for interacting with database. 
        void Execute(SqlCommand cmd)
        {
            var con = new SqlConnection(STRCONNECTION);
            cmd.Connection = con;
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        internal bool Update(EmployeeApi emp)
        {
            var cmd = new SqlCommand(STRUPDATE);
            cmd.Parameters.AddWithValue("@id", emp.EmpId);
            cmd.Parameters.AddWithValue("@name", emp.EmpName);
            cmd.Parameters.AddWithValue("@address", emp.EmpAddress);
            cmd.Parameters.AddWithValue("@phone", emp.EmpPhone);
            cmd.Parameters.AddWithValue("@salary", emp.EmpSalary);
            cmd.Parameters.AddWithValue("@dept", emp.DeptId);
            Execute(cmd);
            return true;
        }
        internal bool Insert(EmployeeApi emp)
        {
            var cmd = new SqlCommand(STRINSERT);
            cmd.Parameters.AddWithValue("@id", emp.EmpId);
            cmd.Parameters.AddWithValue("@name", emp.EmpName);
            cmd.Parameters.AddWithValue("@address", emp.EmpAddress);
            cmd.Parameters.AddWithValue("@phone", emp.EmpPhone);
            cmd.Parameters.AddWithValue("@salary", emp.EmpSalary);
            cmd.Parameters.AddWithValue("@dept", emp.DeptId);
            Execute(cmd);
            return true;
        }
        internal EmployeeApi Find(int id)
        {
            var con = new SqlConnection(STRCONNECTION);//create the connection
            var cmd = new SqlCommand(STRFIND, con);//create the command and associate the Query and Connection
            cmd.Parameters.AddWithValue("@id", id);
            try
            {
                con.Open();//Open the Connection
                var reader = cmd.ExecuteReader();//Execute the command to return a reader object
                while (reader.Read())//read each row...
                {
                    var emp = new EmployeeApi
                    {
                        DeptId = Convert.ToInt32(reader["DeptId"]),
                        EmpAddress = reader["EmpAddress"].ToString(),
                        EmpId = Convert.ToInt32(reader["EmpID"]),
                        EmpName = reader[1].ToString(),
                        EmpSalary = Convert.ToDouble(reader["EmpSalary"]),
                        EmpPhone = reader["EmpPhone"].ToString()
                    };
                    return emp;
                }
                throw new Exception("Employee not found");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        internal List<Dept> GetAllDepts()
        {
            var list = new List<Dept>();
            var con = new SqlConnection(STRCONNECTION);
            var cmd = new SqlCommand(STRDEPT, con);
            try
            {
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var dept = new Dept
                    {
                        DeptId = Convert.ToInt32(reader["DeptID"]),
                        DeptName = reader["DeptName"].ToString()
                    };
                    list.Add(dept);
                }
                return list;
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
        internal List<EmployeeApi> GetAllEmployees()
        {
            var list = new List<EmployeeApi>();//create a blank list...
            var con = new SqlConnection(STRCONNECTION);//create the connection
            var cmd = new SqlCommand(STRSELECT, con);//create the command and associate the Query and Connection
            try
            {
                con.Open();//Open the Connection
                var reader = cmd.ExecuteReader();//Execute the command to return a reader object
                while (reader.Read())//read each row...
                {
                    var emp = new EmployeeApi
                    {
                        DeptId = Convert.ToInt32(reader["DeptId"]),
                        EmpAddress = reader["EmpAddress"].ToString(),
                        EmpId = Convert.ToInt32(reader["EmpID"]),
                        EmpName = reader[1].ToString(),
                        EmpSalary = Convert.ToDouble(reader["EmpSalary"]),
                        EmpPhone = reader["EmpPhone"].ToString()
                    };
                    list.Add(emp);
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
    }
}