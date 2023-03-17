using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ALevelSalarySlipServices.Model
{
    public class EmployeesDetails
    {
        public int Empid { get; set; }
        public string EmpName { get; set; }
        public string DepartmentName { get; set; }
        public string Designation { get; set; }
        public string DOJ { get; set; }
        public string UANNo { get; set; }
        public string ESICNo { get; set; }
        public string STATUS { get; set; }
        public string BankName { get; set; }
        public string IFSCCode { get; set; }
        public string AccountNo { get; set; }
        public string PANCardno { get; set; }
        public string AdhaarCard { get; set; }
        public string Branch { get; set; }
        public string VendorName { get; set; }
        public string ResponseMessage { get; set; }
    }
    public class EmployeeDetailslist
    {
        public EmployeesDetails objEmployeesDetails { get; set; }
        public string[] objPeriod { get; set; }
        public MonthlySalaryDetails objMonthlySalaryDetails { get; set; }
        public VendorDetails objVendorDetails { get; set; }
        public string ResponseMessage { get; set; }
    }


}