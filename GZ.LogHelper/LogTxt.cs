using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GZ.LogHelper
{
    public class LogTxt : ILog
    {
        private string LogRootPath { get; set; }
        public LogTxt(string rootPath)
        {
            
            LogRootPath = rootPath;
        }

        string getFileName(string type)
        {
            string fileName = System.IO.Path.Combine(LogRootPath, type, DateTime.Now.ToString("yyyy-MM-dd") + ".log");
            string path = Path.GetDirectoryName(fileName);
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            if (!File.Exists(fileName))
                System.IO.File.CreateText(fileName).Dispose();

            return fileName;
        }

        public void Error(string errMsg)
        {
            lock (LockerProvider.Error)
            {
                string fileName = this.getFileName("ERROR");
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("【时间】：" + DateTime.Now);
                sb.AppendLine("【错误描述】：" + errMsg);
                using (TextWriter writer2 = System.IO.File.AppendText(fileName))
                {
                    writer2.WriteLine(sb.ToString());
                    writer2.WriteLine(" ");
                }
            }

        }

        public void Error(Exception exception)
        {
            lock (LockerProvider.Error)
            {
                string fileName = this.getFileName("ERROR");
                StringBuilder sb2 = new StringBuilder();
                CommonTools.GetExceptionMsg(exception, sb2, "");
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("【时间】：" + DateTime.Now);
                sb.AppendLine("【错误描述】：" + sb2);
                using (TextWriter writer2 = System.IO.File.AppendText(fileName))
                {
                    writer2.WriteLine(sb.ToString());
                    writer2.WriteLine(" ");
                }
            }
        }

        public void Error(Exception exception, string description)
        {
            lock (LockerProvider.Error)
            {
                string fileName = this.getFileName("ERROR");
                StringBuilder sb2 = new StringBuilder();
                if (!string.IsNullOrEmpty(description))
                {
                    sb2.AppendLine(description);
                }
                CommonTools.GetExceptionMsg(exception, sb2, "");
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("【时间】：" + DateTime.Now);
                sb.AppendLine("【错误描述】：" + sb2);
                using (TextWriter writer2 = System.IO.File.AppendText(fileName))
                {
                    writer2.WriteLine(sb.ToString());
                    writer2.WriteLine(" ");
                }
            }

        }
        public void CustomLog(string type, string message)
        {
            lock (LockerProvider.Customer)
            {
                string fileName = this.getFileName(type);
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("【时间】：" + DateTime.Now);
                sb.AppendLine("【信息】：" + message);
                using (TextWriter writer2 = System.IO.File.AppendText(fileName))
                {
                    writer2.WriteLine(sb.ToString());
                    System.Threading.Thread.Sleep(5000);
                    writer2.WriteLine(" ");
                }
            }
        }
        public void Debug(string msg)
        {
            throw new NotImplementedException();
        }


        public void Info(string msg)
        {
            lock (LockerProvider.Info)
            {
                string fileName = this.getFileName("INFO");
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("【时间】：" + DateTime.Now);
                sb.AppendLine("【信息】：" + msg);
                using (TextWriter writer2 = System.IO.File.AppendText(fileName))
                {
                    writer2.WriteLine(sb.ToString());
                    writer2.WriteLine(" ");
                }
            }
        }

        public void Warning(string msg)
        {
            lock (LockerProvider.Warn)
            {
                string fileName = this.getFileName("WARN");
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("【时间】：" + DateTime.Now);
                sb.AppendLine("【信息】：" + msg);
                using (TextWriter writer2 = System.IO.File.AppendText(fileName))
                {
                    writer2.WriteLine(sb.ToString());
                    writer2.WriteLine(" ");
                }
            }
        }


    }

    public class LockerProvider
    {
        static LockerProvider _customer;
        public static LockerProvider Customer
        {
            get
            {
                if (_customer == null)
                    _customer = new LockerProvider();
                return _customer;
            }
        }

        static LockerProvider _error;
        public static LockerProvider Error
        {
            get
            {
                if (_error == null)
                    _error = new LockerProvider();
                return _error;
            }
        }

        static LockerProvider _info;
        public static LockerProvider Info
        {
            get
            {
                if (_info == null)
                    _info = new LockerProvider();
                return _info;
            }
        }

        static LockerProvider _warn;
        public static LockerProvider Warn
        {
            get
            {
                if (_warn == null)
                    _warn = new LockerProvider();
                return _warn;
            }
        }
        static LockerProvider _apilog;
        public static LockerProvider APILog
        {
            get
            {
                if (_apilog == null)
                    _apilog = new LockerProvider();
                return _apilog;
            }
        }
    }
}
