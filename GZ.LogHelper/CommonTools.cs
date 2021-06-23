using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GZ.LogHelper
{
    public class CommonTools
    {
        public static void GetExceptionMsg(Exception ex, StringBuilder sb, string Prefix = "")
        {
            sb.AppendLine(Prefix + "【异常类型】：" + ex.GetType().Name);
            sb.AppendLine(Prefix + "【异常信息】：" + ex.Message);
            sb.AppendLine(Prefix + "【堆栈调用】：" + ex.StackTrace);
            sb.AppendLine(Prefix + "【异常方法】：" + ex.TargetSite);

            if (ex.InnerException != null)
                GetExceptionMsg(ex.InnerException, sb, Prefix + "\t");
        }

    }
}
