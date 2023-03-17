using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ALevelSalarySlipServices.Model
{
    public class AppVersion
    {
        public int Ver_Id { get; set; }
        public string Version { get; set; }
        public bool Status { get; set; }
    }
    public class AppVersionDetails
    {
        public AppVersion AppVersions { get; set; }
        public string ResponseMessage { get; set; }
    }
    public class ExamVersion
    {
        public int Ver_Id { get; set; }
    }
}