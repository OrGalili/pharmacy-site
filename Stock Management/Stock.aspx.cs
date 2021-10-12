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

public partial class Stock_Mengment_Stock : System.Web.UI.Page
{
    DataTable LowStockMedicines;
    protected void Page_Load(object sender, EventArgs e)
    {
        ((Panel)(this.Master.FindControl("PanelAdmin"))).Visible = true;
        LowStockMedicines = MedicinesDAL.GetLowStockMedicines();
        if (LowStockMedicines.Rows.Count == 0)
            LabelAllOk.Visible = true;
        else if (ViewState["LowStockMedicines"] == null)
        {
            ViewState["LowStockMedicines"] = LowStockMedicines;
            GridViewBinding();
        }
        else
            LowStockMedicines = (DataTable)ViewState["LowStockMedicines"];
        
    }
    protected void GridViewBinding()
    {
        GridViewLowStockMedicines.AutoGenerateColumns = false;
        GridViewLowStockMedicines.DataSource = LowStockMedicines;
        GridViewLowStockMedicines.DataBind();
    }
    protected void GridViewLowStockMedicines_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridViewLowStockMedicines.EditIndex = e.NewEditIndex;
        GridViewBinding();
    }
    protected void GridViewLowStockMedicines_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string medicineId = GridViewLowStockMedicines.Rows[e.RowIndex].Cells[0].Text;
        string count = ((TextBox)GridViewLowStockMedicines.Rows[e.RowIndex].Cells[4].Controls[0]).Text;
        MedicinesDAL.AddMedicineStock(int.Parse(medicineId), int.Parse(count));
        LowStockMedicines = MedicinesDAL.GetLowStockMedicines();
        if (LowStockMedicines.Rows.Count == 0)
            LabelAllOk.Visible = true;
        ViewState["LowStockMedicines"] = LowStockMedicines;
        GridViewLowStockMedicines.EditIndex = -1;
        GridViewBinding();
    }
    protected void GridViewLowStockMedicines_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridViewLowStockMedicines.EditIndex = -1;
        GridViewBinding();
    }
}
