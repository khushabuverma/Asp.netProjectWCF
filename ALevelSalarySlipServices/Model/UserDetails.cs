using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ALevelSalarySlipServices.Model
{
    public class UserDetails
    {
        public string EmpId { get; set; }
        public string EmpName { get; set; }
        public string Dept { get; set; }
        public string CompanyName { get; set; }
        public bool IsPasswordChanged { get; set; }
        public string ResponseMessage { get; set; }
    }
}