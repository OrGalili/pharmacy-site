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

public partial class Shopping_Basket_SignUp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ButtonSignUp_Click(object sender, EventArgs e)
    {
        string firstName, lastName, address, phoneNumber, userName, pass, email;
        firstName = TextBoxFirstName.Text;
        lastName = TextBoxLastName.Text;
        address = TextBoxAddress.Text;
        phoneNumber = TextBoxPhoneNumber.Text;
        userName = TextBoxUserName.Text;
        pass = TextBoxPass.Text;
        email = TextBoxEmail.Text;
        if (CostumersDAL.isExictent(userName) == 1)
            LabelExistUserName.Visible = true;
        else
        {
            CostumersDAL.InsertNewCostumer(firstName, lastName, address, phoneNumber, userName, pass, email);
            Response.Redirect(@"~\Medicines Catalogue\MedicinesCatalogue.aspx");
        }
    }
    protected void LinkButtonBack_Click(object sender, EventArgs e)
    {
        string url;
        if (Session["AdminLogedIn"] != null)
            url = @"~\Catalogue Administration\Administration.aspx";
        else
            url = @"~\Medicines Catalogue\MedicinesCatalogue.aspx";
        Response.Redirect(url);
    }
}
