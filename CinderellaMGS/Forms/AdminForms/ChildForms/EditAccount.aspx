<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EditAccount.aspx.cs" Inherits="Forms_AdminForms_ChildForms_EditAccount" %>

<asp:Content ID="HeaderTitle" ContentPlaceHolderID="HeaderTitle" Runat="Server">
    <h2>Edit Account</h2>
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" Runat="Server">
    <form id="form1" runat="server">
        
        <table id="EditAcctTable" style="width:85%;">
            <tr>
                <th rowspan="4" class="auto-style5"><asp:ListBox ID="ListBox1" runat="server" Height="184px" Width="161px"></asp:ListBox></th>
                <th class="auto-style8"></th>
                <th class="auto-style3">Current Settings:</th>
                <th class="auto-style6">New Settings:</th>
            </tr>
            <tr>
                <td class="auto-style1">Username:</td>
                <td class="auto-style4">
                    <asp:Label ID="Label1" runat="server" Text="Label" CssClass="auto-style2"></asp:Label>
                </td>
                <td class="auto-style7">
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="auto-style2"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Password:</td>
                <td class="auto-style4">
                    <asp:Label ID="Label2" runat="server" Text="Label" CssClass="auto-style2"></asp:Label>
                </td>
                <td class="auto-style7">
                    <asp:TextBox ID="TextBox2" runat="server" CssClass="auto-style2"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Current Permissions: </td>
                <td class="auto-style4">
                    <asp:ListBox ID="ListBox2" runat="server" Width="161px" CssClass="auto-style2"></asp:ListBox>
                </td>
                <td class="auto-style7">
                    <asp:CheckBoxList ID="CheckBoxList1" runat="server" CssClass="auto-style2">
                    </asp:CheckBoxList>
                </td>
            </tr>
        </table>
    </form>
</asp:Content>

<asp:Content ID="Content1" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style1 {
            font-size: small;
            width: 105px;
            text-align: right;
        }
        .auto-style2 {
            font-size: small;
        }
        .auto-style3 {
            font-size: small;
            width: 225px;
        }
        .auto-style4 {
            width: 225px;
        }
        .auto-style5 {
            width: 157px;
        }
        .auto-style6 {
            font-size: small;
            width: 253px;
        }
        .auto-style7 {
            width: 253px;
        }
        .auto-style8 {
            width: 105px;
        }
    </style>
</asp:Content>


