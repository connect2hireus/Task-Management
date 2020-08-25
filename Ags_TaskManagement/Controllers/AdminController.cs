using Ags_TaskManagement.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace Ags_TaskManagement.Controllers
{
  
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Dashboard(string fromDate, string toDate, int? page)
        {
            List<Manager> listitem = new List<Manager>();
            Manager task = new Manager();
            if (fromDate != "" && fromDate != null)
            {
                task.fromDate = Convert.ToDateTime(fromDate);
            }

            if (toDate != "" && toDate != null)
            {
                task.toDate = Convert.ToDateTime(toDate);
            }
            listitem = task.SearchEmpoloyee();
            ViewData["SearchEmployee"] = listitem.ToPagedList(page ?? 1, 10);
            return View();
        }

        [Authorize]
        [HttpGet]
        public ActionResult CreateEmployee()
        {
            Country country = new Country();
            List<SelectListItem> Country = new List<SelectListItem>();
            List<SelectListItem> designation = new List<SelectListItem>();
            List<SelectListItem> role = new List<SelectListItem>();

            Country = country.GetCountry();
            if (country != null)
            {
                ViewBag.Country = Country;
            }

            ViewBag.Designation = GETDROPDOWNDesignation();
            ViewBag.Role = GETDROPDOWNROLE();
            return View();

        }

        [Authorize]
        [HttpPost]
        public ActionResult CreateEmployee(Admin employee, HttpPostedFileBase ProfilePic)
        {

            string result = string.Empty;
            string path = string.Empty;
            Admin objEmp = new Admin();
            try
            {

                objEmp.CompanyID = Convert.ToInt32(User.Identity.Name.Split('|')[0]);
                if (employee.RoleID > 0)
                {
                    objEmp.RoleID = employee.RoleID;
                }
                if (employee.FullName != "" && employee.FullName != null)
                {
                    objEmp.FullName = employee.FullName;
                }
                if (employee.CommunicationSkill != "" && employee.CommunicationSkill != null)
                {
                    objEmp.CommunicationSkill = employee.CommunicationSkill;
                }
                if (employee.OfficeEmailID != "" && employee.OfficeEmailID != null)
                {
                    objEmp.OfficeEmailID = employee.OfficeEmailID;
                }
                if (employee.PersonalMailId != "" && employee.PersonalMailId != null)
                {
                    objEmp.PersonalMailId = employee.PersonalMailId;
                }
                if (employee.JobLocation != "" && employee.JobLocation != null)
                {
                    objEmp.JobLocation = employee.JobLocation;
                }
                if (employee.JobCity > 0)
                {
                    objEmp.JobCity = employee.JobCity;
                }
                if (employee.JobState > 0)
                {
                    objEmp.JobState = employee.JobState;
                }
                if (employee.JobCountry > 0)
                {
                    objEmp.JobCountry = employee.JobCountry;
                }
                if (employee.ObjPinCode != "" && employee.ObjPinCode != null)
                {
                    objEmp.ObjPinCode = employee.ObjPinCode;
                }
                if (employee.Password != "" && employee.Password != null)
                {
                    objEmp.Password = employee.Password;
                }
                if (employee.OfficeMobileNo != "" && employee.OfficeMobileNo != null)
                {
                    objEmp.OfficeMobileNo = employee.OfficeMobileNo;
                }
                if (employee.PersonalMobileNumber != "" && employee.PersonalMobileNumber != null)
                {
                    objEmp.PersonalMobileNumber = employee.PersonalMobileNumber;
                }
                if (employee.Designation > 0)
                {
                    objEmp.Designation = employee.Designation;
                }
                //if (employee.Qualification != "" && employee.Qualification != null)
                //{
                //    objEmp.Qualification = employee.Qualification;
                //}
                if (employee.CommunicationAddress != "" && employee.CommunicationAddress != null)
                {
                    objEmp.CommunicationAddress = employee.CommunicationAddress;
                }
                if (employee.PermanentAddress != "" && employee.PermanentAddress != null)
                {
                    objEmp.PermanentAddress = employee.PermanentAddress;
                }
                if (employee.PANNO != "" && employee.PANNO != null)
                {
                    objEmp.PANNO = employee.PANNO;
                }
                if (employee.AdhaarNo != "" && employee.AdhaarNo != null)
                {
                    objEmp.AdhaarNo = employee.AdhaarNo;
                }
                if (ProfilePic != null)
                {
                    objEmp.ProfilePic = Path.GetExtension(ProfilePic.FileName);
                }
                objEmp.DMLFlag = "I";
                result = objEmp.EmployeeMasterIUD();
                if (result != "" && result != null)
                {
                    if (ProfilePic != null)
                    {
                        path = ReadConfig.FilePath + "/Manager/" + Convert.ToString(User.Identity.Name.Split('|')[0]) + "/Employee/" + result;
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        path = Path.Combine(path, result + Path.GetExtension(ProfilePic.FileName));
                        ProfilePic.SaveAs(path);
                    }
                    result = "Success";
                }
                else
                {
                    result = "Failed";
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
            if (result == "Success")
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Employee Added Successfully');window.location='/Manager/CreateEmployee';</script>");
                //return Content("<script type='text/javascript language='javascript'>alert('Employee Created Successfully!');window.location='/Manager/CreateEmployee';</script>");
            }
            else
            {
                return Content("<script type='text/javascript language='javascript'>alert('Failed! please try again');window.location='/Manager/CreateEmployee'</script>");
            }
        }

        public List<SelectListItem> GETDROPDOWNDesignation()
        {
            Manager obj = new Manager();
            List<SelectListItem> symlist = new List<SelectListItem>();
            if (obj.DesignationDropdowndata() != null)
            {

                foreach (DataRow dr in obj.dtresult.Rows)
                {
                    SelectListItem slctitem = new SelectListItem();
                    slctitem.Value = dr["id"].ToString();
                    slctitem.Text = dr["Designation"].ToString();
                    symlist.Add(slctitem);
                }
            }


            return symlist;
        }

        public List<SelectListItem> GETDROPDOWNROLE()
        {
            Manager obj = new Manager();
            List<SelectListItem> symlist = new List<SelectListItem>();
            if (obj.RoleDropdowndata() != null)
            {

                foreach (DataRow dr in obj.dtresult.Rows)
                {
                    SelectListItem slctitem = new SelectListItem();
                    slctitem.Value = dr["RoleID"].ToString();
                    slctitem.Text = dr["RoleName"].ToString();
                    symlist.Add(slctitem);
                }
            }


            return symlist;
        }


        [Authorize]
        [HttpGet]
        public JsonResult GetStates(string id)
        {
            State state = new State();
            List<SelectListItem> State = new List<SelectListItem>();
            state.CountryID = Convert.ToInt32(id);
            State = state.GetStateByCountryID();
            if (State != null)
            {
                return Json(State, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Notfound", JsonRequestBehavior.AllowGet);
            }
        }

        [Authorize]
        [HttpGet]
        public JsonResult GetCities(string id)
        {
            City objCity = new City();
            List<SelectListItem> City = new List<SelectListItem>();
            objCity.StateID = Convert.ToInt32(id);
            City = objCity.GetCityByStateID();
            if (City != null)
            {
                return Json(City, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Notfound", JsonRequestBehavior.AllowGet);
            }
        }

        [Authorize]
        [HttpGet]
        public ActionResult EditEmployee(string id)
        {
            Admin objEmp = new Admin();
            Manager objmng = new Manager();
            Country country = new Country();
            DesignationMaster dm = new DesignationMaster();
            RoleMaster rm = new RoleMaster();

            State state = new State();
            City city = new City();
            List<SelectListItem> Countries = new List<SelectListItem>();
            List<SelectListItem> States = new List<SelectListItem>();
            List<SelectListItem> Cities = new List<SelectListItem>();
            List<SelectListItem> Desig = new List<SelectListItem>();
            List<SelectListItem> Role = new List<SelectListItem>();
            objmng.EmployeeId = Convert.ToInt32(id);
            if (id != null && id != "")
            {
                try
                {

                    Countries = country.GetCountry();
                    objEmp.EmployeeID = Convert.ToInt32(id);
                    //dm.CompanyID = Convert.ToInt16(User.Identity.Name.Split('|')[0]);
                    Desig = dm.GetDesignation();
                    rm.CompanyID = Convert.ToInt16(User.Identity.Name.Split('|')[0]);
                    Role = rm.GetRoleName();
                    if (objEmp.GetEmployeeByID())
                    {
                        foreach (DataRow dr in objEmp.dtbl.Rows)
                        {
                            objEmp.EmployeeID = Convert.ToInt32(id);
                            if (!dr.IsNull("RoleID"))
                            {
                                objEmp.RoleID = Convert.ToInt32(dr["RoleID"]);
                            }
                            if (!dr.IsNull("FullName"))
                            {
                                objEmp.FullName = Convert.ToString(dr["FullName"]);
                            }
                            if (!dr.IsNull("CommunicationSkill"))
                            {
                                objEmp.CommunicationSkill = Convert.ToString(dr["CommunicationSkill"]);
                            }
                            if (!dr.IsNull("OfficeEmailID"))
                            {
                                objEmp.OfficeEmailID = Convert.ToString(dr["OfficeEmailID"]);
                            }
                            if (!dr.IsNull("PersonalMailId"))
                            {
                                objEmp.PersonalMailId = Convert.ToString(dr["PersonalMailId"]);
                            }
                            if (!dr.IsNull("ProfilePic"))
                            {
                                objEmp.ProfilePic = Convert.ToString(dr["ProfilePic"]);
                            }
                            if (!dr.IsNull("JobLocation"))
                            {
                                objEmp.JobLocation = Convert.ToString(dr["JobLocation"]);
                            }
                            if (!dr.IsNull("JobCountry"))
                            {
                                objEmp.JobCountry = Convert.ToInt32(dr["JobCountry"]);

                            }
                            if (!dr.IsNull("JobCity"))
                            {
                                objEmp.JobCity = Convert.ToInt32(dr["JobCity"]);

                            }
                            if (!dr.IsNull("JobState"))
                            {
                                objEmp.JobState = Convert.ToInt32(dr["JobState"]);
                                city.StateID = objEmp.JobState;
                                Cities = city.GetCityByStateID();
                            }
                            if (!dr.IsNull("JobCountry"))
                            {

                                objEmp.JobCountry = Convert.ToInt32(dr["JobCountry"]);
                                state.CountryID = objEmp.JobCountry;
                                States = state.GetStateByCountryID();
                            }

                            if (!dr.IsNull("ObjPinCode"))
                            {
                                objEmp.ObjPinCode = Convert.ToString(dr["ObjPinCode"]);
                            }
                            if (!dr.IsNull("Password"))
                            {
                                objEmp.Password = Convert.ToString(dr["Password"]);
                            }
                            if (!dr.IsNull("OfficeMobileNo"))
                            {
                                objEmp.OfficeMobileNo = Convert.ToString(dr["OfficeMobileNo"]);
                            }
                            if (!dr.IsNull("PersonalMobileNumber"))
                            {
                                objEmp.PersonalMobileNumber = Convert.ToString(dr["PersonalMobileNumber"]);
                            }
                            if (!dr.IsNull("Designation"))
                            {
                                objEmp.Designation = Convert.ToInt32(dr["Designation"]);
                            }
                            //if (!dr.IsNull("Qualification"))
                            //{
                            //    objEmp.Qualification = Convert.ToString(dr["Qualification"]);
                            //}
                            if (!dr.IsNull("CommunicationAddress"))
                            {
                                objEmp.CommunicationAddress = Convert.ToString(dr["CommunicationAddress"]);
                            }
                            if (!dr.IsNull("PermanentAddress"))
                            {
                                objEmp.PermanentAddress = Convert.ToString(dr["PermanentAddress"]);
                            }
                            if (!dr.IsNull("PANNO"))
                            {
                                objEmp.PANNO = Convert.ToString(dr["PANNO"]);
                            }
                            if (!dr.IsNull("AdhaarNo"))
                            {
                                objEmp.AdhaarNo = Convert.ToString(dr["AdhaarNo"]);
                            }
                            //if (!dr.IsNull("AdhaarNo"))
                            //{
                            //    objEmp.AdhaarNo = Convert.ToString(dr["AdhaarNo"]);
                            //}
                        }

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
                ViewData["Employee"] = objEmp;
                ViewBag.Country = Countries;
                ViewBag.States = States;
                ViewBag.City = Cities;
                ViewBag.Desig = Desig;
                ViewBag.Role = Role;
            }
            else
            {
                RedirectToAction("Employees", "Company");
            }



            return View();

        }

        [Authorize]
        [HttpPost]
        public ActionResult EditEmployee(Admin employee, HttpPostedFileBase ProfilePic)
        {
            string result = string.Empty;
            string path = string.Empty;
            string Msg = string.Empty;
            Admin objEmp = new Admin();
            Manager objmng = new Manager();
            try
            {


                objEmp.EmployeeID = employee.EmployeeID;

                if (employee.RoleID > 0)
                {
                    objEmp.RoleID = employee.RoleID;
                }
                if (employee.FullName != "" && employee.FullName != null)
                {
                    objEmp.FullName = employee.FullName;
                }
                if (employee.CommunicationSkill != "" && employee.CommunicationSkill != null)
                {
                    objEmp.CommunicationSkill = employee.CommunicationSkill;
                }
                if (employee.OfficeEmailID != "" && employee.OfficeEmailID != null)
                {
                    objEmp.OfficeEmailID = employee.OfficeEmailID;
                }
                if (employee.PersonalMailId != "" && employee.PersonalMailId != null)
                {
                    objEmp.PersonalMailId = employee.PersonalMailId;
                }
                if (employee.JobLocation != "" && employee.JobLocation != null)
                {
                    objEmp.JobLocation = employee.JobLocation;
                }
                if (employee.JobCity > 0)
                {
                    objEmp.JobCity = employee.JobCity;
                }
                if (employee.JobState > 0)
                {
                    objEmp.JobState = employee.JobState;
                }
                if (employee.JobCountry > 0)
                {
                    objEmp.JobCountry = employee.JobCountry;
                }
                if (employee.ObjPinCode != "" && employee.ObjPinCode != null)
                {
                    objEmp.ObjPinCode = employee.ObjPinCode;
                }
                if (employee.Password != "" && employee.Password != null)
                {
                    objEmp.Password = employee.Password;
                }
                if (employee.OfficeMobileNo != "" && employee.OfficeMobileNo != null)
                {
                    objEmp.OfficeMobileNo = employee.OfficeMobileNo;
                }
                if (employee.PersonalMobileNumber != "" && employee.PersonalMobileNumber != null)
                {
                    objEmp.PersonalMobileNumber = employee.PersonalMobileNumber;
                }
                if (employee.Designation > 0)
                {
                    objEmp.Designation = employee.Designation;
                }
                //if (employee.Qualification != "" && employee.Qualification != null)
                //{
                //    objEmp.Qualification = employee.Qualification;
                //}
                if (employee.CommunicationAddress != "" && employee.CommunicationAddress != null)
                {
                    objEmp.CommunicationAddress = employee.CommunicationAddress;
                }
                if (employee.PermanentAddress != "" && employee.PermanentAddress != null)
                {
                    objEmp.PermanentAddress = employee.PermanentAddress;
                }
                if (employee.PANNO != "" && employee.PANNO != null)
                {
                    objEmp.PANNO = employee.PANNO;
                }
                if (employee.AdhaarNo != "" && employee.AdhaarNo != null)
                {
                    objEmp.AdhaarNo = employee.AdhaarNo;
                }
                if (ProfilePic != null)
                {
                    objEmp.ProfilePic = Path.GetExtension(ProfilePic.FileName);
                }
                else
                {
                    objEmp.ProfilePic = employee.ProfilePic;
                }
                objEmp.DMLFlag = "U";
                result = objEmp.EmployeeMasterUpdateIUD();
                if (result != "" && result != null)
                {
                    if (ProfilePic != null)
                    {
                        path = ReadConfig.FilePath + "/Manager/" + Convert.ToString(User.Identity.Name.Split('|')[0]) + "/Employee/" + objEmp.EmployeeID;
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        path = Path.Combine(path, objEmp.EmployeeID + Path.GetExtension(ProfilePic.FileName));
                        ProfilePic.SaveAs(path);
                    }
                    result = "Success";
                }
                else
                {
                    result = "Failed";
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
            if (result == "Success")
            {
                Msg = "Employee Updated Successfully!";
                //return Content("<script type='text/javascript language='javascript'>alert('Employee Created Successfully!');window.location='/Employee/CreateEmployee'</script>");
            }
            else
            {
                Msg = "Failed! please try again";
                //return Content("<script type='text/javascript language='javascript'>alert('Failed! please try again');window.location='/Employee/CreateEmployee'</script>");
            }
            TempData["Msg"] = Msg;
            return RedirectToAction("Employees", "Manager");

        }
    }
}