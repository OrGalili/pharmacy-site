using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


public static class AdministratorsDAL
{
    public static int InsertNewAdmin(string AccessName , string Password)
    {
        string sql = string.Format("INSERT INTO Administrators(AccessName,Password) VALUES('{0}','{1}')", AccessName, Password);
        return DataAccess.ExecuteNonQuery(sql);
    }
    public static int DeleteAdmin(string AccessName)
    {
        string sql = string.Format("DELETE FROM Administrators WHERE AccessName='{0}'", AccessName);
        return DataAccess.ExecuteNonQuery(sql);
    }
    public static int UpdateAdmin(string AccessName, string Password,int AdministratorId)
    {
        string sql = string.Format("UPDATE Administrators SET AccessName='{0}',Password='{1}' WHERE AdministratorId='{2}'", AccessName, Password, AdministratorId);
        return DataAccess.ExecuteNonQuery(sql);
    }
    public static DataTable GetAdminsList()
    {
        string sql = "SELECT AccessName ,Password FROM Administrators";
        return DataAccess.GetDataTable(sql, "Admins");
    }
    public static int ChangePassword(string Password , string AccessName)
    {
        string sql = string.Format("UPDATE Administrators SET Password='{0}' WHERE AccessName='{1}'", Password, AccessName);
        return DataAccess.ExecuteNonQuery(sql);
    }
}
