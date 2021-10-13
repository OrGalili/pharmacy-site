using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public static class MedicinesDAL
{
    public static int InsertNewMedicine(string MedicineName ,int Category , string Discription , int Stock ,string imgUrl,int Price)
    {
        string sql = string.Format("Insert into Medicines(MedicineName,Category,Discription,Stock,Image,Price) values('{0}','{1}','{2}','{3}','{4}','{5}')", MedicineName, Category, Discription, Stock, imgUrl, Price);
        return DataAccess.ExecuteNonQuery(sql);
    }
    public static int UpdateMedicine(string MedicineName, int Category, string Discription, int Stock, string imgUrl,int Price, int MedicineId)
    {
        string sql = string.Format("UPDATE Medicines SET MedicineName='{0}',Category='{1}',Discription='{2}',Stock='{3}',Image='{4}',Price='{5}' WHERE MedicineId='{6}'",MedicineName,Category,Discription,Stock,imgUrl,Price,MedicineId);
        return DataAccess.ExecuteNonQuery(sql);
    }
    public static int DeleteMedicine(int MedicineId)
    {
        string sql = string.Format("DELETE FROM Medicines WHERE MedicineId='{0}'", MedicineId);
        return DataAccess.ExecuteNonQuery(sql);
    }
    public static DataTable GetMedicinesInCategory(int Category)
    {
        string sql = string.Format(@"SELECT Medicines.*, Category AS Expr1
                                       FROM Medicines
                                       WHERE (Category = '{0}')", Category);
        return DataAccess.GetDataTable(sql,"Medicines");
    }
    public static DataTable GetMedicineDetails(int MedicineId)
    {
        string sql = string.Format(@"SELECT Medicines.*
                                       FROM  Medicines
                                       WHERE (MedicineId = '{0}')", MedicineId);
        return DataAccess.GetDataTable(sql,"MedicineDetails");
    }
    public static DataTable GetAllMedicinesNameAndId()
    {
        string sql = "SELECT MedicineId, MedicineName FROM Medicines";
        return DataAccess.GetDataTable(sql, "Medicines");
    }
    public static DataTable GetAllMedicines()
    {
        string sql = "SELECT Medicines. * FROM Medicines";
        return DataAccess.GetDataTable(sql, "Medicines");
    }
    public static DataTable FindMedicines(string findStr)
    {
        string sql = "select * from Medicines where Cast(MedicineName AS Nvarchar(max))like N'%" + findStr + "%'";
        return DataAccess.GetDataTable(sql, "Medicines");
    }
    public static DataTable GetEmptyTable()
    {
        string sql = "SELECT Medicines. * FROM Medicines Where MedicineId = -1";
        return DataAccess.GetDataTable(sql, "Medicines");
    }
    public static string GetMedicineDiscription(int Medicineid)
    {
        string sql = "SELECT Discription FROM Medicines WHERE(MedicineId = '" + Medicineid + "')";
        return (string)DataAccess.ExecuteScalar(sql);
    }
    public static int GetMedicineStock(int MedicineId)
    {
        string sql = string.Format("SELECT Stock FROM Medicines WHERE(MedicineId='{0}')", MedicineId);
        return (int)DataAccess.ExecuteScalar(sql);
    }
    public static int InsertMedicineStock(int stock ,int medicineId)
    {
        string sql = string.Format("UPDATE Medicines SET Stock='{0}' WHERE (MedicineId='{1}')", stock, medicineId);
        return DataAccess.ExecuteNonQuery(sql);
    }
    public static int SubMedicineStock(int medicineId , int count)
    {
        string sql = string.Format("UPDATE Medicines SET Stock = Stock-'{0}' WHERE (MedicineId='{1}')", count, medicineId);
        return DataAccess.ExecuteNonQuery(sql);
    }
    public static DataTable GetLowStockMedicines()
    {
        string sql = "SELECT MedicineId,MedicineName,Stock FROM Medicines WHERE Stock<=15";
        return DataAccess.GetDataTable(sql, "LowStockMedicines");
    }
    public static int AddMedicineStock(int medicineId, int count)
    {
        string sql = string.Format("UPDATE Medicines SET Stock = Stock+'{0}' WHERE (MedicineId='{1}')", count, medicineId);
        return DataAccess.ExecuteNonQuery(sql);
    }
    public static string GetMedicineName(int medicineId)
    {
        string sql = "SELECT MedicineName FROM Medicines WHERE MedicineId ='" + medicineId + "'";
        return (string)DataAccess.ExecuteScalar(sql);
    }
    public static int UpdateNullDiscriptoins()
    {
        string sql = "UPDATE Medicines SET Discription = 'אין פרטים על התרופה' WHERE(Discription IS NULL) OR Discription=''";
        return DataAccess.ExecuteNonQuery(sql);
    }
}
