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

public partial class Catalogue_Administration_AdminAccess : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["CostumerAccess"] != null)
        {
            LinkButtonChangePass.CommandArgument = "client";
            LabelAccessType.Text = "client name:";
        }
        else
            LabelAccessType.Text = "admin name:";

    }
    protected void ButtonConform_Click(object sender, EventArgs e)
    {
        if (LabelAccessType.Text == "admin name:")
        {
            DataTable AdminsTable = AdministratorsDAL.GetAdminsList();
            foreach (DataRow dr in AdminsTable.Rows)
            {
                if (TextBoxName.Text == dr["AccessName"].ToString() && TextBoxPass.Text == dr["Password"].ToString())
                {
                    Session["AdminLogedIn"] = TextBoxName.Text;
                    Response.Redirect("Administration.aspx");
                }
            }
        }
        else if (LabelAccessType.Text == "client name:")
        {
            DataTable UsersTable = CostumersDAL.GetCostumersList();
            foreach (DataRow dr in UsersTable.Rows)
            {
                if (TextBoxName.Text == dr["UserName"].ToString() && TextBoxPass.Text == dr["Password"].ToString())
                {
                    Session["CostumerLogedIn"] = TextBoxName.Text; 
                    Response.Redirect(@"~\Medicines Catalogue\MedicinesCatalogue.aspx?CostumerLogedIn" + TextBoxName.Text);
                }
            }
        }
        LabelWrongPass.Visible = true;
    }
    protected void LinkButtonChangePass_Click(object sender, EventArgs e)
    {
        string url = @"~\Catalogue Administration\ChangePass.aspx";
        if (((LinkButton)sender).CommandArgument == "client")
            Response.Redirect(url + "?Costumer=" + true);
        Response.Redirect(url);
    }
}
