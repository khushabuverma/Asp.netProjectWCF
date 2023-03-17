using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ALevelSalarySlipServices.DAL;
using System.Data;
using ALevelSalarySlipServices.Model;
using System.Dynamic;
using System.ServiceModel.Web;

namespace ALevelSalarySlipServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class ALevelSalarySlipAPI : IALevelSalarySlipAPI
    {
        public UserDetails login_app(Login objLogin)
        {
            UserDetails ObjUserDetails = new Model.UserDetails();
            try
            {
                ALevelSalarySlip_DAL dis = new ALevelSalarySlip_DAL();
                DataSet ds = dis.login_app(objLogin.EmpId, objLogin.Password);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ObjUserDetails.EmpId = ds.Tables[0].Rows[0]["EmpId"].ToString();
                    ObjUserDetails.EmpName = ds.Tables[0].Rows[0]["Empname"].ToString();
                    ObjUserDetails.Dept = ds.Tables[0].Rows[0]["Dept"].ToString();
                    ObjUserDetails.CompanyName = ds.Tables[0].Rows[0]["CompanyName"].ToString();
                    ObjUserDetails.IsPasswordChanged = (bool)ds.Tables[0].Rows[0]["IsPasswordChanged"];
                    ObjUserDetails.ResponseMessage = "Success";
                }
                else
                {
                    ObjUserDetails.ResponseMessage = "Invaild Username and Password";
                }
                return ObjUserDetails;
            }
            catch (Exception ex)
            {
                ObjUserDetails.ResponseMessage = ex.Message;
                return ObjUserDetails;
            }
        }

        public AppVersionDetails Check_AppVersion(ExamVersion objExamVersion)
        {
            AppVersionDetails objAppVersionDetails = new AppVersionDetails();
            try
            {
                ALevelSalarySlip_DAL dis = new ALevelSalarySlip_DAL();
                AppVersion AppVersion = new AppVersion();
                DataSet ds = dis.Check_LastestVersion(objExamVersion.Ver_Id);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    objAppVersionDetails.AppVersions = new AppVersion();
                    objAppVersionDetails.AppVersions.Ver_Id = Convert.ToInt32(ds.Tables[0].Rows[0]["Ver_Id"]);
                    objAppVersionDetails.AppVersions.Version = Convert.ToString(ds.Tables[0].Rows[0]["Version"].ToString());
                    objAppVersionDetails.AppVersions.Status = true;
                    objAppVersionDetails.ResponseMessage = "Success";
                    //  result = "{\"Response\" : [{\"Responsecode\" : \"0\" , \"Response\" : \"Success\"}] , \"Data\" : " + result + "}";
                }
                else
                {
                    objAppVersionDetails.ResponseMessage = "Invaild Username and Password";
                    // result = "{\"Response\" : [{\"Responsecode\" : \"1\" , \"Response\" : \"Invaild Username and Password\" }]}";
                }
            }
            catch (Exception ex)
            {
                //General.LogSteps("GetRechargePlan", System.Web.Hosting.HostingEnvironment.MapPath("~\\AndriodRecharge.txt"));
                objAppVersionDetails.ResponseMessage = ex.Message;
                return objAppVersionDetails;
            }
            return objAppVersionDetails;
        }

        public ResponseMessage1 ValidateOldPassword(ChangePassword objExamVersion)
        {
            ResponseMessage1 objResponseMessage = new ResponseMessage1();
            try
            {
                ALevelSalarySlip_DAL dis = new ALevelSalarySlip_DAL();
                DataSet ds = dis.validateoldpassword(objExamVersion.OldPassword, objExamVersion.UserId);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToInt32(ds.Tables[0].Rows[0]["value"]) == 1)
                    {
                        objResponseMessage.ResponseMessage = "Success";
                    }
                    else
                    {
                        objResponseMessage.ResponseMessage = "Invaild Old Password";
                    }
                }
                else
                {
                    objResponseMessage.ResponseMessage = "Invaild Old Password";
                }
                return objResponseMessage;
            }
            catch (Exception ex)
            {
                objResponseMessage.ResponseMessage = ex.Message;
                return objResponseMessage;
            }
        }
        public ResponseMessage1 ChangePassword(ChangePassword objExamVersion)
        {
            ResponseMessage1 objResponseMessage = new ResponseMessage1();
            try
            {
                ALevelSalarySlip_DAL dis = new ALevelSalarySlip_DAL();
                DataSet ds = dis.ChangePassword(objExamVersion.OldPassword, objExamVersion.UserId, objExamVersion.NewPassword);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToInt32(ds.Tables[0].Rows[0]["value"]) == 1)
                    {
                        objResponseMessage.ResponseMessage = "Success";
                    }
                    else
                    {
                        objResponseMessage.ResponseMessage = "Invalid Details";
                    }

                    //  result = "{\"Response\" : [{\"Responsecode\" : \"0\" , \"Response\" : \"Success\"}] , \"Data\" : " + result + "}";
                }
                else
                {
                    objResponseMessage.ResponseMessage = "Invaild Old Password";
                    // result = "{\"Response\" : [{\"Responsecode\" : \"1\" , \"Response\" : \"Invaild Username and Password\" }]}";
                }

                return objResponseMessage;
            }
            catch (Exception ex)
            {
                //General.LogSteps("GetRechargePlan", System.Web.Hosting.HostingEnvironment.MapPath("~\\AndriodRecharge.txt"));
                objResponseMessage.ResponseMessage = ex.Message;
                return objResponseMessage;
            }
        }
        public ResponseMessage1 InsExceptionMsg(ExceptionMsg objExceptionMsg)
        {
            ResponseMessage1 objResponseMessage = new ResponseMessage1();
            try
            {
                ALevelSalarySlip_DAL dis = new ALevelSalarySlip_DAL();
                DataSet ds = dis.InsExceptionMsg_(objExceptionMsg.UserId, objExceptionMsg.Error_MessageR);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToInt32(ds.Tables[0].Rows[0]["value"]) == 1)
                    {
                        objResponseMessage.ResponseMessage = "Success";
                    }
                    else
                    {
                        objResponseMessage.ResponseMessage = "Invalid Details";
                    }

                    //  result = "{\"Response\" : [{\"Responsecode\" : \"0\" , \"Response\" : \"Success\"}] , \"Data\" : " + result + "}";
                }
                else
                {
                    objResponseMessage.ResponseMessage = "Invalid Details";
                    // result = "{\"Response\" : [{\"Responsecode\" : \"1\" , \"Response\" : \"Invaild Username and Password\" }]}";
                }

                return objResponseMessage;
            }
            catch (Exception ex)
            {
                //General.LogSteps("GetRechargePlan", System.Web.Hosting.HostingEnvironment.MapPath("~\\AndriodRecharge.txt"));
                objResponseMessage.ResponseMessage = ex.Message;
                return objResponseMessage;
            }
        }

        public EmployeeDetailslist GetEmployeeDetails(Login objLogin)
        {
            EmployeeDetailslist ObjUserDetails = new Model.EmployeeDetailslist();
            try
            {
                ALevelSalarySlip_DAL dis = new ALevelSalarySlip_DAL();
                ObjUserDetails.objEmployeesDetails = new EmployeesDetails();
                DataSet ds = dis.GetEmployeesDetails(objLogin.EmpId);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ObjUserDetails.objEmployeesDetails.Empid = (Int32)ds.Tables[0].Rows[0]["EmpId"];
                    ObjUserDetails.objEmployeesDetails.EmpName = ds.Tables[0].Rows[0]["Empname"].ToString();
                    ObjUserDetails.objEmployeesDetails.DepartmentName = ds.Tables[0].Rows[0]["DepartmentName"].ToString();
                    ObjUserDetails.objEmployeesDetails.Designation = ds.Tables[0].Rows[0]["Designation"].ToString();
                    ObjUserDetails.objEmployeesDetails.DOJ = ds.Tables[0].Rows[0]["DOJ"].ToString();
                    ObjUserDetails.objEmployeesDetails.UANNo = ds.Tables[0].Rows[0]["UANNo"].ToString();
                    ObjUserDetails.objEmployeesDetails.ESICNo = ds.Tables[0].Rows[0]["ESICNo"].ToString();
                    ObjUserDetails.objEmployeesDetails.STATUS = ds.Tables[0].Rows[0]["STATUS"].ToString();
                    ObjUserDetails.objEmployeesDetails.BankName = ds.Tables[0].Rows[0]["BankName"].ToString();
                    ObjUserDetails.objEmployeesDetails.IFSCCode = ds.Tables[0].Rows[0]["IFSCCode"].ToString();
                    ObjUserDetails.objEmployeesDetails.AccountNo = ds.Tables[0].Rows[0]["AccountNo"].ToString();
                    ObjUserDetails.objEmployeesDetails.PANCardno = ds.Tables[0].Rows[0]["PANCardno"].ToString();
                    ObjUserDetails.objEmployeesDetails.AdhaarCard = ds.Tables[0].Rows[0]["AdhaarCard"].ToString();
                    ObjUserDetails.objEmployeesDetails.Branch = ds.Tables[0].Rows[0]["Branch"].ToString();
                    ObjUserDetails.objEmployeesDetails.VendorName = ds.Tables[0].Rows[0]["CompanyName"].ToString();

                    ObjUserDetails.ResponseMessage = "Success";
                }
                else
                {
                    ObjUserDetails.ResponseMessage = "Employee Details is not Found";
                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    ObjUserDetails.objPeriod = new String[ds.Tables[1].Rows.Count];
                    for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                    {
                        ObjUserDetails.objPeriod[i] = ds.Tables[1].Rows[i]["MonthYear"].ToString();
                    }
                }
                else {
                    ObjUserDetails.ResponseMessage = "No Salary Slip is upload yet. Please try after sometime.";
                }
                ObjUserDetails.objMonthlySalaryDetails = new MonthlySalaryDetails();
                if (ds.Tables[2].Rows.Count > 0)
                {
                    ObjUserDetails.objMonthlySalaryDetails.Empid = (Int32)ds.Tables[2].Rows[0]["Empid"];
                    ObjUserDetails.objMonthlySalaryDetails.Working_Days = ds.Tables[2].Rows[0]["Working_Days"].ToString();
                    ObjUserDetails.objMonthlySalaryDetails.Week_Off = (Int32)ds.Tables[2].Rows[0]["Week_Off"];
                    ObjUserDetails.objMonthlySalaryDetails.Holiday = (Int32)ds.Tables[2].Rows[0]["Holiday"];
                    ObjUserDetails.objMonthlySalaryDetails.CL = (decimal)ds.Tables[2].Rows[0]["CL"];
                    ObjUserDetails.objMonthlySalaryDetails.EL = (decimal)ds.Tables[2].Rows[0]["SL"];
                    ObjUserDetails.objMonthlySalaryDetails.Total_paid_days = ds.Tables[2].Rows[0]["Total_paid_days"].ToString();
                    ObjUserDetails.objMonthlySalaryDetails.Fixed_Basic = (decimal)ds.Tables[2].Rows[0]["Fixed_Basic"];
                    ObjUserDetails.objMonthlySalaryDetails.Fixed_VAD = (decimal)ds.Tables[2].Rows[0]["Fixed_VAD"];
                    ObjUserDetails.objMonthlySalaryDetails.Fixed_HRA = (decimal)ds.Tables[2].Rows[0]["Fixed_HRA"];
                    ObjUserDetails.objMonthlySalaryDetails.Fixed_SpecialAllowance = (decimal)ds.Tables[2].Rows[0]["Fixed_SpecialAllowance"];
                    ObjUserDetails.objMonthlySalaryDetails.TotalGross = (decimal)ds.Tables[2].Rows[0]["TotalGross"];
                    ObjUserDetails.objMonthlySalaryDetails.Basic_Paid = (decimal)ds.Tables[2].Rows[0]["Basic_Paid"];
                    ObjUserDetails.objMonthlySalaryDetails.VDA_Paid = (decimal)ds.Tables[2].Rows[0]["VDA_Paid"];
                    ObjUserDetails.objMonthlySalaryDetails.HRA_Paid = (decimal)ds.Tables[2].Rows[0]["HRA_Paid"];

                    ObjUserDetails.objMonthlySalaryDetails.SpecialAllowance_Paid = (decimal)ds.Tables[2].Rows[0]["SpecialAllowance_Paid"];
                    ObjUserDetails.objMonthlySalaryDetails.TotalEarninig = (decimal)ds.Tables[2].Rows[0]["TotalEarninig"];
                    ObjUserDetails.objMonthlySalaryDetails.GWI = (decimal)ds.Tables[2].Rows[0]["GWI"];
                    ObjUserDetails.objMonthlySalaryDetails.AttendanceAward = (decimal)ds.Tables[2].Rows[0]["AttendanceAward"];
                    ObjUserDetails.objMonthlySalaryDetails.ServiceAllowance = (decimal)ds.Tables[2].Rows[0]["ServiceAllowance"];
                    ObjUserDetails.objMonthlySalaryDetails.GWP = (decimal)ds.Tables[2].Rows[0]["GWP"];
                    ObjUserDetails.objMonthlySalaryDetails.Position_Allowance = (decimal)ds.Tables[2].Rows[0]["Position_Allowance"];
                    ObjUserDetails.objMonthlySalaryDetails.Variable_Allowance = (decimal)ds.Tables[2].Rows[0]["Variable_Allowance"];

                    ObjUserDetails.objMonthlySalaryDetails.Arrear = (decimal)ds.Tables[2].Rows[0]["Arrear"];
                    ObjUserDetails.objMonthlySalaryDetails.TotalVariable = (decimal)ds.Tables[2].Rows[0]["TotalVariable"];
                    ObjUserDetails.objMonthlySalaryDetails.ESIC = ds.Tables[2].Rows[0]["ESIC"].ToString();
                    ObjUserDetails.objMonthlySalaryDetails.EPF = ds.Tables[2].Rows[0]["EPF"].ToString();

                    ObjUserDetails.objMonthlySalaryDetails.IdCardDed = (decimal)ds.Tables[2].Rows[0]["IdCardDed"];
                    ObjUserDetails.objMonthlySalaryDetails.PantDed = (decimal)ds.Tables[2].Rows[0]["PantDed"];
                    ObjUserDetails.objMonthlySalaryDetails.OtherDed = (decimal)ds.Tables[2].Rows[0]["OtherDed"];
                    ObjUserDetails.objMonthlySalaryDetails.TotalDeduction = (decimal)ds.Tables[2].Rows[0]["TotalDeduction"];

                    ObjUserDetails.objMonthlySalaryDetails.Net_Amount_Paid = (decimal)ds.Tables[2].Rows[0]["Net_Amount_Paid"];
                    ObjUserDetails.objMonthlySalaryDetails.MonthYear = ds.Tables[2].Rows[0]["MonthYear"].ToString();
                }
                ObjUserDetails.objVendorDetails = new VendorDetails();
                if (ds.Tables[3].Rows.Count > 0)
                {
                    ObjUserDetails.objVendorDetails.Id = (Int32)ds.Tables[3].Rows[0]["Id"];
                    ObjUserDetails.objVendorDetails.CompanyName = ds.Tables[3].Rows[0]["CompanyName"].ToString();
                    ObjUserDetails.objVendorDetails.ImageUrl = ds.Tables[3].Rows[0]["ImageUrl"].ToString();
                    ObjUserDetails.objVendorDetails.Address = ds.Tables[3].Rows[0]["Address"].ToString();
                }
                else {
                    ObjUserDetails.ResponseMessage = "No Company Details Found";
                }
                return ObjUserDetails;
            }
            catch (Exception ex)
            {
                ObjUserDetails.ResponseMessage = ex.Message;
                return ObjUserDetails;
            }
        }


        public GetMonthlySalaryDetailsById GetMonthlySalaryDetailsById(EmployeeDetailsByID objEmployeeDetailsByID)
        {
            GetMonthlySalaryDetailsById ObjGetMonthlySalaryDetailsById = new Model.GetMonthlySalaryDetailsById();
            try
            {
                ALevelSalarySlip_DAL dis = new ALevelSalarySlip_DAL();
                ObjGetMonthlySalaryDetailsById.objMonthlySalaryDetails = new MonthlySalaryDetails();
                DataSet ds = dis.MonthlySalaryDetailsByMonth(objEmployeeDetailsByID.EmpId, objEmployeeDetailsByID.Month);

                ObjGetMonthlySalaryDetailsById.objMonthlySalaryDetails = new MonthlySalaryDetails();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ObjGetMonthlySalaryDetailsById.objMonthlySalaryDetails.Empid = (Int32)ds.Tables[0].Rows[0]["Empid"];
                    ObjGetMonthlySalaryDetailsById.objMonthlySalaryDetails.Working_Days = ds.Tables[0].Rows[0]["Working_Days"].ToString();
                    ObjGetMonthlySalaryDetailsById.objMonthlySalaryDetails.Week_Off = (Int32)ds.Tables[0].Rows[0]["Week_Off"];
                    ObjGetMonthlySalaryDetailsById.objMonthlySalaryDetails.Holiday = (Int32)ds.Tables[0].Rows[0]["Holiday"];
                    ObjGetMonthlySalaryDetailsById.objMonthlySalaryDetails.CL = (decimal)ds.Tables[0].Rows[0]["CL"];
                    ObjGetMonthlySalaryDetailsById.objMonthlySalaryDetails.EL = (decimal)ds.Tables[0].Rows[0]["SL"];
                    ObjGetMonthlySalaryDetailsById.objMonthlySalaryDetails.Total_paid_days = ds.Tables[0].Rows[0]["Total_paid_days"].ToString();
                    ObjGetMonthlySalaryDetailsById.objMonthlySalaryDetails.Fixed_Basic = (decimal)ds.Tables[0].Rows[0]["Fixed_Basic"];
                    ObjGetMonthlySalaryDetailsById.objMonthlySalaryDetails.Fixed_VAD = (decimal)ds.Tables[0].Rows[0]["Fixed_VAD"];
                    ObjGetMonthlySalaryDetailsById.objMonthlySalaryDetails.Fixed_HRA = (decimal)ds.Tables[0].Rows[0]["Fixed_HRA"];
                    ObjGetMonthlySalaryDetailsById.objMonthlySalaryDetails.Fixed_SpecialAllowance = (decimal)ds.Tables[0].Rows[0]["Fixed_SpecialAllowance"];
                    ObjGetMonthlySalaryDetailsById.objMonthlySalaryDetails.TotalGross = (decimal)ds.Tables[0].Rows[0]["TotalGross"];
                    ObjGetMonthlySalaryDetailsById.objMonthlySalaryDetails.Basic_Paid = (decimal)ds.Tables[0].Rows[0]["Basic_Paid"];
                    ObjGetMonthlySalaryDetailsById.objMonthlySalaryDetails.VDA_Paid = (decimal)ds.Tables[0].Rows[0]["VDA_Paid"];
                    ObjGetMonthlySalaryDetailsById.objMonthlySalaryDetails.HRA_Paid = (decimal)ds.Tables[0].Rows[0]["HRA_Paid"];

                    ObjGetMonthlySalaryDetailsById.objMonthlySalaryDetails.SpecialAllowance_Paid = (decimal)ds.Tables[0].Rows[0]["SpecialAllowance_Paid"];
                    ObjGetMonthlySalaryDetailsById.objMonthlySalaryDetails.TotalEarninig = (decimal)ds.Tables[0].Rows[0]["TotalEarninig"];
                    ObjGetMonthlySalaryDetailsById.objMonthlySalaryDetails.GWI = (decimal)ds.Tables[0].Rows[0]["GWI"];
                    ObjGetMonthlySalaryDetailsById.objMonthlySalaryDetails.AttendanceAward = (decimal)ds.Tables[0].Rows[0]["AttendanceAward"];
                    ObjGetMonthlySalaryDetailsById.objMonthlySalaryDetails.ServiceAllowance = (decimal)ds.Tables[0].Rows[0]["ServiceAllowance"];
                    ObjGetMonthlySalaryDetailsById.objMonthlySalaryDetails.GWP = (decimal)ds.Tables[0].Rows[0]["GWP"];
                    ObjGetMonthlySalaryDetailsById.objMonthlySalaryDetails.Position_Allowance = (decimal)ds.Tables[0].Rows[0]["Position_Allowance"];
                    ObjGetMonthlySalaryDetailsById.objMonthlySalaryDetails.Variable_Allowance = (decimal)ds.Tables[0].Rows[0]["Variable_Allowance"];

                    ObjGetMonthlySalaryDetailsById.objMonthlySalaryDetails.Arrear = (decimal)ds.Tables[0].Rows[0]["Arrear"];
                    ObjGetMonthlySalaryDetailsById.objMonthlySalaryDetails.TotalVariable = (decimal)ds.Tables[0].Rows[0]["TotalVariable"];
                    ObjGetMonthlySalaryDetailsById.objMonthlySalaryDetails.ESIC = ds.Tables[0].Rows[0]["ESIC"].ToString();
                    ObjGetMonthlySalaryDetailsById.objMonthlySalaryDetails.EPF = ds.Tables[0].Rows[0]["EPF"].ToString();

                    ObjGetMonthlySalaryDetailsById.objMonthlySalaryDetails.IdCardDed = (decimal)ds.Tables[0].Rows[0]["IdCardDed"];
                    ObjGetMonthlySalaryDetailsById.objMonthlySalaryDetails.PantDed = (decimal)ds.Tables[0].Rows[0]["PantDed"];
                    ObjGetMonthlySalaryDetailsById.objMonthlySalaryDetails.OtherDed = (decimal)ds.Tables[0].Rows[0]["OtherDed"];
                    ObjGetMonthlySalaryDetailsById.objMonthlySalaryDetails.TotalDeduction = (decimal)ds.Tables[0].Rows[0]["TotalDeduction"];

                    ObjGetMonthlySalaryDetailsById.objMonthlySalaryDetails.Net_Amount_Paid = (decimal)ds.Tables[0].Rows[0]["Net_Amount_Paid"];
                    ObjGetMonthlySalaryDetailsById.objMonthlySalaryDetails.MonthYear = ds.Tables[0].Rows[0]["MonthYear"].ToString();
                    
                    ObjGetMonthlySalaryDetailsById.ResponseMessage = "Success"; 

                }
                else {
                    ObjGetMonthlySalaryDetailsById.ResponseMessage = "No Record Found"; 
                }

                return ObjGetMonthlySalaryDetailsById;
            }
            catch (Exception ex)
            {
                ObjGetMonthlySalaryDetailsById.ResponseMessage = ex.Message;
                return ObjGetMonthlySalaryDetailsById;
            }
        }

        public ResponseMessage1 InsFeedback(Feedback objFeedback)
        {
            ResponseMessage1 objResponseMessage = new ResponseMessage1();
            try
            {
                ALevelSalarySlip_DAL dis = new ALevelSalarySlip_DAL();
                DataSet ds = dis.InsertFeedback(objFeedback.Rating, objFeedback.Message,objFeedback.MessageType, objFeedback.UserId);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToInt32(ds.Tables[0].Rows[0]["value"]) == 1)
                    {
                        objResponseMessage.ResponseMessage = "Success";
                    }
                    else
                    {
                        objResponseMessage.ResponseMessage = "Invalid Details";
                    }

                    //  result = "{\"Response\" : [{\"Responsecode\" : \"0\" , \"Response\" : \"Success\"}] , \"Data\" : " + result + "}";
                }
                else
                {
                    objResponseMessage.ResponseMessage = "Invalid Details";
                    // result = "{\"Response\" : [{\"Responsecode\" : \"1\" , \"Response\" : \"Invaild Username and Password\" }]}";
                }

                return objResponseMessage;
            }
            catch (Exception ex)
            {
                //General.LogSteps("GetRechargePlan", System.Web.Hosting.HostingEnvironment.MapPath("~\\AndriodRecharge.txt"));
                objResponseMessage.ResponseMessage = ex.Message;
                return objResponseMessage;
            }
        }
    }
}
