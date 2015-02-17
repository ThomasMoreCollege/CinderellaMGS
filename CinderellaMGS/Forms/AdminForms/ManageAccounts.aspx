<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ManageAccounts.aspx.cs" Inherits="Forms_AdminForms_ManageAccounts" %>


<asp:Content ID="HeaderTitle" ContentPlaceHolderID="HeaderTitle" Runat="Server">
    <h2>Account Manager</h2>
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" Runat="Server">
    <form id="form1" runat="server">
    <table id="AccMngTable" style="width:60%;">
        <tr> 
            <td>
                <asp:Button ID="AddButton" runat="server" Height="31px" Text="Add Account" Width="120px" PostBackUrl="~/Forms/AdminForms/ChildForms/AddAccount.aspx" />
            </td>
            <td >Add a new account with specified permissions</td>
        </tr>
        <tr id="middleRow">
            <td >
                <asp:Button ID="EditButton" runat="server" Height="31px" Text="Edit Account " Width="120px" PostBackUrl="~/Forms/AdminForms/ChildForms/EditAccount.aspx" />
            </td>
            <td>&nbsp;</tds
        </tr>
                Edit an existing accounts username, password, and permissions<tr>
            <td>
                <asp:Button ID="RemoveButton" runat="server" Height="31px" Text="Delete Account " Width="120px" PostBackUrl="~/Forms/AdminForms/ChildForms/DeleteAccount.aspx" />
            </td>
            <td>Delete an account from the system</td>
        </tr>
    </table>
    </form>
</asp:Content>

<asp:Content ID="Content1" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style1
        {
            width: 166px;
        }
        .auto-style2
        {
            font-size: small;
        }
    </style>
</asp:Content>


