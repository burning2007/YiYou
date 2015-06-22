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

            System.Threading.Thread t = new System.Threading.Thread(TempImgLRU);
            t.Start();
        }

        /// <summary>
        /// Remove the old, unnecessary files
        /// </summary>
        private void TempImgLRU()
        {
            int nLURInterval = 30;   // LUR every ? seconds
            int nMaxFilesCount = 100;  // Only LRU when files count exceed this threshold
            int nMaxExpiredMinutes = 30;   // Only delete the files expired with specified minutes

            string strTempFolder = Yiyou.Util.ImageUtils.GetTempFolderPath();

            while (System.IO.Directory.Exists(strTempFolder))
            {
                try
                {
                    string[] FileList = System.IO.Directory.GetFiles(strTempFolder, "*.*", System.IO.SearchOption.AllDirectories);
                    if (FileList.Length > nMaxFilesCount)
                    {
                        foreach (string filePath in FileList)
                        {
                            System.IO.FileInfo fi = new System.IO.FileInfo(filePath);
                            if (fi.LastAccessTime.AddMinutes(nMaxExpiredMinutes) < DateTime.Now)
                            {
                                fi.Attributes = System.IO.FileAttributes.Normal;
                                fi.Delete();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Log4NetLogger.GetLogger().Info("LRU failed: " + ex.StackTrace);
                }

                System.Threading.Thread.Sleep(nLURInterval * 1000);
            }
        }
    }
}