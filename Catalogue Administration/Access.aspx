<%@ Page Language="C#" MasterPageFile="~/MedicinesMP.master" AutoEventWireup="true" CodeFile="Access.aspx.cs" Inherits="Catalogue_Administration_AdminAccess" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <table align="center">
            <tr>
                <td style="width: 100px">
                </td>
                <td style="width: 100px" dir="rtl">
                    <asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox></td>
                <td dir="rtl" style="width: 100px; text-align: right">
                    <asp:Label ID="LabelAccessType" runat="server" Width="70px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 100px">
                </td>
                <td style="width: 100px" dir="rtl">
                    <asp:TextBox ID="TextBoxPass" runat="server" TextMode="Password"></asp:TextBox></td>
                <td dir="rtl" style="width: 100px; text-align: right">
                    password:</td>
            </tr>
            <tr>
                <td style="width: 100px">
                </td>
                <td style="width: 100px; text-align: center;">
                    <asp:Button ID="ButtonConform" runat="server" Text="login" OnClick="ButtonConform_Click" /></td>
                <td style="width: 100px; text-align: right;" align="left" dir="ltr">
                    <asp:LinkButton ID="LinkButtonChangePass" runat="server" OnClick="LinkButtonChangePass_Click">change password</asp:LinkButton></td>
            </tr>
            <tr>
                <td align="center" colspan="3" style="height: 20px; text-align: right">
                    <asp:Label ID="LabelWrongPass" runat="server" Text="The password or username you entered is not correct" Visible="False"></asp:Label></td>
            </tr>
        </table>
</asp:Content>

