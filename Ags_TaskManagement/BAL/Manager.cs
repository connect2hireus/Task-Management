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
    public class Manager
    {
        public Nullable<int> TaskId { get; set; }
       
        [Required(ErrorMessage = "*")]
        public Nullable<int> Projectid { get; set; }
        public Nullable<int> countryid { get; set; }
        public Nullable<int> CityID { get; set; }
        public Nullable<int> StateID { get; set; }
        public Nullable<int> EmployeeId { get; set; }
        public Nullable<int> id { get; set; }
        public Nullable<int> RoleID { get; set; }
        [Required(ErrorMessage = "*")]
        public string TaskTitle { get; set; }
        public string ProjectTitle { get; set; }
        [Required(ErrorMessage = "*")]
        public Nullable<DateTime> Date { get; set; }
        [Required(ErrorMessage = "*")]
        public string Duration { get; set; }
        [Required(ErrorMessage = "*")]
        public string Reamrk { get; set; }
        public string result { get; set; }
        public DataTable dtresult { get; set; }
        public Nullable<bool> TaskVerified { get; set; }
        public string VerfiedBy { get; set; }
        public string Title { get; set; }     
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> TaskVerfied { get; set; }
        public Nullable<DateTime> fromDate { get; set; }
        public Nullable<DateTime> toDate { get; set; }
        public string EmployeName { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string TaskDate { get; set; }
        public string Website { get; set; }
        public string Description { get; set; }
        public string PersonalMobileNumber { get; set; }
        public string ProjectManager { get; set; }
        public string countryname { get; set; }
        public string Designation { get; set; }
        public string RoleName { get; set; }
        public string CityName { get; set; }
        public string StateName { get; set; }
        public string ProfilePic { get; set; }
        public string FullName { get; set; }
        public string OfficeEmailID { get; set; }
        public DataTable dtbl { get; set; }



        public List<Manager> SearchTaskMasterForManager()
        {
            List<Manager> listitem = new List<Manager>();
            SqlConnection connection = new SqlConnection(DbReadConfig.DbConnection);
            SqlCommand cmd = new SqlCommand("Sp_FetchTaskMaster", connection);
           // cmd.Parameters.AddWithValue("@ProjectId", ProjectId);
            cmd.Parameters.AddWithValue("@fromDate", fromDate);
            cmd.Parameters.AddWithValue("@toDate", toDate);
            cmd.Parameters.AddWithValue("@ActionMode", "FetchProjectReportForManageer");
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter();
            if (ConnectionState.Closed == connection.State)
            {
                connection.Open();
            }
            sda.SelectCommand = cmd;
            dtresult = new DataTable();
            sda.Fill(dtresult);

            if (dtresult.Rows.Count > 0 && dtresult != null)
            {
                foreach (DataRow dr in dtresult.Rows)
                {
                    Manager gr = new Manager();
                    if (!dr.IsNull("Projectid"))
                    {
                        gr.Projectid = Convert.ToInt32(dr["Projectid"]);
                    }
                    if (!dr.IsNull("Title"))
                    {
                        gr.Title = dr["Title"].ToString();
                    }
                    if (!dr.IsNull("TaskTitle"))
                    {
                        gr.TaskTitle = dr["TaskTitle"].ToString();
                    }
                    if (!dr.IsNull("Duration"))
                    {
                        gr.Duration = dr["Duration"].ToString();
                    }
                    
                    if (!dr.IsNull("EmployeName"))
                    {
                        gr.EmployeName = dr["EmployeName"].ToString();
                    }
                    if (!dr.IsNull("StartDate"))
                    {
                        gr.StartDate = dr["StartDate"].ToString();
                    }
                    if (!dr.IsNull("EndDate"))
                    {
                        gr.EndDate = dr["EndDate"].ToString();
                    }


                    listitem.Add(gr);
                }
            }
            return listitem.ToList();
        }

        public List<Manager> ProjectCompleteDetail()
        {
            List<Manager> listitem = new List<Manager>();
            SqlConnection connection = new SqlConnection(DbReadConfig.DbConnection);
            SqlCommand cmd = new SqlCommand("Sp_FetchTaskMaster", connection);
            cmd.Parameters.AddWithValue("@ProjectId", Projectid);
            //cmd.Parameters.AddWithValue("@fromDate", fromDate);
            //cmd.Parameters.AddWithValue("@toDate", toDate);
            cmd.Parameters.AddWithValue("@ActionMode", "ProjectDetail");
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter();
            if (ConnectionState.Closed == connection.State)
            {
                connection.Open();
            }
            sda.SelectCommand = cmd;
            dtresult = new DataTable();
            sda.Fill(dtresult);

            if (dtresult.Rows.Count > 0 && dtresult != null)
            {
                foreach (DataRow dr in dtresult.Rows)
                {
                    Manager gr = new Manager();

                    if (!dr.IsNull("Title"))
                    {
                        gr.Title = dr["Title"].ToString();
                    }
                    if (!dr.IsNull("ProjectManager"))
                    {
                        gr.ProjectManager = dr["ProjectManager"].ToString();
                    }
                    if (!dr.IsNull("Description"))
                    {
                        gr.Description = dr["Description"].ToString();
                    }
                    if (!dr.IsNull("Websit"))
                    {
                        gr.Website = dr["Websit"].ToString();
                    }
                    //if (!dr.IsNull("EmployeName"))
                    //{
                    //    gr.EmployeName = dr["EmployeName"].ToString();
                    //}
                    if (!dr.IsNull("StartDate"))
                    {
                        gr.StartDate = dr["StartDate"].ToString();
                    }
                    if (!dr.IsNull("EndDate"))
                    {
                        gr.EndDate = dr["EndDate"].ToString();
                    }

                    listitem.Add(gr);
                }
            }
            return listitem.ToList();
        }

        public List<Manager> TaskCompleteDetail()
        {
            List<Manager> listitem = new List<Manager>();
            SqlConnection connection = new SqlConnection(DbReadConfig.DbConnection);
            SqlCommand cmd = new SqlCommand("Sp_FetchTaskMaster", connection);
             cmd.Parameters.AddWithValue("@ProjectId", Projectid);
            //cmd.Parameters.AddWithValue("@fromDate", fromDate);
            //cmd.Parameters.AddWithValue("@toDate", toDate);
            cmd.Parameters.AddWithValue("@ActionMode", "TaskDetail");
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter();
            if (ConnectionState.Closed == connection.State)
            {
                connection.Open();
            }
            sda.SelectCommand = cmd;
            dtresult = new DataTable();
            sda.Fill(dtresult);

            if (dtresult.Rows.Count > 0 && dtresult != null)
            {
                foreach (DataRow dr in dtresult.Rows)
                {
                    Manager gr = new Manager();

                    if (!dr.IsNull("ProjectTitle"))
                    {
                        gr.ProjectTitle = dr["ProjectTitle"].ToString();
                    }
                    if (!dr.IsNull("EmployeeName"))
                    {
                        gr.EmployeName = dr["EmployeeName"].ToString();
                    }
                    if (!dr.IsNull("TaskTitle"))
                    {
                        gr.TaskTitle = dr["TaskTitle"].ToString();
                    }                   
                    if (!dr.IsNull("TaskDate"))
                    {
                        gr.TaskDate = dr["TaskDate"].ToString();
                    }
                    if (!dr.IsNull("Duration"))
                    {
                        gr.Duration = dr["Duration"].ToString();
                    }
                    if (!dr.IsNull("Reamrk"))
                    {
                        gr.Reamrk = dr["Reamrk"].ToString();
                    }

                    listitem.Add(gr);
                }
            }
            return listitem.ToList();
        }


        public List<Manager> DesignationDropdowndata()
        {
            List<Manager> listitem = new List<Manager>();
            SqlConnection connection = new SqlConnection(DbReadConfig.DbConnection);
            SqlCommand cmd = new SqlCommand("SP_CommonForDropdown", connection);
            cmd.Parameters.AddWithValue("@ActionMode", "Designation");
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter();
            if (ConnectionState.Closed == connection.State)
            {
                connection.Open();
            }
            sda.SelectCommand = cmd;
            dtresult = new DataTable();
            sda.Fill(dtresult);

            if (dtresult.Rows.Count > 0 && dtresult != null)
            {
                foreach (DataRow dr in dtresult.Rows)
                {
                    Manager gr = new Manager();

                    if (!dr.IsNull("Designation"))
                    {
                        gr.Designation = dr["Designation"].ToString();
                    }
                    if (!dr.IsNull("id"))
                    {
                        gr.id = Convert.ToInt32(dr["id"]);
                    }


                    listitem.Add(gr);
                }
            }
            return listitem.ToList();
        }

        public List<Manager> RoleDropdowndata()
        {
            List<Manager> listitem = new List<Manager>();
            SqlConnection connection = new SqlConnection(DbReadConfig.DbConnection);
            SqlCommand cmd = new SqlCommand("SP_CommonForDropdown", connection);
            cmd.Parameters.AddWithValue("@ActionMode", "Role");
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter();
            if (ConnectionState.Closed == connection.State)
            {
                connection.Open();
            }
            sda.SelectCommand = cmd;
            dtresult = new DataTable();
            sda.Fill(dtresult);

            if (dtresult.Rows.Count > 0 && dtresult != null)
            {
                foreach (DataRow dr in dtresult.Rows)
                {
                    Manager gr = new Manager();

                    if (!dr.IsNull("RoleName"))
                    {
                        gr.RoleName = dr["RoleName"].ToString();
                    }
                    if (!dr.IsNull("RoleID"))
                    {
                        gr.RoleID = Convert.ToInt32(dr["RoleID"]);
                    }


                    listitem.Add(gr);
                }
            }
            return listitem.ToList();
        }

        public List<Manager> SearchEmpoloyee()
        {
            List<Manager> listitem = new List<Manager>();
            SqlConnection connection = new SqlConnection(DbReadConfig.DbConnection);
            SqlCommand cmd = new SqlCommand("SP_EmployeeReport", connection);
            // cmd.Parameters.AddWithValue("@ProjectId", ProjectId);
            cmd.Parameters.AddWithValue("@fromDate", fromDate);
            cmd.Parameters.AddWithValue("@toDate", toDate);
            cmd.Parameters.AddWithValue("@ActionMode", "FetchEmployee");
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter();
            if (ConnectionState.Closed == connection.State)
            {
                connection.Open();
            }
            sda.SelectCommand = cmd;
            dtresult = new DataTable();
            sda.Fill(dtresult);

            if (dtresult.Rows.Count > 0 && dtresult != null)
            {
                foreach (DataRow dr in dtresult.Rows)
                {
                    Manager gr = new Manager();
                    if (!dr.IsNull("EmployeeID"))
                    {
                        gr.EmployeeId = Convert.ToInt32(dr["EmployeeID"]);
                    }
                    if (!dr.IsNull("ProfilePic"))
                    {
                        gr.ProfilePic = dr["ProfilePic"].ToString();
                    }
                    if (!dr.IsNull("FullName"))
                    {
                        gr.FullName = dr["FullName"].ToString();
                    }
                    if (!dr.IsNull("OfficeEmailID"))
                    {
                        gr.OfficeEmailID = dr["OfficeEmailID"].ToString();
                    }

                    if (!dr.IsNull("Designation"))
                    {
                        gr.Designation = dr["Designation"].ToString();
                    }
                    if (!dr.IsNull("PersonalMobileNumber"))
                    {
                        gr.PersonalMobileNumber = dr["PersonalMobileNumber"].ToString();
                    }
                   


                    listitem.Add(gr);
                }
            }
            return listitem.ToList();
        }


       
    }
}