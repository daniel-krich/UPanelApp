using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserPanel.Services
{
    public interface IErrorHandler
    {
        void ErrorReport(int code, string issue);
        void ErrorReport(Exception err);
    }
}
