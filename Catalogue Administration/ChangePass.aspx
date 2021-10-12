<%@ Page Language="C#" MasterPageFile="~/MedicinesMP.master" AutoEventWireup="true" CodeFile="ChangePass.aspx.cs" Inherits="Catalogue_Administration_AdminChangePass" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <table align="center">
        <tr>
            <td style="width: 100px">
            </td>
            <td style="width: 100px" dir="rtl">
                <asp:TextBox ID="TextBoxUserName" runat="server"></asp:TextBox></td>
            <td dir="rtl" style="width: 100px; text-align: right">
                <asp:Label ID="LabelAccessType" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td style="width: 100px" dir="rtl">
                <asp:TextBox ID="TextBoxPass" runat="server" TextMode="Password"></asp:TextBox></td>
            <td dir="rtl" style="width: 100px; text-align: right">
                current password:</td>
        </tr>
        <tr>
            <td style="width: 100px; text-align: center">
            </td>
            <td style="width: 100px; text-align: center" dir="rtl">
                <asp:TextBox ID="TextBoxNewPass" runat="server" TextMode="Password"></asp:TextBox></td>
            <td dir="rtl" style="width: 100px; text-align: right">
                new password:</td>
        </tr>
        <tr>
            <td align="center" colspan="1">
            </td>
            <td align="center" colspan="3">
                <table>
                    <tr>
                        <td style="width: 100px; text-align: center;">
                            <asp:HyperLink ID="HyperLinkCancel" runat="server" NavigateUrl="~/Catalogue Administration/Access.aspx"
                                Width="50px">cancel</asp:HyperLink>
                        </td>
                        <td style="width: 100px">
                            <asp:Button ID="ButtonConform" runat="server" OnClick="ButtonConform_Click" Text="OK" /></td>
                    </tr>
                </table>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center" colspan="4" style="text-align: right">
                <asp:Label ID="LabelWrongPass" runat="server" Text="The password or username you entered is not correct"
                    Visible="False"></asp:Label></td>
        </tr>
    </table>
</asp:Content>

