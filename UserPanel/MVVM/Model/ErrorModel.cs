using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserPanel.MVVM.Model
{
    public class ErrorModel
    {
        public int Code { get; set; }
        public string Issue { get; set; }

        public ErrorModel() { }
        public ErrorModel(int code, string issue)
        {
            Code = code;
            Issue = issue;
        }
    }
}
