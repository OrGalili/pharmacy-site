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
//using HMO;

public partial class Shopping_Basket_CashBox : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dt = CostumersDAL.GetCostumerDetails(Session["CostumerLogedIn"].ToString());
            DataRow CostumerDetails = dt.Rows[0];
            LabelUserName.Text = Session["CostumerLogedIn"].ToString();
            LabelFirstName.Text = CostumerDetails["FirstName"].ToString();
            LabelLastName.Text = CostumerDetails["LastName"].ToString();
            LabelEmail.Text = CostumerDetails["Email"].ToString();
            LabelTotalPrice.Text = Request.QueryString["TP"];
        }
    }
    protected void ButtonOrder_Click(object sender, EventArgs e)
    {
        InvitationsDAL.InsertNewInvitation(Session["CostumerLogedIn"].ToString());
        int lastShopId = InvitationsDAL.GetLastInvitationId();
        DataTable MedicinesOrdered = (DataTable)Session["MedicinesOrdered"];
        int medicineId;
        int quantity;
        int category;
        foreach (DataRow dr in MedicinesOrdered.Rows)
        {
            category = int.Parse(dr["Category"].ToString());
            medicineId = int.Parse(dr["MedicineId"].ToString());
            quantity = int.Parse(dr["Count"].ToString());
            DataTable dt = MedicinesDAL.GetMedicineDetails(medicineId);
            if (dt.Rows [0]["NeedRecipe"].ToString() == "true")
        //        (new HMO.Service()).MedicineUsed(medicineId);

            InvitationDetailsDAL.InsertMedicineToInvitation(lastShopId, medicineId);
            InvitationDetailsDAL .UpdateMedicineQuantity (quantity,lastShopId,medicineId);
            MedicinesDAL.SubMedicineStock(medicineId, quantity);
            MedicineCategoriesDAL.UpdateMedicineCategoryCount(category, quantity);
        }

        Response.Redirect(@"~\Shopping Basket\TnxForBuying.aspx");
    }
}