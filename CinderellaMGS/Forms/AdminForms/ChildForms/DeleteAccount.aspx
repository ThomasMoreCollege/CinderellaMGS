<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DeleteAccount.aspx.cs" Inherits="Forms_AdminForms_ChildForms_DeleteAccount" %>

<asp:Content ID="HeaderTitle" ContentPlaceHolderID="HeaderTitle" Runat="Server">
    <h2>Delete Account</h2>
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" Runat="Server">
        
        <table id="DeleteAcctTable" style="width:70%;">
            <tr>
                <th rowspan="4" class="auto-style3"><asp:ListBox ID="ExistingAcctsListBox" runat="server" Height="167px" Width="145px" DataSourceID="AccountsToBeDeletedSqlDataSource" DataTextField="Username" DataValueField="Username" AutoPostBack="True" OnSelectedIndexChanged="ExistingAcctsListBox_SelectedIndexChanged"></asp:ListBox>
                    <asp:SqlDataSource ID="AccountsToBeDeletedSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [Username] FROM [Accounts]"></asp:SqlDataSource>
                </th>
                <th class="auto-style6"></th>
                <th class="auto-style7">Account Information:</th>
            </tr>
            <tr>
                <td class="auto-style8">Username:</td>
                <td class="auto-style4">
                    <asp:Label ID="UsernameLabel" runat="server" Text="--" style="text-align: left"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style8">Account Type:</td>
                <td class="auto-style4">
                    <asp:Label ID="AccountTypeLabel" runat="server" Text="--" style="text-align: left"></asp:Label>
                </td>
            </tr>
            <tr>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ExistingAcctsListBox" ErrorMessage="Please select an account to delete." ForeColor="Red" style="font-size: small"></asp:RequiredFieldValidator>
                </td>
                <td></td>
                <td><asp:Button ID="DeleteButton" runat="server" Text="Delete Account" OnClick="DeleteButton_Click" /></td>
            </tr>
        </table>

</asp:Content>

<asp:Content ID="Content1" runat="server" contentplaceholderid="head">
    <style type="text/css">

        .auto-style3 {
            width: 176px;
        }
        .auto-style4 {
            width: 164px;
            text-align: left;
        }
        .auto-style6 {
            width: 107px;
        }
        .auto-style7 {
            width: 164px;
        }
        .auto-style8
        {
            width: 107px;
            text-align: right;
        }
        </style>
</asp:Content>


