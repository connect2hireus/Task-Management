using System.Configuration;

namespace Ags_TaskManagement
{
    public static class ReadConfig
    {
        //public static string SiteUrl = ConfigurationManager.AppSettings["http_url"].ToString() ?? "";
        //public static string SiteUrls = ConfigurationManager.AppSettings["https_ssl_url"].ToString() ?? "";
        //public static string templatesUrl = ConfigurationManager.AppSettings["templatesUrl"].ToString() ?? "";
        public static string FilePath = ConfigurationManager.AppSettings["FilePath"].ToString() ?? "";
    }
}   
