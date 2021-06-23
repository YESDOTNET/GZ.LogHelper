using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GZ.LogHelper
{
    public class LogConfig
    {
        static string _root;
        public static string LogRoot
        {
            get
            {
                if (String.IsNullOrWhiteSpace(_root))
                {
                    _root = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log");
                }
                return _root;
            }
            set
            {
                _root = value;
            }
        }

    }
}
