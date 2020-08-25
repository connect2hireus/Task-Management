using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using Ags_TaskManagement.BAL;


namespace Ags_TaskManagement.BAL
{
    public class Employee
    {
        public Nullable<int> EmployeeID { get; set; }
        public Nullable<int> RoleID { get; set; }
        public string FullName { get; set; }
        public string ProfilePic { get; set; }
        [Required(ErrorMessage = "Please Enter Registered EmailID")]
        public string OfficeEmailID { get; set; }
        [Required(ErrorMessage = "Please Enter Password")]
        public string Password { get; set; }
        public DataTable dtblEmp { get; set; }
        string result { get; set; }
        public bool EmpLogin()
        {
            result = string.Empty;
            SqlConnection connection = new SqlConnection(DbReadConfig.DbConnection);
            SqlCommand command = new SqlCommand("EmpLogin", connection);
            try
            {
                if (ConnectionState.Closed == connection.State)
                {
                    connection.Open();
                }
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@OfficeEmailID", OfficeEmailID);
                command.Parameters.AddWithValue("@Password", Password);
                connection.Close();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = command;
                dtblEmp = new DataTable();
                da.Fill(dtblEmp);
                if (dtblEmp.Rows.Count > 0 && dtblEmp != null)
                {
                    EmployeeID = Convert.ToInt32(dtblEmp.Rows[0]["EmployeeID"]);
                    RoleID = Convert.ToInt32(dtblEmp.Rows[0]["RoleID"]);
                    FullName = Convert.ToString(dtblEmp.Rows[0]["FullName"]);
                    OfficeEmailID = Convert.ToString(dtblEmp.Rows[0]["OfficeEmailID"]);
                    ProfilePic = Convert.ToString(dtblEmp.Rows[0]["ProfilePic"]);
                    result = "Found";
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                GC.Collect();
            }
            if (result == "Found")
                return true;
            else
                return false;
        }
    }
}