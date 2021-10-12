<%@ Page Language="C#" MasterPageFile="~/MedicinesMP.master" AutoEventWireup="true" CodeFile="MedicineEdit.aspx.cs" Inherits="Catalogue_Administration_MedicineEdit" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    &nbsp;<table dir="rtl" width="600" align="center">
        <tr>
                    <td style="height: 30px" width="100" align="right">
                        medicine name:</td>
                    <td style="height: 30px" align="right" width="500">
                        <asp:TextBox ID="TextBoxMedicineName" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
                    <td style="height: 30px" align="right" width="100">
                        category:</td>
                    <td style="height: 30px" align="right" width="500">
                        <asp:DropDownList ID="DropDownListCategory" runat="server">
                        </asp:DropDownList></td>
        </tr>
        <tr>
                    <td style="height: 30px" align="right" width="100">
                        stok:</td>
                    <td style="height: 30px" align="right" width="500">
                        <asp:TextBox ID="TextBoxStock" runat="server" ></asp:TextBox></td>
        </tr>
        <tr>
                    <td style="height: 30px;" align="right" width="100">
                        cost:</td>
                    <td style="height: 30px" align="right" width="500">
                        <asp:TextBox ID="TextBoxPrice" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
                    <td align="right" width="100">
                        image location:</td>
                    <td align="right" width="500" dir="ltr">
                        <asp:TextBox ID="TextBoxImageUrl" runat="server" Width="350px"></asp:TextBox></td>
        </tr>
        <tr>
            <td align="right" valign="top" width="100">
                        description:</td>
            <td align="right" width="500">
                        <asp:TextBox ID="TextBoxDiscription" runat="server" Height="214px" TextMode="MultiLine" Width="450px"></asp:TextBox></td>
        </tr>
        <tr>
                    <td style="height: 21px;" width="100">
                        <asp:HyperLink ID="HyperLinkBack" runat="server" NavigateUrl="~/Catalogue Administration/Administration.aspx"
                            Width="38px">back</asp:HyperLink></td>
                    <td colspan="1" style="height: 21px;" width="500">
                <asp:PlaceHolder ID="PlaceHolderButton" runat="server"></asp:PlaceHolder>
                    </td>
        </tr>
            </table>
</asp:Content>

