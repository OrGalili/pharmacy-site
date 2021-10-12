using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

//https://msdn.microsoft.com/en-us/library/System.Data.SqlClient.SqlConnection(v=vs.110).aspx
public class DataAccess
{
     static private string connString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=" + System.IO.Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory) + @"\App_Data\PharmacyDB.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
        public static int ExecuteNonQuery(string strSql)
        {
            int rowsAffected;
            SqlConnection connection = new SqlConnection(connString);
            SqlCommand command = new SqlCommand(strSql, connection);
            connection.Open();
            rowsAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowsAffected;
        }

        public static Object ExecuteScalar(string strSql)
        {
            SqlConnection connection = new SqlConnection(connString);
            SqlCommand command = new SqlCommand(strSql, connection);
            connection.Open();
            Object obj = command.ExecuteScalar();
            connection.Close();
            return obj;
        }

        static public DataTable GetDataTable(string strSql, string table_name)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(connString);
            SqlCommand command = new SqlCommand(strSql, connection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(strSql, connection);
            dataAdapter.Fill(dt);
            dt.TableName = table_name;
            return dt;
        }
        public static void UpdateDataTable(DataTable dt)
        {
            SqlConnection connection = new SqlConnection(connString);
            SqlCommand command = new SqlCommand("SELECT * FROM " + dt.TableName + " WHERE 1=0", connection);
            command.Connection = connection;
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = command;
            dataAdapter.Fill(dt);

            SqlCommandBuilder builder = new SqlCommandBuilder(dataAdapter);

            dataAdapter.Update(dt);

        }
}
