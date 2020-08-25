using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace Ags_TaskManagement.BAL
{
    public enum EmpLeaveStatusType { Approved, Rejected, Cancelled };
    public static class Utility
    {
        public static void ShowMessage(string Message, Page page)
        {
            string msg = String.Format("<script type='text/javascript'> alert('Message:\n{0}'); </script>", Message);
            System.Web.HttpContext.Current.Response.Write(String.Format("<SCRIPT LANGUAGE=\"JavaScript\">alert(\"{0}\")</SCRIPT>", msg));

        }
        public static bool IsFileExists(string FilePath)
        {

            return System.IO.File.Exists(HttpContext.Current.Server.MapPath(FilePath));

        }
        public static void MessageBox(HtmlGenericControl divMsg, string Status, string msg, HtmlGenericControl txtMessage)
        {
            divMsg.Visible = true;
            divMsg.Attributes.Add("class", "alert alert-" + Status + " alert-dismissable");
            txtMessage.InnerText = msg;
        }
        public static void ResetFormControlValues(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c.Controls.Count > 0)
                {
                    ResetFormControlValues(c);
                }
                else
                {
                    switch (c.GetType().ToString())
                    {
                        case "System.Web.UI.WebControls.TextBox":
                            ((TextBox)c).Text = "";
                            break;
                        case "System.Web.UI.WebControls.CheckBox":
                            ((CheckBox)c).Checked = false;
                            break;
                        case "System.Web.UI.WebControls.RadioButton":
                            ((RadioButton)c).Checked = false;
                            break;

                    }
                }
            }
        }

        internal static void MessageBox(object divMsg, string v1, string v2, object txtMessage)
        {
            throw new NotImplementedException();
        }
    }
}