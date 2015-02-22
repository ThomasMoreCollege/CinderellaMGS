<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DeleteAccount.aspx.cs" Inherits="Forms_AdminForms_ChildForms_DeleteAccount" %>

<asp:Content ID="HeaderTitle" ContentPlaceHolderID="HeaderTitle" Runat="Server">
    <h2>Delete Account</h2>
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" Runat="Server">

    <form id="form1" runat="server">
        
        <table id="DeleteAcctTable" style="width:60%;">
            <tr>
                <th rowspan="4" class="auto-style3"><asp:ListBox ID="ListBox1" runat="server" Height="184px" Width="161px"></asp:ListBox></th>
                <th class="auto-style6"></th>
                <th class="auto-style7">Current Settings:</th>
            </tr>
            <tr>
                <td class="auto-style5">Username:</td>
                <td class="auto-style4">
                    <asp:Label ID="Label1" runat="server" Text="Label" CssClass="auto-style2"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style5">Password:</td>
                <td class="auto-style4">
                    <asp:Label ID="Label2" runat="server" Text="Label" CssClass="auto-style2"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style5">Current Permissions: </td>
                <td class="auto-style4">
                    <asp:ListBox ID="ListBox2" runat="server" Width="161px" CssClass="auto-style2"></asp:ListBox>
                </td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td><asp:Button ID="DeleteButton" runat="server" Text="Delete Account" /></td>
            </tr>
        </table>

        
    </form>

</asp:Content>

<asp:Content ID="Content1" runat="server" contentplaceholderid="head">
    <style type="text/css">

        .auto-style2 {
            font-size: small;
        }
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


