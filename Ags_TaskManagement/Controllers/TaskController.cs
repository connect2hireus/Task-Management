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
    public class TaskController : Controller
    {
        TaskMaster taskMaster = new TaskMaster();
        // GET: Task
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Dashboard(string fromDate, string toDate, int? page)
        {
            List<TaskMaster> listitem = new List<TaskMaster>();
            TaskMaster task = new TaskMaster();
            if (fromDate != "" && fromDate != null)
            {
                task.fromDate = Convert.ToDateTime(fromDate);
            }

            if (toDate != "" && toDate != null)
            {
                task.toDate = Convert.ToDateTime(toDate);
            }
            listitem = task.SearchTaskMaster();
            ViewData["Searchresult"] = listitem.ToPagedList(page ?? 1, 10);

            return View();
        }
        [Authorize]
        [HttpGet]        
        public ActionResult TaskMaster()
        {
            ViewBag.project = GETDROPDOWNMEDICINE();
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult TaskMaster(TaskMaster objtskmaster)
        {
            string result = string.Empty;            
            TaskMaster obj = new TaskMaster();
            DateTime date = Convert.ToDateTime(objtskmaster.Date);
            obj.ProjectId = objtskmaster.ProjectId;
            obj.EmployeeId = Convert.ToInt32(User.Identity.Name.Split('|')[0]);
            obj.TaskTitle = objtskmaster.TaskTitle;
            obj.Date = date;
            obj.Duration = objtskmaster.Duration;
            obj.Reamrk = objtskmaster.Reamrk;
            result = obj.TaskMasterUID();
            if (result != null && result != "")
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Task Added Successfully');window.location='/Task/TaskMaster';</script>");
            }
            else
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Failed! Please try again later.');window.location='/Marketing/CreateLead';</script>");
            }



        }

        public List<SelectListItem> GETDROPDOWNMEDICINE()
        {
            TaskMaster obj = new TaskMaster();
            List<SelectListItem> symlist = new List<SelectListItem>();
            if (obj.ProjectDropdowndata() != null)
            {

                foreach (DataRow dr in obj.dtresult.Rows)
                {
                    SelectListItem slctitem = new SelectListItem();
                    slctitem.Value = dr["ProjectId"].ToString();
                    slctitem.Text = dr["Title"].ToString();
                    symlist.Add(slctitem);
                }
            }


            return symlist;
        }

        [Authorize]
         public ActionResult SearchTaskMaster(string fromDate,string toDate,int?page)
        {
             
            List<TaskMaster> listitem = new List<TaskMaster>();
            TaskMaster task = new TaskMaster();
            if (fromDate != "" && fromDate !=null)
            {
                task.fromDate = Convert.ToDateTime(fromDate);
            }

            if (toDate != "" && toDate !=null)
            {
                task.toDate = Convert.ToDateTime(toDate);
            }  
            listitem= task.SearchTaskMaster();
            ViewData["Searchresult"] = listitem.ToPagedList(page ?? 1,10);
            
            return View();
            
        }

    }
}