using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


public static class MedicineCategoriesDAL
{
    public static string GetCategoryName(int CategoryId)
    {
        string sql = string.Format(@"SELECT Name FROM MedicineCategories
                                     WHERE (CategoryId = '{0}')", CategoryId);
        return (string)DataAccess.ExecuteScalar(sql);
    }
    public static int GetCategoryId(string Name)
    {
        string sql = string.Format(@"SELECT CategoryId FROM MedicineCategories 
                                     WHERE (Name = '{0}')", Name);
        return (int)DataAccess.ExecuteScalar(sql);
    }
    public static DataTable GetAllCategories()
    {
        string sql = "SELECT MedicineCategories.* FROM MedicineCategories";
        return DataAccess.GetDataTable(sql, "MedicineCategories");
    }
    public static int InsertCategorie(string categoryName)
    {
        string sql = "INSERT INTO MedicineCategories (Name) VALUES('{"+categoryName+"}')";
        return DataAccess.ExecuteNonQuery(sql);
    }
    public static int isExictent(string categoryName)
    {
        string sql = @"SELECT COUNT(Name) AS Expr1 FROM MedicineCategories
                       WHERE (Name = '" + categoryName + "')";
        return int.Parse(DataAccess.ExecuteScalar(sql).ToString());
    }
    public static int UpdateMedicineCategoryCount(int categoryId,int count)
    {
        string sql = string.Format("UPDATE MedicineCategories SET Count=Count+'{0}' WHERE (CategoryId='{1}')", count, categoryId);
        return DataAccess.ExecuteNonQuery(sql);
    }
    public static int GetNumberCategories()
    {
        string sql = "SELECT COUNT(Name) AS Expr1 FROM MedicineCategories";
        return int.Parse(DataAccess.ExecuteScalar(sql).ToString());
    }
    public static int GetSumCount()
    {
        string sql = "SELECT Sum(Count) FROM MedicineCategories";
        return int.Parse(DataAccess.ExecuteScalar(sql).ToString());
    }
}
