using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace LeadTrix.BAL
{
    public class BalCompany
    {
        public Nullable <int> CompanyID { get; set; }

        [Required(ErrorMessage ="Please Enter Company Name")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Please Enter Organisation Name")]
        public string OrganizationName { get; set; }

        [Required(ErrorMessage = "Please Enter Company Size")]
        public Nullable <int> CompanySize { get; set; }

        public string GSTNO { get; set; }

        [Required(ErrorMessage = "Please Select Country")]
        public Nullable<int> CountryID { get; set; }

        [Required(ErrorMessage = "Please Select Sate")]
        public Nullable <int> StateID { get; set; }

        [Required(ErrorMessage = "Please Select City")]
        public Nullable <int> CityID { get; set; }

        [Required(ErrorMessage = "Please Enter Mobile No")]
        //[MaxLength(10), MinLength(10)]
        public string MobileNo { get; set; }

        //[MaxLength(10), MinLength(10)]
        public string AlternateMobileNo { get; set; }

        [Required(ErrorMessage = "Please Enter EmailID")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string EmailID { get; set; }

        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string AlternateEmail { get; set; }

        public string CompanyURL { get; set; }

        public string Logo { get; set; }

        [Required(ErrorMessage = "Please Enter Support Pin")]
        //[MaxLength(4),MinLength(4)]
        public Nullable <int> SupportPIN { get; set; }

        [Required(ErrorMessage = "Please Enter Contact Persopn Name")]
        public string ContactPerson { get; set; }

        public string FacebookAccount { get; set; }

        public string TwitterAccount { get; set; }

        public string LinkedINAccount { get; set; }

        [Required(ErrorMessage = "Please Enter Start Date")]
        public Nullable<DateTime> StartDate { get; set; }
        [Required(ErrorMessage = "Please Enter End Date")]
        public Nullable<DateTime> EndDate { get; set; }

        public Nullable <bool> IsKYC { get; set; }

        public Nullable <bool> IsActive { get; set; }

        [Required(ErrorMessage = "Please Enter Billing Address")]
        public string BillingAddress { get; set; }

        [Required(ErrorMessage = "Please Enter Communication Address")]
        public string CommunicationAddress { get; set; }

        public Nullable<DateTime> Sysdate { get; set; }
        public Nullable<bool> Subscription { get; set; }
        public string DMLFlag { get; set; }
        public DataTable dtbl { get; set; }
        public string result { get; set; }
        public string CompanyIUD()
        {
            result = string.Empty;
            SqlConnection connection = new SqlConnection(DbReadConfig.DbConnection);
            try
            {
                SqlCommand command = new SqlCommand("CompanyIUD", connection);
                command.CommandType = CommandType.StoredProcedure;
                if (ConnectionState.Closed == connection.State)
                {
                    connection.Open();
                }
                command.Parameters.AddWithValue("@CompanyID", CompanyID);
                command.Parameters.AddWithValue("@CompanyName", CompanyName);
                command.Parameters.AddWithValue("@OrganizationName", OrganizationName);
                command.Parameters.AddWithValue("@CompanySize", CompanySize);
                command.Parameters.AddWithValue("@GSTNO", GSTNO);
                command.Parameters.AddWithValue("@State", StateID);
                command.Parameters.AddWithValue("@City", CityID);
                command.Parameters.AddWithValue("@Country", CountryID);
                command.Parameters.AddWithValue("@MobileNo", MobileNo);
                command.Parameters.AddWithValue("@AlternateMobileNo", AlternateMobileNo);
                command.Parameters.AddWithValue("@EmailID", EmailID);
                command.Parameters.AddWithValue("@AlternateEmail", AlternateEmail);
                command.Parameters.AddWithValue("@CompanyURL", CompanyURL);
                command.Parameters.AddWithValue("@Logo", Logo);
                command.Parameters.AddWithValue("@SupportPIN", SupportPIN);
                command.Parameters.AddWithValue("@ContactPerson", ContactPerson);
                command.Parameters.AddWithValue("@FacebookAccount", FacebookAccount);
                command.Parameters.AddWithValue("@TwitterAccount", TwitterAccount);
                command.Parameters.AddWithValue("@LinkedINAccount", LinkedINAccount);
                command.Parameters.AddWithValue("@IsKYC", IsKYC);
                command.Parameters.AddWithValue("@IsActive", IsActive);
                command.Parameters.AddWithValue("@Sysdate", Sysdate);
                command.Parameters.AddWithValue("@StartDate", StartDate);
                command.Parameters.AddWithValue("@EndDate", EndDate);
                command.Parameters.AddWithValue("@Subscription", Subscription);
                command.Parameters.AddWithValue("@BillingAddress", BillingAddress);
                command.Parameters.AddWithValue("@CommunicationAddress", CommunicationAddress);
                command.Parameters.AddWithValue("@DMLFlag", DMLFlag);
                result = Convert.ToString(command.ExecuteScalar());
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
           
            return result;
        }
        public bool GetCompany()
        {
            SqlConnection connection = new SqlConnection(DbReadConfig.DbConnection);
            try
            {
                SqlCommand command = new SqlCommand("GetCompany", connection);
                command.CommandType = CommandType.StoredProcedure;
                if (ConnectionState.Closed == connection.State)
                {
                    connection.Open();
                }
                dtbl = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = command;
                da.Fill(dtbl);
            }
            catch(Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                GC.Collect();
            }
            if(dtbl.Rows.Count>0 && dtbl!=null)
            { 
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool GetCompanyByID()
        {
            string result = string.Empty;
            SqlConnection connection = new SqlConnection(DbReadConfig.DbConnection);
            try
            {
                SqlCommand command = new SqlCommand("GetCompanyByID", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CompanyID",CompanyID);
                if (ConnectionState.Closed == connection.State)
                {
                    connection.Open();
                }
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = command;
                dtbl = new DataTable();
                da.Fill(dtbl);
            } 
            catch(Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                GC.Collect();
            }
            if(dtbl.Rows.Count>0 && dtbl!=null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}