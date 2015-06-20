using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yiyou.Log
{
    public class Log4NetLogger
    {
        private static readonly log4net.ILog _loginfo = log4net.LogManager.GetLogger("GXWebLogger");

        static Log4NetLogger()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        public static log4net.ILog GetLogger()
        {
            return _loginfo;
        }
    }
}
