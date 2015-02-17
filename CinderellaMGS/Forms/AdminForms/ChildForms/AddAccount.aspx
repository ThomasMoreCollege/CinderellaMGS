<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddAccount.aspx.cs" Inherits="Forms_AdminForms_ChildForms_AddAccount" %>


<asp:Content ID="HeaderTitle" ContentPlaceHolderID="HeaderTitle" Runat="Server">
    <h2>Add Account</h2>
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" Runat="Server">
    <form id="form1" runat="server">
    <table id="AddAcctTable" style="width:36%;">
        <tr>
            <td class="auto-style1">New Username:</td>
            <td>
                <asp:TextBox ID="NewUserNameTextBox" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Password:</td>
            <td>
                <asp:TextBox ID="PasswordTextBox" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Confirm Password:</td>
            <td>
                <asp:TextBox ID="ConfirmPasswordTextBox" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Permissions:</td>
            <td>
                <asp:CheckBoxList ID="RolesCheckBoxList" runat="server" style="font-size: small">
                </asp:CheckBoxList>
            </td>
        </tr>
        <tr>
            <td class="auto-style1"></td>
            <td>
                <asp:Button ID="CreateAccButton" runat="server" Text="Create Account" Width="116px" />
            </td>
        </tr>
    </table>
    </form>
</asp:Content>

<asp:Content ID="Content1" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style1 {
            width: 128px;
            text-align: right;
            font-size: small;
        }
    </style>
</asp:Content>


