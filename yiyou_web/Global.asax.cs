using System;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using Yiyou.Log;
using Yiyou.SQLServerDAL;

namespace ICUPro.Portal
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // 在应用程序启动时运行的代码
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            // Code that runs on application startup      
            Log4NetLogger.GetLogger().Info("Application_Start....");
            SqlHelper.ConnectionStringSettings = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            Log4NetLogger.GetLogger().Info("ConnectionStringSettings: " + SqlHelper.ConnectionStringSettings);
            

            //DataSet dsGlobalInfo = new DataSet();
            //Log4NetLogger.GetLogger().Info("Get tbProject");
            //dsGlobalInfo.Tables.Add(ApplicationDAL.GetProjectList().Tables[0].Copy().TableName = "tbProject");

            //Log4NetLogger.GetLogger().Info("Get tbLoction");
            //dsGlobalInfo.Tables.Add(ApplicationDAL.GetLoctionList().Tables[0].Copy().TableName = "tbLoction");

            //Log4NetLogger.GetLogger().Info("Get tbHospital");
            //dsGlobalInfo.Tables.Add(ApplicationDAL.GetHospitalList().Tables[0].Copy().TableName = "tbHospital");

            //Log4NetLogger.GetLogger().Info("Get tbDoctor");
            //dsGlobalInfo.Tables.Add(ApplicationDAL.GetDoctorList().Tables[0].Copy().TableName = "tbDoctor");
            //Application["dsGlobalInfo"] = dsGlobalInfo;
        }
    }
}