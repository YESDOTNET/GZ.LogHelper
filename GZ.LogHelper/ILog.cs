using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GZ.LogHelper
{
    public interface ILog
    {
        void Error(string errMsg);
        void Error(Exception exception);
        void Error(Exception exception, string description);
        void Info(string msg);
        void Debug(string msg);
        void Warning(string msg);

        void CustomLog(string type, string message);
    }
}
