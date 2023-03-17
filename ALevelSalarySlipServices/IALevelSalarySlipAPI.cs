using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Script.Serialization;
using System.Net;
using System.Web.Script.Services;
using System.Data;
using ALevelSalarySlipServices.Model;

namespace ALevelSalarySlipServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IALevelSalarySlipAPI
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/AppLogin")]
        UserDetails login_app(Login objLogin);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/Check_LatestVersion")]
        AppVersionDetails Check_AppVersion(ExamVersion objExamVersion);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/ValidateOldPassword")]
        ResponseMessage1 ValidateOldPassword(ChangePassword objExamVersion);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/ChangeAppUserPassword")]
        ResponseMessage1 ChangePassword(ChangePassword objExamVersion);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/InsertExceptionMsg")]
        ResponseMessage1 InsExceptionMsg(ExceptionMsg objExceptionMsg);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/GetEmployeeDetailsById")]
        EmployeeDetailslist GetEmployeeDetails(Login objLogin);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/GetEmployeeMonthlySalaryDetailsByMonth")]
        GetMonthlySalaryDetailsById GetMonthlySalaryDetailsById(EmployeeDetailsByID objEmployeeDetailsByID);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/InsFeedBack")]
        ResponseMessage1 InsFeedback(Feedback objFeedback);
    }
}
