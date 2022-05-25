using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateIndustrialSystem.DAL
{
    public class DataAccess
    {
        string connStr = ConfigurationManager.ConnectionStrings["db"].ConnectionString;

        SqlConnection conn;
        SqlCommand comm;
        SqlDataAdapter adapter;
        SqlTransaction trans;

        /// <summary>
        /// 操作完成后对三个变量进行注销
        /// </summary>
        private void Dispose()
        {
            if (adapter != null)
            {
                adapter.Dispose();
                adapter = null;
            }
            if (comm != null)
            {
                comm.Dispose();
                comm = null;
            }
            if (conn != null)
            {
                conn.Close();
                conn.Dispose();
                conn = null;
            }
            if (trans != null)
            {
                trans.Dispose();
                trans = null;
            }
        }

        private DataTable GetDatas(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                conn = new SqlConnection(connStr);
                conn.Open();

                adapter = new SqlDataAdapter(sql, conn);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.Dispose();
            }

            return dt;
        }

        public DataTable GetStorageArea()
        {
            string strSql = "select * from create_industrial_system_storage_area";
            return this.GetDatas(strSql);
        }
        public DataTable GetDevices()
        {
            string strSql = "select * from create_industrial_system_devices";
            return this.GetDatas(strSql);
        }
        public DataTable GetMonitorValues()
        {
            string strSql = "select * from create_industrial_system_monitor_values ORDER BY d_id, value_id";
            return this.GetDatas(strSql);
        }
    }
}
