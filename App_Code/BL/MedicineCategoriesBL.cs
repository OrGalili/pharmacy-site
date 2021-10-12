using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;


public static class MedicineCategoriesBL
{
    public static ArrayList CalculateCategoriesPrecent()
    {
        ArrayList precentResult = new ArrayList();
        DataTable categoriesTable = MedicineCategoriesDAL.GetAllCategories();
        double sum = MedicineCategoriesDAL.GetSumCount();
        foreach (DataRow dr in categoriesTable.Rows)
        {
            double categoryPrecent = double.Parse(dr["Count"].ToString()) * 100 / sum;
            precentResult.Add(categoryPrecent);
            if (sum * 0.2 <= int.Parse(dr["Count"].ToString()))
                precentResult.Add("Yes");
            else
                precentResult.Add("No");
        }
        return precentResult;
    }
}
