using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public static class CostumersDAL
{
    public static int InsertNewCostumer(string FirstName, string LastName, string Address, string PhoneNumber, string UserName , string Pass ,string Email)
    {
        string sql = string.Format("INSERT INTO Costumers (FirstName,LastName,Address,PhoneNumber,UserName,Password,Email) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", FirstName, LastName, Address, PhoneNumber, UserName, Pass, Email);
        return DataAccess.ExecuteNonQuery(sql);
    }
    public static int DeleteCostumer(int CostumerId)
    {
        string sql = string.Format("DELETE FROM Costumers WHERE CostumerId='{0}'", CostumerId);
        return DataAccess.ExecuteNonQuery(sql);
    }
    public static int UpdateCostumer(string FirstName, string LastName, string Address, string PhoneNumber, DateTime LastInvitation , int CostumerId)
    {
        string sql = string.Format("UPDATE Costumers SET FirstName='{0}',LastName='{1}',Address='{2}',PhoneNumber='{3}',LastInvitation='{4}' WHERE CostumerId='{5}'",FirstName,LastName,Address,PhoneNumber,LastInvitation,CostumerId);
        return DataAccess.ExecuteNonQuery(sql);
    }
    public static int isExictent(string UserName)
    {
        string sql = @"SELECT COUNT(UserName) AS Expr1 FROM Costumers
                       WHERE (UserName = '" + UserName + "')";
        return int.Parse(DataAccess.ExecuteScalar(sql).ToString());
    }
    public static DataTable GetCostumersList()
    {
        string sql = @"SELECT UserName, Password FROM Costumers";
        return DataAccess.GetDataTable(sql,"Costumers");
    }
    public static int ChangePassword(string UserName, string Password)
    {
        string sql = string.Format("UPDATE Costumers SET Password='{0}' WHERE UserName='{1}'", Password, UserName);
        return DataAccess.ExecuteNonQuery(sql);
    }
    public static DataTable GetCostumerDetails(string userName)
    {
        string sql = "SELECT * FROM Costumers WHERE (UserName ='"+userName+"')";
        return DataAccess.GetDataTable(sql, "Costumer");
    }
    public static string GetCostumerId(string userName)
    {
        string sql = "SELECT CostumerId FROM Costumers WHERE (UserName ='" + userName + "')";
        return DataAccess.ExecuteScalar(sql).ToString();
    }
}
