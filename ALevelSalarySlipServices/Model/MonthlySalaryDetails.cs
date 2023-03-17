using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ALevelSalarySlipServices.Model
{
    public class MonthlySalaryDetails
    {
        public int Empid { get; set; }
        public string Working_Days { get; set; }
        public int Week_Off { get; set; }
        public int Holiday { get; set; }
        public decimal CL { get; set; }
        public decimal EL { get; set; }
        public string Total_paid_days { get; set; }
        public decimal Fixed_Basic { get; set; }
        public decimal Fixed_VAD { get; set; }
        public decimal Fixed_HRA { get; set; }
        public decimal Fixed_SpecialAllowance { get; set; }
        public decimal TotalGross { get; set; }
        public decimal Basic_Paid { get; set; }
        public decimal VDA_Paid { get; set; }
        public decimal HRA_Paid { get; set; }
        public decimal SpecialAllowance_Paid { get; set; }
        public decimal TotalEarninig { get; set; }
        public decimal GWI { get; set; }
        public decimal AttendanceAward { get; set; }
        public decimal ServiceAllowance { get; set; }
        public decimal GWP { get; set; }
        public decimal Position_Allowance { get; set; }
        public decimal Variable_Allowance { get; set; }
        public decimal Arrear { get; set; }
        public decimal TotalVariable { get; set; }
        public string ESIC { get; set; }
        public string EPF { get; set; }
        public decimal IdCardDed { get; set; }
        public decimal PantDed { get; set; }
        public decimal OtherDed { get; set; }
        public decimal TotalDeduction { get; set; }
        public decimal Net_Amount_Paid { get; set; }
        public string MonthYear { get; set; }
    }
    public class GetMonthlySalaryDetailsById
    {
        public MonthlySalaryDetails objMonthlySalaryDetails { get; set; }
        public string ResponseMessage { get; set; }
    }
    public class EmployeeDetailsByID
    {
        public int EmpId { get; set; }
        public string Month { get; set; }
    }
}