using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

    class AppSettings
    {
        public static string ConnectionString
        {
            get
            {
                string cs = null;
                cs = ConfigurationManager.ConnectionStrings[AppSettings.Connection].ConnectionString;
                if (String.IsNullOrEmpty(cs))
                {
                    throw new NullReferenceException("ConnectionString in Appsettings nicht definiert!");
                }
                return cs;
            }
        }
        public static string Connection
        {
            get
            {
                string conn = null;
                conn = ConfigurationManager.AppSettings["Connection"];
                if (String.IsNullOrEmpty(conn))
                {
                    throw new NullReferenceException("Connection in Appsettings nicht definiert!");
                }
                return conn;
            }
        }
        public static string DataManagerClass
        {
            get
            {
                string dm = null;
                dm = ConfigurationManager.AppSettings["DataManager"];
                if (String.IsNullOrEmpty(dm))
                {
                    throw new NullReferenceException("Datamanager in Appsettings nicht definiert!");
                }
                return dm;
            }
        }
    }