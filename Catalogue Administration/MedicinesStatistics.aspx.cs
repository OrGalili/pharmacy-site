using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Catalogue_Administration_MedicinesStatistics : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ((Panel)(this.Master.FindControl("PanelAdmin"))).Visible = true;
        MakeTable();
    }
    private void MakeTable()
    {
        //T - Table
        //P - Precent
        int numRows = MedicineCategoriesDAL.GetNumberCategories();
        DataTable CategoriesT = MedicineCategoriesDAL.GetAllCategories();
        ArrayList CategoriesP = MedicineCategoriesBL.CalculateCategoriesPrecent();
        for (int r = 0 , i = 0; r < numRows; r++,i+=2)
        {
            Image point = new Image();
            point.ImageUrl = @"~/Images/Design/red[2].gif";
            TableRow row = new TableRow();
            TableCell cNotRecommended = new TableCell();
            TableCell cRecommended = new TableCell();
            if (CategoriesP [i+1].ToString()== "No")
            {
                cNotRecommended.Controls.Add(point);
                row.Cells.Add(cNotRecommended);
                row.Cells.Add(cRecommended);
            }
            else
            {
                cRecommended.Controls.Add(point);
                row.Cells.Add(cNotRecommended);
                row.Cells.Add(cRecommended);
            }
            TableCell precent = new TableCell();
            TableCell name = new TableCell();
            if (double.Parse(CategoriesP[i].ToString()) < 10)
                precent.Text = CategoriesP[i].ToString().Substring(0, 4) + "%";
            else
                precent.Text = CategoriesP[i].ToString().Substring(0, 5) + "%";
            row.Cells.Add(precent);
            name.Text = CategoriesT.Rows[r]["Name"].ToString();
            row.Cells.Add(name);
            TableStatistics.Rows.Add(row);
        }
    }
}
