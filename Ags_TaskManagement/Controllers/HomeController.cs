using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Ags_TaskManagement.BAL;


namespace Ags_TaskManagement.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

         [HttpPost]
        public ActionResult Login(Employee emp)
            {
            if (ModelState.IsValid)
            {
                string formVal = string.Empty;
                Employee obj = new Employee();
                obj.OfficeEmailID = emp.OfficeEmailID;
                obj.Password = emp.Password;
                if(obj.EmpLogin())
                {
                    formVal =Convert.ToString(obj.EmployeeID)+'|'+ Convert.ToString(obj.RoleID) + '|' + obj.OfficeEmailID + '|' + obj.FullName + '|' + obj.ProfilePic;
                    FormsAuthentication.RedirectFromLoginPage(formVal, false);
                    if (obj.RoleID == 3)
                    {
                        return RedirectToAction("Dashboard", "Task");
                    }
                    else if (obj.RoleID == 2)
                    {
                        return RedirectToAction("Dashboard", "Manager");
                    }
                    else if (obj.RoleID == 1)
                    {
                        return RedirectToAction("Dashboard", "Admin");
                    }
                    else
                    {
                        FormsAuthentication.SignOut();
                        return Content("<script language='javascript' type='text/javascript'>alert('You are not authorized person to access this panel');window.location='/Home/Login';</script>");
                    }
                }
                else
                {
                    ViewBag.Message += "Invalid Credentials";
                }
              
            }
            return View(emp);
        }

        
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login","Home");
        }
    }
}