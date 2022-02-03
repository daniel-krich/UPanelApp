using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserPanelWebApi.Models
{
    public class ErrorEntity
    {
        public int Code { get; set; }
        public string Issue { get; set; }

        public ErrorEntity(int code, string issue)
        {
            Code = code;
            Issue = issue;
        }
    }
}
