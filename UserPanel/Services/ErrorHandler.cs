using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserPanel.Services
{
    public class ErrorHandler : IErrorHandler
    {
        public void ErrorReport(int code, string issue)
        {
            Trace.WriteLine($"Error {code}: {issue}");
        }

        public void ErrorReport(Exception err)
        {
            Trace.WriteLine($"Exception message: {err.Message}");
            Trace.WriteLine(err.StackTrace);
        }
    }
}
