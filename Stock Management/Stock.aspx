<%@ Page Language="C#" MasterPageFile="~/MedicinesMP.master" AutoEventWireup="true" CodeFile="Stock.aspx.cs" Inherits="Stock_Mengment_Stock" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="700" align="center">
        <tr>
            <td dir="rtl" style="width: 100px; height: 20px; text-align: center" valign="top">
                <asp:GridView ID="GridViewLowStockMedicines" runat="server" OnRowCancelingEdit="GridViewLowStockMedicines_RowCancelingEdit" OnRowEditing="GridViewLowStockMedicines_RowEditing" OnRowUpdating="GridViewLowStockMedicines_RowUpdating" Width="650px" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="MedicineId" ReadOnly="True" ShowHeader="False" >
                            <ControlStyle Width="0px" />
                            <ItemStyle Width="0px" />
                            <HeaderStyle Width="0px" />
                            <FooterStyle Width="0px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="MedicineName" HeaderText="medicine name" ReadOnly="True" />
                        <asp:BoundField DataField="Stock" HeaderText="number units" ReadOnly="True" />
                        <asp:CommandField EditText="Order stock" HeaderText="add units" ShowEditButton="True" />
                        <asp:BoundField />
                    </Columns>
                </asp:GridView>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center" dir="rtl" style="width: 100px; height: 24px; text-align: center"
                valign="top">
                <asp:HyperLink ID="HyperLinkBack" runat="server" NavigateUrl="~/Catalogue Administration/Administration.aspx"
                    Width="40px">back</asp:HyperLink></td>
        </tr>
        <tr>
            <td align="center" dir="rtl" style="width: 100px; height: 24px; text-align: center"
                valign="top">
                <asp:Label ID="LabelAllOk" runat="server" Font-Size="X-Large" ForeColor="Red" Text="There are no drugs whose inventory has been reduced"
                    Visible="False" Width="569px"></asp:Label></td>
        </tr>
    </table>
</asp:Content>

