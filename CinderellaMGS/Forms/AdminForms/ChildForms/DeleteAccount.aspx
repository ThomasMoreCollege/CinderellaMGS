<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DeleteAccount.aspx.cs" Inherits="Forms_AdminForms_ChildForms_DeleteAccount" %>

<asp:Content ID="HeaderTitle" ContentPlaceHolderID="HeaderTitle" Runat="Server">
    <h2>Delete Account</h2>
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" Runat="Server">

    <form id="form1" runat="server">
        
        <table id="DeleteAcctTable" style="width:60%;">
            <tr>
                <th rowspan="3" class="auto-style3"><asp:ListBox ID="ExistingAcctsListBox" runat="server" Height="184px" Width="161px" DataSourceID="AccountsToBeDeletedSqlDataSource" DataTextField="Username" DataValueField="Username"></asp:ListBox>
                    <asp:SqlDataSource ID="AccountsToBeDeletedSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [Username] FROM [Accounts]"></asp:SqlDataSource>
                </th>
                <th class="auto-style6"></th>
                <th class="auto-style7">Current Settings:</th>
            </tr>
            <tr>
                <td class="auto-style5">Username:</td>
                <td class="auto-style4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5">Account Type:</td>
                <td class="auto-style4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ExistingAcctsListBox" ErrorMessage="Please select an account to delete." ForeColor="Red" style="font-size: small"></asp:RequiredFieldValidator>
                </td>
                <td></td>
                <td><asp:Button ID="DeleteButton" runat="server" Text="Delete Account" OnClick="DeleteButton_Click" /></td>
            </tr>
        </table>

        
    </form>

</asp:Content>

<asp:Content ID="Content1" runat="server" contentplaceholderid="head">
    <style type="text/css">

        .auto-style3 {
            width: 176px;
        }
        .auto-style4 {
            width: 164px;
            text-align: center;
        }
        .auto-style5 {
            font-size: small;
            width: 107px;
            text-align: right;
        }
        .auto-style6 {
            width: 107px;
        }
        .auto-style7 {
            font-size: small;
            width: 164px;
        }
        </style>
</asp:Content>


