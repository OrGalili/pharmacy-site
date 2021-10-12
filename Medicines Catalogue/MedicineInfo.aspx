<%@ Page Language="C#" MasterPageFile="~/MedicinesMP.master" AutoEventWireup="true" CodeFile="MedicineInfo.aspx.cs" Inherits="Medicines_Catalogue_MedicineInfo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table height="200" width="700" align="center">
        <tr>
            <td align="center" colspan="2" dir="rtl" valign="top">
                <asp:Label ID="LabelMedicineName" runat="server" Font-Bold="True" Font-Italic="False"
                    Font-Overline="False" Font-Size="20pt" Font-Underline="True" ForeColor="Honeydew"></asp:Label></td>
        </tr>
        <tr>
            <td align="center" colspan="2" dir="rtl" valign="top">
                <asp:TextBox ID="TextBoxMedicineInfo" runat="server" Height="400px" ReadOnly="True"
                    TextMode="MultiLine" Width="650px" BackColor="#00C0C0"></asp:TextBox></td>
        </tr>
        <tr>
            <td align="center" colspan="2" dir="rtl" valign="top">
                <asp:HyperLink ID="HyperLinkBack" runat="server" NavigateUrl="~/Medicines Catalogue/MedicinesCatalogue.aspx"
                    Width="40px">back</asp:HyperLink></td>
        </tr>
    </table>
</asp:Content>

