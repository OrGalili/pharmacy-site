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

public partial class Catalogue_Administration_Administration : System.Web.UI.Page
{
    DataTable MedicinesTable;
    string findText = "";
    int idCategory = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminLogedIn"] != null)
        {
            ((Panel)(this.Master.FindControl("PanelAdmin"))).Visible = true;

            if (Request.QueryString["findText"] != null)
                findText = Request.QueryString["findText"].ToString();

            if (Request.QueryString["CategoryId"] != null)
            {
                idCategory = int.Parse(Request.QueryString["CategoryId"]);
                Binding(idCategory);
            }

            else if (findText != "")
            {
                MedicinesTable = MedicinesDAL.FindMedicines(findText);
                DataListMedicines.DataSource = MedicinesTable;
                DataListMedicines.DataBind();
            }
            else if (!this.IsPostBack)
                Binding(idCategory);
        }
        else
        {
            Response.Redirect(@"~\Catalogue Administration\Access.aspx");
        }
    }
    protected void LinkButtonEdit_Click(object sender, EventArgs e)
    {
        Response.Redirect("MedicineEdit.aspx?MedicineId="+((LinkButton)sender).CommandArgument);
    }
    protected void LinkButtonDelete_Click(object sender, EventArgs e)
    {
        int id = int.Parse(((LinkButton)sender).CommandArgument);
        MedicinesDAL.DeleteMedicine(id);
        Binding(idCategory);
    }
    private void Binding(int id)
    {
        MedicinesTable = MedicinesDAL.GetMedicinesInCategory(id);
        DataListMedicines.DataSource = MedicinesTable;
        DataListMedicines.DataBind();
    }
}
