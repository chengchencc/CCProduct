using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackMamba.Framework.Core;
using NLog;
namespace CC.Product.Core
{
    public class Log
    {
        private static Logger instance ;
        private static object _lock = new object();
        public static Logger GetInstance()
        {
            if (instance == null)
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = LogManager.GetCurrentClassLogger();
                    }
                }
            }
            return instance;
        }
        public static void Write(string message)
        {
            GetInstance().Debug(message);
        }

    }
}
