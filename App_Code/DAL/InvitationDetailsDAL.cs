using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


public static class InvitationDetailsDAL
{
    public static int InsertMedicineToInvitation(int ShoppingId,int MedicineId)
    {
        string sql = string.Format(@"INSERT INTO InvitationDetails
                      (ShoppingId,MedicineId) VALUES ('{0}','{1}')", ShoppingId, MedicineId);
        return DataAccess.ExecuteNonQuery(sql);
    }
    public static int DeleteMedicineToInvitation(int ShoppingId, int MedicineId)
    {
        string sql = string.Format(@"DELETE FROM InvitationDetails MedicineId='{0}' WHERE ShoppingId='{1}'",MedicineId , ShoppingId);
        return DataAccess.ExecuteNonQuery(sql);
    }
    public static int DeleteAllInvitation(int ShoppingId)
    {
        string sql = "DELETE FROM InvitationDetails WHERE ShoppingId='" + ShoppingId + "'";
        return DataAccess.ExecuteNonQuery(sql);
    }
    public static int UpdateMedicineQuantity(int Quantity,int ShoppingId,int MedicineId)
    {
        string sql = string.Format(@"UPDATE InvitationDetails SET Quantity='{0}' WHERE ShoppingId='{1}' AND MedicineId='{2}'",Quantity, ShoppingId, MedicineId);
        return DataAccess.ExecuteNonQuery(sql);
    }
}
