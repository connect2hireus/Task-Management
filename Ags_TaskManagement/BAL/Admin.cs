using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using Ags_TaskManagement.BAL;
using PagedList;

namespace Ags_TaskManagement.BAL
{
    public class Admin
    {
        public Nullable<int> ProjectId { get; set; }
        [Required(ErrorMessage = "Please select Title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please Enter StartDate")]
        public Nullable<DateTime> StartDate { get; set; }
        [Required(ErrorMessage = "Please Enter EndDate")]
        public Nullable<DateTime> EndDate { get; set; }
        [Required(ErrorMessage = "Please Enter Project Description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please Enter ContactNo")]
        public string ContactNo { get; set; }
        [Required(ErrorMessage = "Please enter Official emailID")]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string EmailId { get; set; }
        public string Websit { get; set; }
        public string ProjectFile { get; set; }
        public string ContactBy { get; set; }
        public string ProjectManager { get; set; }
        public Nullable<int> EmployeeID { get; set; }
        public Nullable<int> CompanyID { get; set; }
        public string EmployeeCode { get; set; }
        [Required(ErrorMessage = "Please select role")]
        public Nullable<int> RoleID { get; set; }
        [Required(ErrorMessage = "Please enter full name")]
        public string FullName { get; set; }
        public string NickName { get; set; }
        public Nullable<DateTime> DateOfBirth { get; set; }
        public Nullable<DateTime> DateofLastIncrement { get; set; }
        public string CommunicationSkill { get; set; }
        [Required(ErrorMessage = "Please enter Official emailID")]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string OfficeEmailID { get; set; }
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string PersonalMailId { get; set; }
        [Required(ErrorMessage = "Please select state")]
        public Nullable<int> JobState { get; set; }
        [Required(ErrorMessage = "Please select city")]
        public Nullable<int> JobCity { get; set; }
        [Required(ErrorMessage = "Please select country")]
        public Nullable<int> JobCountry { get; set; }
        public string JobLocation { get; set; }
        [Required(ErrorMessage = "Please enter pincode")]
        public string ObjPinCode { get; set; }
        [Required(ErrorMessage = "Please enter password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please enter official mobile number")]
        public string OfficeMobileNo { get; set; }
        public string PersonalMobileNumber { get; set; }
        [Required(ErrorMessage = "Please select designation")]
        public Nullable<int> Designation { get; set; }
        public string DesignationName { get; set; }
        public string Qualification { get; set; }
        [Required(ErrorMessage = "Please enter communication address")]
        public string CommunicationAddress { get; set; }
        public string PermanentAddress { get; set; }
        [Required(ErrorMessage = "Please enter PAN number")]
        public string PANNO { get; set; }
        [Required(ErrorMessage = "Please enter Aadhar number")]
        public string AdhaarNo { get; set; }
        public string CTC { get; set; }
        public string Refferedby { get; set; }
        public string ReferencesGiven { get; set; }
        public string FatherOccupasion { get; set; }
        public string MotherOccupasion { get; set; }
        public string SiblingDetails { get; set; }
        public string ReferencesDetail1 { get; set; }
        public string ReferencesDetail2 { get; set; }
        public string PreviousCompanyDetail { get; set; }
        public string BelongFrom { get; set; }
        public string Notes { get; set; }
        public string CustimizedField1 { get; set; }
        public string CustimizedField2 { get; set; }
        public string Facebookid { get; set; }
        public string Linkedinid { get; set; }
        public string ProfilePic { get; set; }
        public Nullable<bool> ShowClientEmail { get; set; }
        public Nullable<bool> ShowClientNo { get; set; }
        public string IPSource { get; set; }
        public Nullable<DateTime> DateofEmployement { get; set; }
        public Nullable<DateTime> SysDate { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string DMLFlag { get; set; }
        public DataTable dtbl { get; set; }
        public Nullable<DateTime> fromDate { get; set; }
        public Nullable<DateTime> todate { get; set; }
        public string fdate { get; set; }
        public string ldate { get; set; }

        public string EmployeeMasterIUD()
        {
            SqlConnection connection = new SqlConnection(DbReadConfig.DbConnection);
            string result = string.Empty;
            try
            {
                
                SqlCommand command = new SqlCommand("SP_EmployeeMasterIUD", connection);
                command.CommandType = CommandType.StoredProcedure;
                if (ConnectionState.Closed == connection.State)
                {
                    connection.Open();
                }
                command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                //command.Parameters.AddWithValue("@CompanyID", CompanyID);
                //command.Parameters.AddWithValue("@EmployeeCode", EmployeeCode);
                //command.Parameters.AddWithValue("@DateofEmployement", DateofEmployement);

                command.Parameters.AddWithValue("@RoleID", RoleID);
                command.Parameters.AddWithValue("@FullName", FullName);
                //command.Parameters.AddWithValue("@NickName", NickName);
                //command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);


                command.Parameters.AddWithValue("@CommunicationSkill", CommunicationSkill);
                command.Parameters.AddWithValue("@OfficeEmailID", OfficeEmailID);
                command.Parameters.AddWithValue("@PersonalMailId", PersonalMailId);
                command.Parameters.AddWithValue("@JobState", JobState);

                command.Parameters.AddWithValue("@JobCity", JobCity);
                command.Parameters.AddWithValue("@JobCountry", JobCountry);
                //command.Parameters.AddWithValue("@JobLocation", JobLocation);
                command.Parameters.AddWithValue("@ObjPinCode", ObjPinCode);

                command.Parameters.AddWithValue("@OfficeMobileNo", OfficeMobileNo);
                command.Parameters.AddWithValue("@PersonalMobileNumber", PersonalMobileNumber);
                //command.Parameters.AddWithValue("@CTC", CTC);
                //command.Parameters.AddWithValue("@DateofLastIncrement", DateofLastIncrement);

                //command.Parameters.AddWithValue("@Refferedby", Refferedby);
                //command.Parameters.AddWithValue("@ReferencesGiven", ReferencesGiven);
                command.Parameters.AddWithValue("@Designation", Designation);
                //command.Parameters.AddWithValue("@Qualification", Qualification);

                //command.Parameters.AddWithValue("@FatherOccupasion", FatherOccupasion);
                //command.Parameters.AddWithValue("@MotherOccupasion", MotherOccupasion);
                //command.Parameters.AddWithValue("@SiblingDetails", SiblingDetails);
                //command.Parameters.AddWithValue("@BelongFrom", BelongFrom);

                //command.Parameters.AddWithValue("@ReferencesDetail1", ReferencesDetail1);
                //command.Parameters.AddWithValue("@ReferencesDetail2", ReferencesDetail2);
                //command.Parameters.AddWithValue("@PreviousCompanyDetail", PreviousCompanyDetail);
                command.Parameters.AddWithValue("@Password", Password);

                command.Parameters.AddWithValue("@CommunicationAddress", CommunicationAddress);
                command.Parameters.AddWithValue("@PermanentAddress", PermanentAddress);
                //command.Parameters.AddWithValue("@Notes", Notes);
               
                //command.Parameters.AddWithValue("@Facebookid", Facebookid);
                //command.Parameters.AddWithValue("@Linkedinid", Linkedinid);
                command.Parameters.AddWithValue("@PANNO", PANNO);

                command.Parameters.AddWithValue("@AdhaarNo", AdhaarNo);
                command.Parameters.AddWithValue("@ProfilePic", ProfilePic);
              //  command.Parameters.AddWithValue("@IPSource", IPSource);
                //command.Parameters.AddWithValue("@IsActive", IsActive);

                //command.Parameters.AddWithValue("@SysDate", SysDate);
                //command.Parameters.AddWithValue("@ShowClientEmail", ShowClientEmail);
                //command.Parameters.AddWithValue("@ShowClientNo", ShowClientNo);
                command.Parameters.AddWithValue("@DMLFlag", "I");
                result = Convert.ToString(command.ExecuteScalar());
                
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                GC.Collect();
                connection.Close();
            }
            return result;
        }
        public string EmployeeMasterUpdateIUD()
        {
            string result = string.Empty;
            try
            {
                SqlConnection connection = new SqlConnection(DbReadConfig.DbConnection);
                SqlCommand command = new SqlCommand("EmployeeMasterIUD", connection);
                command.CommandType = CommandType.StoredProcedure;
                if (ConnectionState.Closed == connection.State)
                {
                    connection.Open();
                }
                command.Parameters.AddWithValue("@EmployeeID", EmployeeID);               
                command.Parameters.AddWithValue("@RoleID", RoleID);
                command.Parameters.AddWithValue("@FullName", FullName);
                command.Parameters.AddWithValue("@OfficeEmailID", OfficeEmailID);
                command.Parameters.AddWithValue("@PersonalMailId", PersonalMailId);
                command.Parameters.AddWithValue("@JobCity", JobCity);
                command.Parameters.AddWithValue("@JobCountry", JobCountry);
                command.Parameters.AddWithValue("@JobLocation", JobLocation);
                command.Parameters.AddWithValue("@OfficeMobileNo", OfficeMobileNo);
                command.Parameters.AddWithValue("@PersonalMobileNumber", PersonalMobileNumber);
                command.Parameters.AddWithValue("@Designation", Designation);
                //command.Parameters.AddWithValue("@Qualification", Qualification);

                //command.Parameters.AddWithValue("@FatherOccupasion", FatherOccupasion);
                //command.Parameters.AddWithValue("@MotherOccupasion", MotherOccupasion);
                //command.Parameters.AddWithValue("@SiblingDetails", SiblingDetails);
                //command.Parameters.AddWithValue("@BelongFrom", BelongFrom);

                //command.Parameters.AddWithValue("@ReferencesDetail1", ReferencesDetail1);
                //command.Parameters.AddWithValue("@ReferencesDetail2", ReferencesDetail2);
                //command.Parameters.AddWithValue("@PreviousCompanyDetail", PreviousCompanyDetail);
                command.Parameters.AddWithValue("@Password", Password);

                command.Parameters.AddWithValue("@CommunicationAddress", CommunicationAddress);
                command.Parameters.AddWithValue("@PermanentAddress", PermanentAddress);
                //command.Parameters.AddWithValue("@Notes", Notes);
                //command.Parameters.AddWithValue("@CustimizedField1", CustimizedField1);

                //command.Parameters.AddWithValue("@CustimizedField2", CustimizedField2);
                //command.Parameters.AddWithValue("@Facebookid", Facebookid);
                //command.Parameters.AddWithValue("@Linkedinid", Linkedinid);
                command.Parameters.AddWithValue("@PANNO", PANNO);

                command.Parameters.AddWithValue("@AdhaarNo", AdhaarNo);
                command.Parameters.AddWithValue("@ProfilePic", ProfilePic);
                //command.Parameters.AddWithValue("@IPSource", IPSource);
                //command.Parameters.AddWithValue("@IsActive", IsActive);

                //command.Parameters.AddWithValue("@SysDate", SysDate);
                //command.Parameters.AddWithValue("@ShowClientEmail", ShowClientEmail);
                //command.Parameters.AddWithValue("@ShowClientNo", ShowClientNo);
                command.Parameters.AddWithValue("DMLFlag", "U");
                //result = Convert.ToString(command.ExecuteScalar());
                SqlDataAdapter adp = new SqlDataAdapter(command);
                command.CommandTimeout = 0;
                DataSet ds = new DataSet();
                adp.Fill(ds, "t");
                DataTable dt = ds.Tables["t"];
                if (dt.Rows[0]["StatusCode"].ToString() == "1")
                {
                    result = dt.Rows[0]["msg"].ToString();
                    //BAL.Utility.MessageBox(divMsg, "success", dt.Rows[0]["msg"].ToString(), txtMessage);

                }
                else
                {
                    result= dt.Rows[0]["msg"].ToString();
                    // BAL.Utility.MessageBox(divMsg, "danger", dt.Rows[0]["msg"].ToString(), txtMessage);
                }

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

        public string ProjectUID()
        {
            string result = String.Empty;
            try
            {

                SqlConnection connection = new SqlConnection(DbReadConfig.DbConnection);
                SqlCommand cmd = new SqlCommand("SP_ProjectUID", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    connection.Open();
                }
                cmd.Parameters.AddWithValue("@ProjectId", ProjectId);
                cmd.Parameters.AddWithValue("@Title", Title);
                cmd.Parameters.AddWithValue("@StartDate", StartDate);
                cmd.Parameters.AddWithValue("@EndDate", EndDate);
                cmd.Parameters.AddWithValue("@Description", Description);
                cmd.Parameters.AddWithValue("@ContactNo", ContactNo);
                cmd.Parameters.AddWithValue("@EmailId", EmailId);
                cmd.Parameters.AddWithValue("@Websit", Websit);
                cmd.Parameters.AddWithValue("@Password", Password);
                cmd.Parameters.AddWithValue("@ProjectFile", ProjectFile);
                cmd.Parameters.AddWithValue("@ContactedBy", ContactBy);
                cmd.Parameters.AddWithValue("@ProjectManager", ProjectManager);
                cmd.Parameters.AddWithValue("@ActionMode", DMLFlag);
                result = Convert.ToString(cmd.ExecuteScalar());
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

        public bool GetProjectByID()
        {
            string result = string.Empty;
            SqlConnection con = new SqlConnection(DbReadConfig.DbConnection);
            try
            {
                SqlCommand cmd = new SqlCommand("GETProjectByID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProjectId", ProjectId);
                cmd.Parameters.AddWithValue("@ActionMode", "GetProjectById");  
                if (ConnectionState.Closed == con.State)
                {
                    con.Open();
                }
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = cmd;
                dtbl = new DataTable();
                adp.Fill(dtbl);
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

        public bool GetProject()
        {
            string result = string.Empty;
            SqlConnection con = new SqlConnection(DbReadConfig.DbConnection);
            try
            {
                SqlCommand cmd = new SqlCommand("GETProjectByID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@fromDate", fromDate);
                cmd.Parameters.AddWithValue("@toDate", todate);
                cmd.Parameters.AddWithValue("@ActionMode", "GetProject");
                if (ConnectionState.Closed == con.State)
                {
                    con.Open();
                }
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = cmd;
                dtbl = new DataTable();
                adp.Fill(dtbl);
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

        public bool GetEmployeeByID()
        {
            SqlConnection connection = new SqlConnection(DbReadConfig.DbConnection);
            SqlCommand command = new SqlCommand("GetEmployeeByID", connection);
            command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
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
            if (dtbl.Rows.Count > 0 && dtbl != null)
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