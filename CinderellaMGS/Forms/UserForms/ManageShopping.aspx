<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ManageShopping.aspx.cs" Inherits="Forms_UserForms_ManageShopping" %>

<asp:Content ID="HeaderTitle" ContentPlaceHolderID="HeaderTitle" Runat="Server">
    <h2>Manage Shopping</h2>
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" Runat="Server">
        <table style="width:100%;">
            <tr>
                <td class="auto-style2"><strong>Paired Automatically</strong></td>
                <td>&nbsp;</td>
                <td><strong>Currently Shopping</strong></td>
            </tr>
            <tr>
                <td rowspan="2" class="auto-style2">
                    <asp:ListBox ID="AutomattedListBox" runat="server" Height="249px" Width="207px"></asp:ListBox>
                </td>
                <td class="auto-style1">
                    <asp:Button ID="GoShoppingButton" runat="server" Text="Go Shopping" />
                </td>
                <td rowspan="2">
                    <asp:ListBox ID="AutomattedShoppingListBox" runat="server" Height="248px" Width="207px"></asp:ListBox>
                </td>
            </tr>
            <tr>

                <td class="auto-style1">
                    <asp:Button ID="UndoButton" runat="server" Text="Undo" />
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2"><strong>Paired Manually</strong> </td>
                <td>&nbsp;</td>
                <td><strong>Currenly Shopping</strong></td>
            </tr>
            <tr>
                <td rowspan="2" class="auto-style2">
                    <asp:ListBox ID="ManuallyPairedListBox" runat="server" Height="249px" Width="207px"></asp:ListBox>
                </td>
                <td class="auto-style1">
                    <asp:Button ID="GoShoppingButton2" runat="server" Text="Go Shopping" />
                </td>
                <td rowspan="2">
                    <asp:ListBox ID="ManuallyPairedShoppingListBox" runat="server" Height="248px" Width="207px"></asp:ListBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Button ID="UndoButton2" runat="server" Text="Undo" />
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>

</asp:Content>

<asp:Content ID="Content1" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style1
        {
            text-align: center;
        }
        .auto-style2
        {
            width: 166px;
        }
    </style>
</asp:Content>


