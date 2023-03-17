using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace ALevelSalarySlipServices.DAL
{
    public class Database
    {
        SqlConnection con;
        SqlCommand cmd;
        static string Con1 = "Data Source= 172.20.230.27; Initial Catalog=tos721; user=sa; password=cctvbbk;";
        SqlConnection con1 = new SqlConnection(Con1);

        public Database()
        {
            string Con = "Data Source= 172.24.140.14\\SQLEXPRESS; Initial Catalog=A_Level_Salary_Slip; user=sa; password=vivo@12345;";
            con = new SqlConnection(Con);
        }

        protected DataTable FetchData(string sqlQuery)
        {
            cmd = new SqlCommand(sqlQuery, con);
            cmd.CommandType = CommandType.Text;
            try
            {
                DataTable dt = new DataTable("ResultDataTable");
                con.Open();
                dt.Load(cmd.ExecuteReader());
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
                cmd.Dispose();
            }
        }

        protected object RunCommand(SqlCommand cmd)
        {
            try
            {
                cmd.Connection = con;
                cmd.CommandTimeout = 120;
                con.Open();
                return cmd.ExecuteScalar();
                //return cmd;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        protected Int32 RunExecuteNoneQuery(SqlCommand cmd)
        {
            try
            {
                cmd.Connection = con;
                cmd.CommandTimeout = 120;
                con.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        protected DataTable ExecuteSqlData(string sqlQuery, SqlCommand cmd = null)
        {
            if (sqlQuery != String.Empty)
            {
                cmd = new SqlCommand(sqlQuery);
                cmd.CommandType = CommandType.Text;
            }

            try
            {
                DataTable dt = new DataTable("ResultDataTable");
                cmd.Connection = con;
                con.Open();
                dt.Load(cmd.ExecuteReader());
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
                cmd.Dispose();
            }
        }
        protected DataSet ReturnDataSetotherserver(SqlCommand objCmd)
        {
            try
            {
                DataSet objDS = new DataSet();
                SqlDataAdapter objDA = null;
                objCmd.CommandType = CommandType.Text;
                objCmd.Connection = con1;
                objCmd.CommandTimeout = 120;
                con1.Open();
                using (objDA = new SqlDataAdapter(objCmd))
                {
                    objDA.Fill(objDS);
                    return objDS;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con1.State == ConnectionState.Open)
                    con1.Close();
                // cmd.Dispose();
            }
        }
        protected DataSet ReturnDataSet(SqlCommand objCmd)
        {
            try
            {
                DataSet objDS = new DataSet();
                SqlDataAdapter objDA = null;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Connection = con;
                objCmd.CommandTimeout = 120;
                con.Open();
                using (objDA = new SqlDataAdapter(objCmd))
                {
                    objDA.Fill(objDS);
                    return objDS;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
                // cmd.Dispose();
            }
        }
    }
}
