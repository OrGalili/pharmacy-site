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
using System.Drawing;

public partial class MedicinesMP : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        MakeCategoryList();
        LabelCostumerName.Text = "guest";
        if (Session["CostumerLogedIn"] != null)
        {
            HyperLinkSignUp.Enabled = false;
            Image5.Visible = true;
            Image6.Visible = true;
            HyperLinkShopingBasket.Visible = true;
            LinkButtonLogOut.Visible = true;
            LinkButtonCostumers.Enabled = false;
            HyperLinkAdminstartion.Enabled = false;
            LabelCostumerName.Text = Session["CostumerLogedIn"].ToString();
        }
        else if (Session["AdminLogedIn"] != null)
        {
            HyperLinkSignUp.Enabled = false;
            Image5.Visible = true;
            LinkButtonLogOut.Visible = true;
            LinkButtonCostumers.Enabled = false;
            HyperLinkAdminstartion.Enabled = false;
        }
        int count;
        if (Session["Count"] != null)
        {
            count = int.Parse (Session ["Count"].ToString());
            LabelBasketStatus.Text = count + " products in cart";
        }
        else
            LabelBasketStatus.Text = "cart is empty";  
    }
    private void MakeCategoryList()
    {
        DataTable CategoriesT = MedicineCategoriesDAL.GetAllCategories ();
        if (CategoriesT.Rows.Count == 0)
            ZeroCategories.Visible = true;
        else
        {
            Table ct = new Table();
            ct.Width = 150;
            ct.CellSpacing = 1;
            foreach (DataRow dr in CategoriesT.Rows)
            {
                TableRow r = new TableRow();
                TableCell c = new TableCell();
                c.BackColor = Color.FromName("#99cc33");
                LinkButton NameCategory = new LinkButton();
                NameCategory.Width = System.Web.UI.WebControls.Unit.Percentage(100);
                NameCategory.Text = dr["Name"].ToString();
                NameCategory.CommandArgument = dr["CategoryId"].ToString();
                NameCategory.Click += new EventHandler(NameCategory_Click);
                c.Controls.Add(NameCategory);
                r.Cells.Add(c); 
                ct.Rows.Add(r);
            }
            PanelCategories.Controls.Add(ct);
        }
    }
    protected void NameCategory_Click(object sender, EventArgs e)
    {
        if (Session["AdminLogedIn"] != null)
            Response.Redirect(@"~\Catalogue Administration\Administration.aspx?CategoryId=" + ((LinkButton)sender).CommandArgument);
        else
            Response.Redirect(@"~\Medicines Catalogue\MedicinesCatalogue.aspx?CategoryId=" + ((LinkButton)sender).CommandArgument);
    }
    protected void ImageButtonSearch_Click(object sender, ImageClickEventArgs e)
    {
        string url;
        string findMed = TextBoxMedicineName.Text;
        if (Session["AdminLogedIn"] != null)
            url = @"~\Catalogue Administration\Administration.aspx?findText=" + findMed;
        else
            url = @"~\Medicines Catalogue\MedicinesCatalogue.aspx?findText=" + findMed;
        Response.Redirect(url);
    }
    protected void LinkButtonHomePage_Click(object sender, EventArgs e)
    {
        string url;
        if (Session["AdminLogedIn"] != null)
            url = @"~\Catalogue Administration\Administration.aspx";
        else
            url = @"~\Medicines Catalogue\MedicinesCatalogue.aspx";
        Response.Redirect(url);
    }
    protected void LinkButtonLogin_Click(object sender, EventArgs e)
    {
        Response.Redirect(@"~\Catalogue Administration\Access.aspx?CostumerAccess="+true);
    }
    protected void LinkButtonLogOut_Click(object sender, EventArgs e)
    {
        if (Session["CostumerLogedIn"] != null)
        {
            if (Session["MedicinesId"] != null)
                Session["MedicinesId"] = null;
            if (Session["MedicinesOrdered"] != null)
                Session["MedicinesOrdered"] = null;
            if (Session["MedicinesId"] != null)
                Session["MedicinesId"] = null;
            if (Session["Count"] != null)
                Session["Count"] = null;
            Session["CostumerLogedIn"] = null;
        }
        else
            Session["AdminLogedIn"] = null;
        
        Response.Redirect(@"~\Medicines Catalogue\MedicinesCatalogue.aspx");
    }
    protected void ImageButtonAddCategory_Click(object sender, ImageClickEventArgs e)
    {
        string categoryName = TextBoxNewCategory.Text;
        if (MedicineCategoriesDAL.isExictent(categoryName) != 1)
            MedicineCategoriesDAL.InsertCategorie(categoryName);
    }
}
