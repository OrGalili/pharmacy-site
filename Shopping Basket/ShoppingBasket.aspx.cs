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

public partial class Shopping_Basket_ShoppingBasket : System.Web.UI.Page
{
    DataTable MedicinesOrdered;
    ArrayList MedicinesId;
    protected void Page_Load(object sender, EventArgs e)
    {
        MedicinesId = (ArrayList)Session["MedicinesId"];
        if (MedicinesId == null)
        {
            LabelNoBasket.Visible = true;
            HyperLinkGoBack.Visible = true;
            HyperLinkContinueShopping.Visible = false;
            LinkButtonCashBox.Visible = false;
        }
        else if (ViewState["Invitation"] == null)
        {
            DataTable AllMedicines = MedicinesDAL.GetAllMedicines();
            if (Session["MedicinesOrdered"] != null)
            {
                MedicinesOrdered = (DataTable)Session["MedicinesOrdered"];
                MedicinesOrdered = MedicinesBL.AddMedicinesToSortMedicines(MedicinesId, AllMedicines, MedicinesOrdered);
            }
            else
                MedicinesOrdered = MedicinesBL.SortMedicines(MedicinesId, AllMedicines);
            Session["MedicinesOrdered"] = MedicinesOrdered;
            ViewState["Invitation"] = MedicinesOrdered;
            GridViewBinding();
        }
        else
            MedicinesOrdered = (DataTable)ViewState["Invitation"];
    }
    protected void GridViewBinding()
    {
        GridViewShoppingBasket.AutoGenerateColumns = false;
        GridViewShoppingBasket.DataSource = MedicinesOrdered;
        GridViewShoppingBasket.DataBind();
    }
    protected void GridViewShoppingBasket_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        if (Session["MedicinesOrdered"] != null)
        {
            int MedicineId = int.Parse(MedicinesOrdered.Rows[e.RowIndex]["MedicineId"].ToString());
            MedicinesId = MedicinesBL.DeleteMedicineIdFromArray(MedicineId, MedicinesId);
            MedicinesOrdered.Rows[e.RowIndex].Delete();
            Session["MedicinesOrdered"] = MedicinesOrdered;
            Session["Count"] = MedicinesOrdered.Rows.Count;
            if (MedicinesOrdered.Rows.Count != 0)
                ((Label)(this.Master.FindControl("LabelBasketStatus"))).Text = MedicinesOrdered.Rows.Count.ToString() + " products in the cart";
            else
            {
                LabelNoBasket.Visible = true;
                HyperLinkGoBack.Visible = true;
                HyperLinkContinueShopping.Visible = false;
                LinkButtonCashBox.Visible = false;
                Session["Count"] = null;
                Session["MedicinesOrdered"] = null;
                Session["MedicinesId"] = null;
                ((Label)(this.Master.FindControl("LabelBasketStatus"))).Text = "empty basket";
            }
        }
        GridViewBinding();
    }

    protected void GridViewShoppingBasket_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string count = ((TextBox)GridViewShoppingBasket.Rows[e.RowIndex].Cells[2].Controls[0]).Text;
        MedicinesOrdered.Rows[e.RowIndex]["Count"] = int.Parse(count);
        MedicinesBL.TotalPriceForEachMedicine(MedicinesOrdered);
        Session ["MedicinesOrdered"]= MedicinesOrdered ;
        GridViewShoppingBasket.EditIndex = -1;
        GridViewBinding();
    }
    protected void GridViewShoppingBasket_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridViewShoppingBasket.EditIndex = e.NewEditIndex;
        GridViewBinding();
    }
    protected void GridViewShoppingBasket_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridViewShoppingBasket.EditIndex = -1;
        GridViewBinding();
    }
    protected void LinkButtonCashBox_Click(object sender, EventArgs e)
    {
        int TotalPrice = MedicinesBL.TotalPriceOfMedicinesOrdered(MedicinesOrdered);
        Response.Redirect(@"~\Shopping Basket\CashBox.aspx?TP=" + TotalPrice);
    }
}
