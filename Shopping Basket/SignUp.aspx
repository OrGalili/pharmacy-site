<%@ Page Language="C#" MasterPageFile="~/MedicinesMP.master" AutoEventWireup="true" CodeFile="SignUp.aspx.cs" Inherits="Shopping_Basket_SignUp" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table dir="ltr" width="600" align="center">
        <tr>
            <td colspan="3" style="text-align: center">
                Login to System</td>
        </tr>
        <tr>
            <td colspan="3" style="text-align: center">
                Sign Up:</td>
        </tr>
        <tr>
            <td colspan="3" style="text-align: center">
                Required fields:</td>
            <td>
                 <asp:Label ID="LabelExistUserName" runat="server" ForeColor="Red" Text="The username you entered already exists in the system"
                                Visible="False" Width="500px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: right" width="133">
                alias:</td>
            <td style="width: 133px">
                <asp:TextBox ID="TextBoxUserName" runat="server" Width="133px"></asp:TextBox></td>
            <td dir="ltr" style="text-align: right" width="133">
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorUserName" runat="server" ControlToValidate="TextBoxUserName">*cannot be empty</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 100px; text-align: right">
                password:</td>
            <td style="width: 133px">
                <asp:TextBox TextMode="Password" ID="TextBoxPass" runat="server" Width="133px" ></asp:TextBox></td>
            <td style="width: 100px; text-align: right">
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorPass" runat="server" ControlToValidate="TextBoxPass">*cannot be empty</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 100px; text-align: right">
                Enter your password again:</td>
            <td style="width: 133px">
                <asp:TextBox TextMode="Password" ID="TextBoxPassConfirmation" runat="server" Width="133px"></asp:TextBox></td>
            <td style="width: 100px">
                <asp:CompareValidator ID="CompareValidatorPass" runat="server" ControlToValidate="TextBoxPassConfirmation"
                     ControlToCompare="TextBoxPass">*no match between passwords</asp:CompareValidator></td>
        </tr>
        <tr>
            <td style="width: 100px; height: 21px; text-align: right">
                email:</td>
            <td style="width: 133px; height: 21px">
                <asp:TextBox ID="TextBoxEmail" runat="server" Width="133px"></asp:TextBox></td>
            <td style="width: 100px; height: 21px">
                <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail" runat="server"
                    ControlToValidate="TextBoxEmail" ErrorMessage="Invalid email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic">*</asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" runat="server" ControlToValidate="TextBoxEmail"
                    Display="Dynamic">*email field cannot be empty</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td colspan="3" style="height: 21px; text-align: right">
            </td>
        </tr>
        <tr>
            <td colspan="3" style="height: 21px; text-align: center">
                Not Required Fields:</td>
        </tr>
        <tr>
            <td style="width: 100px; text-align: right">
                first name:</td>
            <td style="width: 133px">
                <asp:TextBox ID="TextBoxFirstName" runat="server" Width="133px"></asp:TextBox></td>
            <td style="width: 100px">
                <asp:RegularExpressionValidator ID="RangeValidatorFirstName" runat="server" ControlToValidate="TextBoxFirstName"
                    ValidationExpression="[A-Za-z]*">*just letters please</asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 100px; text-align: right">
                last name:</td>
            <td style="width: 133px">
                <asp:TextBox ID="TextBoxLastName" runat="server" Width="133px"></asp:TextBox></td>
            <td style="width: 100px">
                 <asp:RegularExpressionValidator ID="RegularExpressionLastName" runat="server" ControlToValidate="TextBoxLastName"
                    ValidationExpression="[A-Za-z]*">*only letters</asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 100px; text-align: right">
                address:</td>
            <td style="width: 133px">
                <asp:TextBox ID="TextBoxAddress" runat="server" Width="133px"></asp:TextBox></td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px; text-align: right">
                phone number:</td>
            <td style="width: 133px">
                <asp:TextBox ID="TextBoxPhoneNumber" runat="server" Width="133px"></asp:TextBox></td>
            <td style="width: 100px">
                <asp:RangeValidator ID="RangeValidatorPhoneNumber" runat="server" ControlToValidate="TextBoxPhoneNumber"
                    MaximumValue="9" MinimumValue="1">*only numbers</asp:RangeValidator></td>
        </tr>
        <tr>
            <td style="width: 100px; text-align: right">
            </td>
            <td style="width: 133px">
                </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td colspan="3" style="text-align: center">
                &nbsp;<table style="width: 500px; text-align: center">
                    <tr>
                        <td style="width: 100px; text-align: right">
                            <asp:HyperLink ID="HyperLinkBack" runat="server" NavigateUrl="~/Medicines Catalogue/MedicinesCatalogue.aspx">home page</asp:HyperLink></td>
                        <td style="width: 100px">
                <asp:Button ID="ButtonSignUp" runat="server" Text="new user" OnClick="ButtonSignUp_Click"/></td>
                        <td style="width: 100px">
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

