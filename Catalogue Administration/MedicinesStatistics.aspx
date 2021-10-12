<%@ Page Language="C#" MasterPageFile="~/MedicinesMP.master" AutoEventWireup="true" CodeFile="MedicinesStatistics.aspx.cs" Inherits="Catalogue_Administration_MedicinesStatistics" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Table ID="TableStatistics" runat="server" Width="600px" GridLines="Both" CellSpacing="0" HorizontalAlign="Center">
        <asp:TableRow ID="title" runat="server">
            <asp:TableCell runat="server">Not recommended to invest</asp:TableCell>
            <asp:TableCell runat="server">Recommended to invest</asp:TableCell>
            <asp:TableCell runat="server">purchase percent</asp:TableCell>
            <asp:TableCell runat="server">category</asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>