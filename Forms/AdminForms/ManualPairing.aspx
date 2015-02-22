<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ManualPairing.aspx.cs" Inherits="Forms_AdminForms_ManualPairing" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeaderTitle" Runat="Server">
    <h2>Manual Pairing</h2>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
    <form id="form1" runat="server">
        <table id="ManualPairTable" border="1">
            <tr>
                <th>Cinderellas</th>
                <th>Godmothers</th>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="CinderellaSearchTextBox" runat="server"></asp:TextBox>&nbsp;<asp:Button ID="CinderellaSearchButton" runat="server" Text="Search By: " />&nbsp;<asp:DropDownList ID="CinderellaSearchDropDown" runat="server">
                        <asp:ListItem>First Name</asp:ListItem>
                        <asp:ListItem>Last Name</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:TextBox ID="GodmotherSearchTextBox" runat="server"></asp:TextBox>&nbsp;<asp:Button ID="GodmotherSearchButton" runat="server" Text="Search By:" />&nbsp;<asp:DropDownList ID="GodmotherSearchDropDown" runat="server">
                        <asp:ListItem>First Name</asp:ListItem>
                        <asp:ListItem>Last Name</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="CinderellaStatusButton" runat="server" Text="Change Status" />&nbsp;<asp:DropDownList ID="CinderellaStatusDropDown" runat="server">
                        <asp:ListItem>ALL STATUSES</asp:ListItem>
                    </asp:DropDownList>
                </td>
                 <td>
                    <asp:Button ID="GodmotherStatusButton" runat="server" Text="Change Status" />&nbsp;<asp:DropDownList ID="GodmotherStatusDropDown" runat="server">
                        <asp:ListItem>ALL STATUSES</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:ListBox ID="CinderellaListBox" runat="server" Height="200px" Width="150px"></asp:ListBox>
                </td>
                <td>
                    <asp:ListBox ID="GodmotherListBox" runat="server" Height="200px" Width="150px"></asp:ListBox>
                </td>
            </tr>
            <tr>
                <td colspan="2"><asp:Button ID="Match" runat="server" Text="Match!" /></td>
            </tr>
        </table>
    </form>
</asp:Content>



<asp:Content ID="Content4" runat="server" contentplaceholderid="head">
    <style type="text/css">
        #form1 {
            height: 445px;
        }
    </style>
</asp:Content>




