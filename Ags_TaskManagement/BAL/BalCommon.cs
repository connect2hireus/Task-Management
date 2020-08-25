using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using Ags_TaskManagement.BAL;
using System.Web.Mvc;

namespace Ags_TaskManagement.BAL
{
    public class BalCommon
    {

    }
    public class Country
    {
        public Nullable<int> CountryID { get; set; }
        public string CountryName { get; set; }
        public DataTable dtbl { get; set; }

        public List<SelectListItem> GetCountry()
        {
            List<SelectListItem> Country = new List<SelectListItem>();
            SqlConnection connection = new SqlConnection(DbReadConfig.DbConnection);
            try
            {
                SqlCommand command = new SqlCommand("SP_CommonForDropdown", connection);
                command.Parameters.AddWithValue("@ActionMode", "Country");

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
                foreach (DataRow dr in dtbl.Rows)
                {
                    SelectListItem List = new SelectListItem();
                    List.Value = Convert.ToString(dr["countryid"]);
                    List.Text = Convert.ToString(dr["countryname"]);
                    Country.Add(List);
                }
                return Country;
            }
            else
            {
                return null;

            }
        }
    }
    public class State
    {
        public Nullable<int> CountryID { get; set; }
        public Nullable<int> StateID { get; set; }
        public string StateName { get; set; }
        public DataTable dtbl { get; set; }
        public List<SelectListItem> GetStateByCountryID()
        {
            List<SelectListItem> State = new List<SelectListItem>();
            SqlConnection connection = new SqlConnection(DbReadConfig.DbConnection);
            try
            {
                SqlCommand command = new SqlCommand("SP_CommonForDropdown", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CountryId", CountryID);
                command.Parameters.AddWithValue("@ActionMode", "State");
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
                foreach (DataRow dr in dtbl.Rows)
                {
                    SelectListItem List = new SelectListItem();
                    List.Value = Convert.ToString(dr["StateID"]);
                    List.Text = Convert.ToString(dr["StateName"]);
                    State.Add(List);
                }
                return State;
            }
            else
            {
                return null;

            }
        }
    }
    public class City
    {
        public Nullable<int> StateID { get; set; }
        public Nullable<int> CityID { get; set; }
        public string CityName { get; set; }
        public DataTable dtbl { get; set; }
        public List<SelectListItem> GetCityByStateID()
        {
            List<SelectListItem> City = new List<SelectListItem>();
            SqlConnection connection = new SqlConnection(DbReadConfig.DbConnection);
            try
            {
                SqlCommand command = new SqlCommand("SP_CommonForDropdown", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@stateid", StateID);
                command.Parameters.AddWithValue("@ActionMode", "City");
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
                foreach (DataRow dr in dtbl.Rows)
                {
                    SelectListItem List = new SelectListItem();
                    List.Value = Convert.ToString(dr["CityID"]);
                    List.Text = Convert.ToString(dr["CityName"]);
                    City.Add(List);
                }
                return City;
            }
            else
            {
                return null;

            }
        }
    }
    public class DesignationMaster
    {
        public string Designation { get; set; }
        public Nullable<int> DesignationID { get; set; }
        public Nullable<int> CompanyID { get; set; }
        public DataTable dtbl { get; set; }
        public List<SelectListItem> GetDesignation()
        {
            List<SelectListItem> Desig = new List<SelectListItem>();
            SqlConnection connection = new SqlConnection(DbReadConfig.DbConnection);
            try
            {
                SqlCommand command = new SqlCommand("SP_CommonForDropdown", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ActionMode", "Designation");
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
                foreach (DataRow dr in dtbl.Rows)
                {
                    SelectListItem List = new SelectListItem();
                    List.Value = Convert.ToString(dr["id"]);
                    List.Text = Convert.ToString(dr["Designation"]);
                    Desig.Add(List);
                }
                return Desig;
            }
            else
            {
                return null;

            }
        }
    }
    public class RoleMaster
    {
        public string RoleName { get; set; }
        public Nullable<int> RoleID { get; set; }
        public Nullable<int> CompanyID { get; set; }
        public DataTable dtbl { get; set; }
        public List<SelectListItem> GetRoleName()
        {
            List<SelectListItem> Role = new List<SelectListItem>();
            SqlConnection connection = new SqlConnection(DbReadConfig.DbConnection);
            try
            {
                SqlCommand command = new SqlCommand("SP_CommonForDropdown", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ActionMode", "Role");
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
                foreach (DataRow dr in dtbl.Rows)
                {
                    SelectListItem List = new SelectListItem();
                    List.Value = Convert.ToString(dr["RoleID"]);
                    List.Text = Convert.ToString(dr["RoleName"]);
                    Role.Add(List);
                }
                return Role;
            }
            else
            {
                return null;

            }
        }
    }

}