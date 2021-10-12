<%@ Page Language="C#" MasterPageFile="~/MedicinesMP.master" AutoEventWireup="true" CodeFile="CashBox.aspx.cs" Inherits="Shopping_Basket_CashBox" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="center" dir="rtl" width="400">
        <tr>
            <td align="right" style="width: 100px; height: 20px; text-align: right">
                user name:</td>
            <td align="right" style="width: 100px; height: 20px">
                <asp:Label ID="LabelUserName" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td align="right" style="width: 100px; height: 20px">
                email:</td>
            <td align="right" style="width: 100px; height: 20px">
                <asp:Label ID="LabelEmail" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td align="right" style="width: 100px; height: 20px">
                first name:</td>
            <td align="right" style="width: 100px; height: 20px">
                <asp:Label ID="LabelFirstName" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td align="right" style="width: 100px">
                last name:</td>
            <td align="right" style="width: 100px">
                <asp:Label ID="LabelLastName" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td align="right" style="width: 100px">
            </td>
            <td align="right" style="width: 100px">
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 100px; height: 20px">
            </td>
            <td align="right" style="width: 100px; height: 20px">
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 100px">
            </td>
            <td align="right" style="width: 100px">
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 100px">
            </td>
            <td align="right" style="width: 100px">
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 100px; color: blue">
                total payment:</td>
            <td align="right" style="width: 100px">
                <asp:Label ID="LabelTotalPrice" runat="server" ForeColor="Blue" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td align="right" style="width: 100px; color: blue">
            </td>
            <td align="right" style="width: 100px">
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 100px; color: blue">
                <asp:Button ID="ButtonOrder" runat="server" OnClick="ButtonOrder_Click" Text="order" /></td>
            <td align="right" style="width: 100px">
                <asp:HyperLink ID="HyperLinkBack" runat="server" NavigateUrl="~/Shopping Basket/ShoppingBasket.aspx">return to shopping cart</asp:HyperLink></td>
        </tr>
    </table>
</asp:Content>

