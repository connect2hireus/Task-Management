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
    public class TaskMaster
    {
        public Nullable<int> TaskId { get; set; }
        
        [Required(ErrorMessage = "*")]
        public Nullable<int> ProjectId { get; set; }
        public Nullable<int> EmployeeId { get; set; }
        [Required(ErrorMessage = "*")]
        public string TaskTitle { get; set; }
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


        public string TaskMasterUID()
        {
            string result = String.Empty;
            SqlConnection connection = new SqlConnection(DbReadConfig.DbConnection);
            SqlCommand cmd = new SqlCommand("SP_TaskMaster", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProjectId", ProjectId);
            cmd.Parameters.AddWithValue("@EmployeeId", EmployeeId);
            cmd.Parameters.AddWithValue("@TaskTitle", TaskTitle);
            cmd.Parameters.AddWithValue("@Duration", Duration);
            cmd.Parameters.AddWithValue("@Remark", Reamrk);
            cmd.Parameters.AddWithValue("@TaskId", TaskId);
            cmd.Parameters.AddWithValue("@ActionMode", "Insert");
            try
            {
                connection.Open();
                result = cmd.ExecuteScalar().ToString();
                connection.Close();
            }
            catch (Exception ex)
            {


            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {

                    connection.Close();
                }
                GC.Collect();
            }
            return result;
        }

        public List<TaskMaster> ProjectDropdowndata()
        {
            List<TaskMaster> listitem = new List<TaskMaster>();
            SqlConnection connection = new SqlConnection(DbReadConfig.DbConnection);
            SqlCommand cmd = new SqlCommand("SP_CommonForDropdown", connection);
            cmd.Parameters.AddWithValue("@ActionMode", "SymptomsRecord");
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
                    TaskMaster gr = new TaskMaster();

                    if (!dr.IsNull("Title"))
                    {
                        gr.Title = dr["Title"].ToString();
                    }
                    if (!dr.IsNull("ProjectId"))
                    {
                        gr.ProjectId = Convert.ToInt32(dr["ProjectId"]);
                    }


                    listitem.Add(gr);
                }
            }
            return listitem.ToList();
        }

        public List<TaskMaster> SearchTaskMaster()
        {
            List<TaskMaster> listitem = new List<TaskMaster>();
            SqlConnection connection = new SqlConnection(DbReadConfig.DbConnection);
            SqlCommand cmd = new SqlCommand("Sp_FetchTaskMaster", connection);
            cmd.Parameters.AddWithValue("@EmployeeId", EmployeeId);
            cmd.Parameters.AddWithValue("@fromDate", fromDate);
            cmd.Parameters.AddWithValue("@toDate", toDate);
            cmd.Parameters.AddWithValue("@ActionMode", "FetchTaskMaster");
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
                    TaskMaster gr = new TaskMaster();

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

                    listitem.Add(gr);
                }
            }
            return listitem.ToList();
        }

    }

   
}