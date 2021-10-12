<%@ Page Language="C#" MasterPageFile="~/MedicinesMP.master" AutoEventWireup="true" CodeFile="MedicinesCatalogue.aspx.cs" Inherits="Medicines_Catalogue_MedicinesCatalogue" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    &nbsp;<table align="center">
        <tr>
            <td dir="rtl" height="20" style="text-align: right">
                <asp:Label ID="LabelMsg" runat="server" Font-Size="XX-Large" ForeColor="Red"
                    Visible="False"></asp:Label></td>
        </tr>
        <tr>
            <td style="height: 290px" >
    <asp:DataList ID="DataListCategoryMedicines" runat="server" RepeatColumns="3" CellSpacing="20">
        <ItemTemplate>
            <table  border="1" bordercolor="#cccccc">
                <tr>
                    <td align="center" style=" background-color: #99cc66" bordercolor="#ffffff">
                        <asp:Label ID="LabelMedicineName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"MedicineName") %>' ForeColor="White"></asp:Label></td>
                </tr>
                <tr>
                    <td align="right"  valign="middle" bordercolor="#ffffff" dir="rtl">
                        <asp:Image ID="ImageMedicine" runat="server" ImageUrl='<%#DataBinder.Eval(Container.DataItem,"Image") %>' Height="100px" Width="100px" /></td>
                </tr>
                <tr>
                    <td  bordercolor="#ffffff" style="height: 50px">
                        <table>
                            <tr>
                                <td  align="center" bordercolor="#ffffff" style="width: 77px">
                                    <asp:LinkButton ID="LinkButtonAddToBasket" runat="server"  BorderColor="Silver" BorderWidth="2px" Font-Underline="False" ForeColor="White" Width="100px" Height="19px" OnClick="LinkButtonAddToBasket_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"MedicineId") %>' >add to basket</asp:LinkButton></td>
                                <td align ="center" style="width: 57px" >
                                    <asp:LinkButton ID="LinkButtonMedicineInfo" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"MedicineId") %>'
                                        OnClick="LinkButtonMedicineInfo_Click">more info</asp:LinkButton></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList></td>
        </tr>
    </table>
</asp:Content>

