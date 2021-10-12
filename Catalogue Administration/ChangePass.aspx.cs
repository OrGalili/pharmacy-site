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

public partial class Catalogue_Administration_AdminChangePass : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["Costumer"] != null)
        {
            LabelAccessType.Text = "client name";
            ButtonConform.CommandArgument = "client";
        }
        else
        {
            LabelAccessType.Text = "admin name";
            ButtonConform.CommandArgument = "admin";
        }
    }
    protected void ButtonConform_Click(object sender, EventArgs e)
    {
        if (((Button)sender).CommandArgument == "admin")
        {
            DataTable AdminsTable = AdministratorsDAL.GetAdminsList();
            foreach (DataRow dr in AdminsTable.Rows)
            {
                if (TextBoxUserName.Text == dr["AccessName"].ToString() && TextBoxPass.Text == dr["Password"].ToString())
                {
                    AdministratorsDAL.ChangePassword(TextBoxNewPass.Text, TextBoxUserName.Text);
                    Response.Redirect(@"~\Medicines Catalogue\MedicinesCatalogue.aspx");
                }
            }
        }
        
        else if(((Button)sender).CommandArgument == "client")
        {
            DataTable UsersTable = CostumersDAL.GetCostumersList();
            foreach (DataRow dr in UsersTable.Rows)
            {
                if (TextBoxUserName.Text == dr["UserName"].ToString() && TextBoxPass.Text == dr["Password"].ToString())
                {
                    CostumersDAL.ChangePassword(TextBoxUserName.Text, TextBoxNewPass.Text);
                    Response.Redirect(@"~\Medicines Catalogue\MedicinesCatalogue.aspx");
                }
            }
        }
        LabelWrongPass.Visible = true;
    }
}
