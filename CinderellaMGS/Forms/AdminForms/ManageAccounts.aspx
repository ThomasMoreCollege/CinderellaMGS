<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ManageAccounts.aspx.cs" Inherits="Forms_AdminForms_ManageAccounts" %>


<asp:Content ID="HeaderTitle" ContentPlaceHolderID="HeaderTitle" Runat="Server">
    <h2>Account Manager</h2>
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" Runat="Server">
    <table id="AccMngTable" style="width:60%;">
        <tr> 
            <td>
                <asp:Button ID="AddButton" runat="server" Height="31px" Text="Add Account" Width="120px" PostBackUrl="~/Forms/AdminForms/ChildForms/AddAccount.aspx" />
            </td>
            <td class="auto-style2" >Add a new account with specified permissions</td>
        </tr>
        <tr id="middleRow">
            <td class="auto-style3" >
                <asp:Button ID="EditButton" runat="server" Height="31px" Text="Edit Account " Width="120px" PostBackUrl="~/Forms/AdminForms/ChildForms/EditAccount.aspx" />
            </td>
            <td class="auto-style4">Edit an existing accounts username, password, and permissions</td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="RemoveButton" runat="server" Height="31px" Text="Delete Account " Width="120px" PostBackUrl="~/Forms/AdminForms/ChildForms/DeleteAccount.aspx" />
            </td>
            <td class="auto-style2">Delete an account from the system</td>
        </tr>
        
    </table>
</asp:Content>

<asp:Content ID="Content1" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style2
        {
            font-size: small;
        }
    .auto-style3 {
        height: 50px;
    }
    .auto-style4 {
        font-size: small;
        height: 50px;
    }
    </style>
</asp:Content>


