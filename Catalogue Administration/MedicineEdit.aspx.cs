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

public partial class Catalogue_Administration_MedicineEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ((Panel)(this.Master.FindControl("PanelAdmin"))).Visible = true;
        if (!IsPostBack)
        {
            DataTable CategoriesTable = MedicineCategoriesDAL.GetAllCategories();
            DropDownListCategory.DataSource = CategoriesTable;
            DropDownListCategory.DataTextField = "Name";
            DropDownListCategory.DataValueField = "CategoryId";
            DropDownListCategory.DataBind();
        }
        Button B = new Button();
        B.Click += new EventHandler(B_Click);
        if (Request.QueryString["MedicineId"] != null)
        {
            int id = int.Parse(Request.QueryString["MedicineId"].ToString());
            if (!IsPostBack)
            {
                DataTable MedicineDetails = MedicinesDAL.GetMedicineDetails(id);
                DataRow Details = MedicineDetails.Rows[0];
                TextBoxMedicineName.Text = Details["MedicineName"].ToString();
                DropDownListCategory.SelectedIndex = int.Parse(Details["Category"].ToString())-1;
                TextBoxDiscription.Text = Details["Discription"].ToString();
                TextBoxStock.Text = Details["Stock"].ToString();
                TextBoxPrice.Text = Details["Price"].ToString();
                TextBoxImageUrl.Text = Details["Image"].ToString();
            }
            B.Text = "edit";
            B.CommandName = id.ToString();
            B.CommandArgument = "update";
        }
        else
        {
            B.Text = "add";
            B.CommandArgument = "extend";
        }
        PlaceHolderButton.Controls.Add(B);
    }
    protected void B_Click(object sender, EventArgs e)
    {
        string medName,discrip,imgUrl;
        int categId, stock, price,medId;
        medName = TextBoxMedicineName.Text;
        discrip = TextBoxDiscription.Text;
        imgUrl = TextBoxImageUrl.Text;
        categId = int.Parse(DropDownListCategory.SelectedValue);
        stock = int.Parse(TextBoxStock.Text.ToString());
        price = int.Parse(TextBoxPrice.Text.ToString());
        if (((Button)sender).CommandArgument.ToString() == "extend")
            MedicinesDAL.InsertNewMedicine(medName, categId, discrip, stock, imgUrl, price);
        else
        {
            medId = int.Parse(((Button)sender).CommandName.ToString());
            MedicinesDAL.UpdateMedicine(medName, categId, discrip, stock, imgUrl, price, medId);
        }
    }
}
