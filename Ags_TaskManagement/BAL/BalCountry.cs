using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Ags_TaskManagement.BAL;

namespace LeadTrix.BAL
{
    public class BalCountry
    {
        public Nullable<int> CountryID { get; set; }
        public Nullable<int> EmployeeID { get; set; }
        public Nullable<bool> IsActive { get; set; }
        [Required(ErrorMessage ="Please Enter Country Code")]
        public string CountryCode { get; set; }
        [Required(ErrorMessage = "Please Enter Country Name")]
        public string CountryName { get; set; }
        public string Remarks { get; set; }
        public string IpSource { get; set; }
        public DataTable dtbl { get; set; }
        public string result { get; set; }
        public string DMLFlag { get; set; }
        public bool GetCountryList()
        {
            SqlConnection connection = new SqlConnection(DbReadConfig.DbConnection);
            try
            {
                SqlCommand command = new SqlCommand("GetCountryList", connection);

                command.CommandType = CommandType.StoredProcedure;
                if (ConnectionState.Closed == connection.State)
                {
                    connection.Open();
                }
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = command;
                dtbl = new DataTable();
                da.Fill(dtbl);
                connection.Close();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                GC.Collect();
            }

            if (dtbl.Rows.Count > 0 && dtbl != null)
            {
                return true;
            }
            else
            {
                return false;

            }
        }

        //public string CountryIUD()
        //{
        //    result = string.Empty;
        //    try
        //    {
        //        SqlConnection connection = new SqlConnection(DbReadConfig.DbConnection);
        //        SqlCommand command = new SqlCommand("CountryIUD", connection);
        //        command.CommandType = CommandType.StoredProcedure;
        //        if (ConnectionState.Closed == connection.State)
        //        {
        //            connection.Open();
        //        }
        //        command.Parameters.AddWithValue("@CountryID", CountryID);
        //        command.Parameters.AddWithValue("@CountryCode", CountryCode);
        //        command.Parameters.AddWithValue("@CountryName", CountryName);
        //        command.Parameters.AddWithValue("@IpSource", IpSource);
        //        command.Parameters.AddWithValue("@remarks", Remarks);
        //        command.Parameters.AddWithValue("@EmployeeID", @EmployeeID);
        //        command.Parameters.AddWithValue("@IsActive", IsActive);
        //        command.Parameters.AddWithValue("@DMLFlag", DMLFlag);

        //        result = Convert.ToString(command.ExecuteScalar());
        //        connection.Close();
        //    }
        //    catch(Exception ex)
        //    {
        //        ex.ToString();
        //    }
        //    finally
        //    {
        //        GC.Collect();
        //    }
            
        //    return result;
        //}
    }
}