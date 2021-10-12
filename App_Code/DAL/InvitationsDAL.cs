using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public static class InvitationsDAL
{
    public static int InsertNewInvitation(string UserName)
    {
        string sql = string.Format(@"INSERT INTO Invitations
        (UserName) VALUES ('{0}')", UserName);
        return DataAccess.ExecuteNonQuery(sql);
    }
    public static int DeleteInvitation(int ShoppingId)
    {
        string sql = string.Format(@"DELETE FROM Invitations WHERE ShoppingId='{0}'", ShoppingId);
        return DataAccess.ExecuteNonQuery(sql);
    }
    public static int UpdateInvitation(string UserName, int ShoppingId)
    {
        string sql = string.Format(@"UPDATE Invitations SET UserName='{0}' WHERE ShoppingId='{1}'", UserName, ShoppingId);
        return DataAccess.ExecuteNonQuery(sql);
    }
    public static int GetLastInvitationId()
    {
        string sql = "SELECT max(ShoppingId) FROM Invitations";
        return int.Parse (DataAccess.ExecuteScalar(sql).ToString());
    }
}
