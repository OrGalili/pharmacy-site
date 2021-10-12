<%@ Page Language="C#" MasterPageFile="~/MedicinesMP.master" AutoEventWireup="true" CodeFile="ShoppingBasket.aspx.cs" Inherits="Shopping_Basket_ShoppingBasket" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 625px; height: 30px" align="center">
        <tr>
            <td style="width: 100px; background-color: white; text-align: right; background-image: url(../Images/Design/b.gif); color: white; height: 20px;" align="right" dir="rtl">
                Your shopping basket:</td>
        </tr>
    </table>
    <br />
    <table align="center">
        <tr>
            <td align="center" colspan="2" dir="rtl" style="text-align: right">
                <asp:Label ID="LabelNoBasket" runat="server" Font-Size="XX-Large" ForeColor="Red"
                    Text="no items in the shopping cart" Visible="False" Width="615px"></asp:Label></td>
        </tr>
        <tr>
            <td align="center" colspan="2" dir="rtl" style="text-align: center">
                <asp:HyperLink ID="HyperLinkGoBack" runat="server" NavigateUrl="~/Medicines Catalogue/MedicinesCatalogue.aspx"
                    Visible="False">Click here to return</asp:HyperLink></td>
        </tr>
        <tr>
            <td align="center" colspan="2" dir="rtl" style="text-align: right">
                <asp:GridView ID="GridViewShoppingBasket" runat="server" Width="690px" OnRowDeleting="GridViewShoppingBasket_RowDeleting" BorderWidth="1px" OnRowUpdating="GridViewShoppingBasket_RowUpdating" OnRowCancelingEdit="GridViewShoppingBasket_RowCancelingEdit" OnRowEditing="GridViewShoppingBasket_RowEditing" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="MedicineName" HeaderText="product name" ReadOnly="True">
                            <HeaderStyle BackColor="#99CC66" ForeColor="White" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Price per unit" DataField="Price" ReadOnly="True" >
                            <ItemStyle ForeColor="Black" />
                            <HeaderStyle BackColor="#99CC66" ForeColor="White" />
                            <ControlStyle ForeColor="Black" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Count" HeaderText="quantity">
                            <HeaderStyle BackColor="#99CC66" ForeColor="White" />
                        </asp:BoundField>
                        <asp:CommandField EditText="update" ShowEditButton="True" CancelText="cancel" UpdateText="update" >
                            <HeaderStyle BackColor="#99CC66" ForeColor="White" />
                            <ItemStyle ForeColor="White" />
                        </asp:CommandField>
                        <asp:BoundField HeaderText="Total price" DataField="TotalPrice" ReadOnly="True" >
                            <ItemStyle ForeColor="Black" />
                            <HeaderStyle BackColor="#99CC66" ForeColor="White" />
                        </asp:BoundField>
                        <asp:CommandField HeaderText="delete" ShowDeleteButton="True" DeleteImageUrl="~/Images/Design/Delete.gif" DeleteText="" ButtonType="Image" >
                            <HeaderStyle BackColor="#99CC66" ForeColor="White" />
                            <ItemStyle ForeColor="White" />
                        </asp:CommandField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td align="center" style="width: 350px; height: 21px; text-align: center">
                            <asp:HyperLink ID="HyperLinkContinueShopping" runat="server" NavigateUrl="~/Medicines Catalogue/MedicinesCatalogue.aspx">continue shopping</asp:HyperLink></td>
            <td align="center" style="width: 350px; height: 21px; text-align: center">
                            <asp:LinkButton ID="LinkButtonCashBox" runat="server" OnClick="LinkButtonCashBox_Click">jackpot</asp:LinkButton></td>
        </tr>
    </table>
</asp:Content>

