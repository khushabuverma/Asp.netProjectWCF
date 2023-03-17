using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
namespace ALevelSalarySlipServices.DAL
{
    public class ALevelSalarySlip_DAL : Database
    {
        public DataSet login_app(int emp_id, string pass)
        {
            try
            {
                using (SqlCommand objCmd = new SqlCommand("udp_ValidateAppUser"))
                {
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.Parameters.Add("@UserId", SqlDbType.BigInt).Value = emp_id;
                    objCmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = pass;
                    return ReturnDataSet(objCmd);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Check_LastestVersion(int VersionId)
        {

            try
            {
                using (SqlCommand objcmd = new SqlCommand("udp_GetAppLatestVersion"))
                {
                    objcmd.CommandType = CommandType.StoredProcedure;
                    objcmd.Parameters.Add("@Ver_Id", SqlDbType.Int).Value = VersionId;
                    return ReturnDataSet(objcmd);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet validateoldpassword(string OldPassword, int UserId)
        {
            try
            {
                using (SqlCommand objCmd = new SqlCommand("udp_validatepassword"))
                {
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.Parameters.Add("@OldPassword", SqlDbType.NVarChar).Value = OldPassword;
                    objCmd.Parameters.Add("@UserId", SqlDbType.Int).Value = UserId;
                    return ReturnDataSet(objCmd);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet ChangePassword(string OldPassword, int UserId, string Newpassword)
        {
            try
            {
                using (SqlCommand objCmd = new SqlCommand("udp_ChangePasswordApp"))
                {
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.Parameters.Add("@OldPassword", SqlDbType.NVarChar).Value = OldPassword.Trim();
                    objCmd.Parameters.Add("@UserId", SqlDbType.Int).Value = UserId;
                    objCmd.Parameters.Add("@newPassword", SqlDbType.NVarChar).Value = Newpassword.Trim();
                    return ReturnDataSet(objCmd);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetEmployeesDetails(int UserId)
        {
            try
            {
                using (SqlCommand objCmd = new SqlCommand("udp_GetEmployeeDetails"))
                {
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.Parameters.Add("@EmpId", SqlDbType.Int).Value = UserId;
                    return ReturnDataSet(objCmd);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet MonthlySalaryDetailsByMonth(int UserId,string Month)
        {
            try
            {
                using (SqlCommand objCmd = new SqlCommand("udp_GetEmployeeMonthlyDetailsByMonth"))
                {
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.Parameters.Add("@EmpId", SqlDbType.Int).Value = UserId;
                    objCmd.Parameters.Add("@MonthYear", SqlDbType.NVarChar).Value = Month;
                    return ReturnDataSet(objCmd);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet InsExceptionMsg_(string UserId, string Error_MessageR)
        {
            try
            {
                using (SqlCommand objCmd = new SqlCommand("Udp_InsExaminationList"))
                {
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.Parameters.Add("@UserId", SqlDbType.NVarChar).Value = UserId.Trim();
                    objCmd.Parameters.Add("@Error_MessageR", SqlDbType.NVarChar).Value = Error_MessageR;
                    return ReturnDataSet(objCmd);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet InsertFeedback(string Rating, string Message, string MessageType, int UserId)
        {
            try
            {
                using (SqlCommand objCmd = new SqlCommand("udp_GetProcFeedback"))
                {
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.Parameters.Add("@Rating", SqlDbType.NVarChar).Value = Rating.Trim();
                    objCmd.Parameters.Add("@Message", SqlDbType.NVarChar).Value = Message.Trim();
                    objCmd.Parameters.Add("@UserId", SqlDbType.Int).Value = UserId;
                    objCmd.Parameters.Add("@MessageType", SqlDbType.NVarChar).Value = MessageType.Trim();
                    objCmd.Parameters.Add("@CreatedDate", SqlDbType.NVarChar).Value = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));
                    return ReturnDataSet(objCmd);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
