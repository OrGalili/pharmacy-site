<%@ Page Language="C#" MasterPageFile="~/MedicinesMP.master" AutoEventWireup="true" CodeFile="Administration.aspx.cs" Inherits="Catalogue_Administration_Administration" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="500" align="center">
        <tr>
            <td rowspan="2" style="width: 100px" align="right">
                <asp:DataList ID="DataListMedicines" runat="server" CellSpacing="20" RepeatColumns="3" Width="650px">
                    <ItemTemplate>
    <table width="200" border="1">
        <tr>
            <td colspan="2" style="background-color: #99cc66">
                                    <asp:Label ID="LabelMedicineName" runat="server" ForeColor="White" Text='<%# DataBinder.Eval(Container.DataItem,"MedicineName") %>'></asp:Label></td>
        </tr>
        <tr>
            <td colspan="2" style="height: 150px">
                                    <asp:Image ID="ImageMedicine" runat="server" Height="100px" ImageUrl='<%#DataBinder.Eval(Container.DataItem,"Image") %>'
                                        Width="100px" /></td>
        </tr>
        <tr>
            <td style="width: 100px" align="center">
                                                            <asp:LinkButton ID="LinkButtonDelete" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"MedicineId") %>'
                                                                OnClick="LinkButtonDelete_Click" Width="60px">remove</asp:LinkButton></td>
            <td style="width: 100px" align="center">
                                                <asp:LinkButton ID="LinkButtonEdit" runat="server" BorderColor="Silver" BorderWidth="2px"
                                                    Font-Underline="False" ForeColor="White" Style="background-color: #99cc66" Width="70px" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"MedicineId") %>' OnClick="LinkButtonEdit_Click">edit</asp:LinkButton></td>
        </tr>
    </table>
                    </ItemTemplate>
                </asp:DataList></td>
        </tr>
        <tr>
        </tr>
    </table>
</asp:Content>

