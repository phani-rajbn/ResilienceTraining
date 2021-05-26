using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
//Data Access Models for connecting to the database and perform Data related operations. 
//ADO.NET, LINQ, ENTITY FRAMEWORK
//ADO.NET was the first in .NET to work on Data Access. 
//ADO.NET has created seperate namespaces for each kind of database. U can download the DLLs for specific Databases from their respective websites. They contain seperate classes for each kind of database for optimization purposes. Each class is designed to work exclusively for that DB only. 
//ADO.NET has ready to use APIs for SQL server and U dont need to download any further DLLs. 
//ADO.NET is designed to work on any kind of databases. 
//System.Data.SqlClient namespace is used to use the Classes for SQL server. 
//For connecting to the database: SqlConnection Class
//For passing queries: SqlCommand Class. Queries can be executed using ExecuteReader(SELECT), ExecuteNonQuery(INSERT, DELETE, UPDATE) and ExecuteScalar(_________).
//For Reading data from SELECT queries: SqlDataReader class.
namespace DatabaseApps
{
    class Employee
    {
        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public string EmpAddress { get; set; }
        public double EmpSalary { get; set; }
        public int DeptId { get; set; }
        public string PhoneNo { get; set; }

        public override string ToString()
        {
            return string.Format($"{EmpName} from {EmpAddress} earns a salary of {EmpSalary}");
        }
    }
    class ConnectedModel
    {
        //ConnectionString is important as it contains the info required to connect to the database: ServerName, DBName, UserName, Password, CredentialType...
        const string CONNECTIONSTRING = @"Data Source=AKSHAY-PC\SQLEXPRESS;Initial Catalog=CSharpProject;Integrated Security=True";
        const string SELECT = "SELECT * FROM TBLEMPLOYEE";
        const string UPDATESTATEMENT = "UpdateEmployee";//set the name of the Stored proc...

        internal static void ConnectToDB()
        {
            SqlConnection con = new SqlConnection(CONNECTIONSTRING);
            SqlCommand cmd = new SqlCommand(SELECT, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
                Console.WriteLine(reader[1]);
            con.Close();
        }
        
        private static Employee createEmployee(SqlDataReader reader)
        {
            Employee emp = new Employee//populate columns into respective Employee's properties.
            {
                EmpID = Convert.ToInt32(reader[0]),
                EmpName = reader[1].ToString(),
                EmpAddress = reader[2].ToString(),
                PhoneNo = reader[3].ToString(),
                EmpSalary = Convert.ToDouble(reader[4]),
                DeptId = int.Parse(reader[5].ToString())
            };
            return emp;
        }
        internal static List<Employee> GetAllEmployees()
        {
            List<Employee> all = new List<Employee>();//create a empty list of Employees
            SqlConnection con = new SqlConnection(CONNECTIONSTRING);//create the connection
            SqlCommand cmd = new SqlCommand(SELECT, con);//create the command with requried statement
            try
            {
                con.Open();//Open the connection
                var reader = cmd.ExecuteReader();//execute the Command to return a reader object. 
                if (!reader.HasRows)//Check for empty rows....
                    throw new Exception("No Data populated to the Table");
                while (reader.Read())//read each row in a while loop
                {
                    var emp = createEmployee(reader);
                    all.Add(emp);//Add the object to the list
                }
                return all;//return the list
            }
            catch (SqlException)//handle any exceptions
            {
                throw new Exception("Reading has failed");
            }
            finally//last block to execute
            {
                con.Close();//Close the connection.
            }
        }

        internal static List<Employee> FindEmployee(string name)
        {
            string strQUERY = $"select * from tblEmployee where EmpName like '%{name}%'";
            SqlConnection con = new SqlConnection(CONNECTIONSTRING);
            SqlCommand cmd = new SqlCommand(strQUERY, con);
            List<Employee> list = new List<Employee>();
            try
            {
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(createEmployee(reader));
                }
                return list;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        private static void Execute(String statement)
        {
            //ExecuteNonQuery is used when UR command statement does not have SELECT in it...
            SqlConnection con = new SqlConnection(CONNECTIONSTRING);
            SqlCommand cmd = new SqlCommand(statement, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                throw new Exception("Insertion failed");
            }
            finally
            {
                con.Close();
            }
        }
        internal static void InsertEmployee(Employee emp)
        {
            string query = $"Insert into tblEmployee values({emp.EmpID}, '{emp.EmpName}','{emp.EmpAddress}','{emp.PhoneNo}', {emp.EmpSalary} , {emp.DeptId})";
            Execute(query);
            Console.WriteLine("Employee Inserted");

        }

        internal static void UpdateEmployee(Employee emp)
        {
            SqlConnection con = new SqlConnection(CONNECTIONSTRING);
            SqlCommand cmd = new SqlCommand(UPDATESTATEMENT, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", emp.EmpID);
            cmd.Parameters.AddWithValue("@name", emp.EmpName);
            cmd.Parameters.AddWithValue("@address", emp.EmpAddress);
            cmd.Parameters.AddWithValue("@phone", emp.PhoneNo);
            cmd.Parameters.AddWithValue("@sal", emp.EmpSalary);
            cmd.Parameters.AddWithValue("@dept", emp.DeptId);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
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
//ToDo:
/*
 * Create a Table called Review: ReviewID, MovieName, ReviewDetails, Rating.
 * Create an interface called IMovieReview with all CRU functions
 * IMplement the interface with Connected model code
 * Call the interface object in the Console App with Menu driven Application.
 */