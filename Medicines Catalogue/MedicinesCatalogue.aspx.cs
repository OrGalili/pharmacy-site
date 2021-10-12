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

public partial class Medicines_Catalogue_MedicinesCatalogue : System.Web.UI.Page
{
    DataTable MedicinesTable;
    ArrayList MedicinesId;
    string idCustomer;
    string findText = "";
        
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["CostumerLogedIn"] != null )
            idCustomer = CostumersDAL.GetCostumerId(Session["CostumerLogedIn"].ToString());

        if (Request.QueryString["findText"] != null)
            findText = Request.QueryString["findText"].ToString();

        int idCategory = 1;
        if (Session["MedicinesId"] != null)
            MedicinesId = (ArrayList)Session["MedicinesId"];
        else
            MedicinesId = new ArrayList();

        if (!IsPostBack)
            Binding(idCategory);

        if (Request.QueryString["CategoryId"] != null)
        {
            idCategory = int.Parse(Request.QueryString["CategoryId"]);
            Binding(idCategory);
        }
        else if (findText != "")
        {
            MedicinesTable = MedicinesDAL.FindMedicines(findText);
            DataListCategoryMedicines.DataSource = MedicinesTable;
            DataListCategoryMedicines.DataBind();
        }
        // alexshikma@walla.com 0542509698 0776621903
            
        MedicinesTable = MedicinesDAL.GetMedicinesInCategory(idCategory);
        
    }

    private bool IsInRecipes(string id)
    {
        /*    bool exist = false;
            DataSet ds = (new HMO.Service()).GetRecipe(int.Parse(idCustomer));
            int d = (new HMO.Service()).GetRecipe(int.Parse(idCustomer)).Tables[0].Rows.Count;
            DataTable dt = (new HMO.Service()).GetRecipe(int.Parse(idCustomer)).Tables[0];
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (id == dr["MedicineId"].ToString())
                {
                    exist = true;
                    break;
                }

            }
            return exist;*/
        return true;
    }

    private bool IfNeedRecipe(string id)
    {
        bool need = false;
        foreach (DataRow dr in MedicinesTable.Rows)
        {
            if (dr["MedicineId"].ToString() == id)
            {
                need = dr["NeedRecipe"].ToString() == "true";
                break;
            }
        }

        return need;
    }

    private void AddMedicine(string id)
    {
        if (!isExistent(id))
        {
            MedicinesId.Add(id);
            Session["MedicinesId"] = MedicinesId;
            Session["Count"] = MedicinesId.Count;
        }

    }
    protected void LinkButtonAddToBasket_Click(object sender, EventArgs e)
    {

        string id = ((LinkButton)sender).CommandArgument;

        if (Session["CostumerLogedIn"] != null)
        {
            if (!IfNeedRecipe(id))
            {
                AddMedicine(id);
                ((Label)(this.Master.FindControl("LabelBasketStatus"))).Text = MedicinesId.Count.ToString() + " Products in the shopping basket";
            }
            else
            {
                if (IsInRecipes(id))
                {
                    AddMedicine(id);
                    ((Label)(this.Master.FindControl("LabelBasketStatus"))).Text = MedicinesId.Count.ToString() + " Products in the shopping basket";
                }
                else
                {
                    LabelMsg.Text = "This medicine does not appear in your prescription";
                    LabelMsg.Visible = true;
                }

            }

       } 
        else
        {
            LabelMsg.Text = "You must register to receive medication";
            LabelMsg.Visible = true;
        }
        
    }
    private bool isExistent(string id)
    {
        bool medicineExistent = false;
        if (MedicinesId != null)
        {
            foreach (object idm in MedicinesId)
            {
                if (idm.ToString() == id)
                {
                    medicineExistent = true;
                    break;
                }
            }
        }
        return medicineExistent;
    }
    private void Binding(int id)
    {
        MedicinesTable = MedicinesDAL.GetMedicinesInCategory(id);
        DataListCategoryMedicines.DataSource = MedicinesTable;
        DataListCategoryMedicines.DataBind();
    }
    protected void LinkButtonMedicineInfo_Click(object sender, EventArgs e)
    {
        string id = ((LinkButton)sender).CommandArgument;
        Response.Redirect(@"~\Medicines Catalogue\MedicineInfo.aspx?Id="+id);
    }
}
