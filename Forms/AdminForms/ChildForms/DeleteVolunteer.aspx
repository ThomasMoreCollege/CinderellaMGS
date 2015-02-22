<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DeleteVolunteer.aspx.cs" Inherits="Forms_AdminForms_ChildForms_DeleteVolunteer" %>

<asp:Content ID="HeaderTitle" ContentPlaceHolderID="HeaderTitle" Runat="Server">
    <h2>Delete Volunteer</h2>
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" Runat="Server">
    <form id="form1" runat="server">
    <table id="DeleteVolTable"style="width:60%;">
        <tr>
            <th rowspan="10" class="auto-style1">
                <asp:ListBox ID="ListBox1" runat="server" Height="232px" Width="161px" style="font-size: small"></asp:ListBox>
            </th>
            <th class="auto-style2">&nbsp;</th>
            <th class="auto-style4">Current Information</th>
        </tr>
        <tr>
            <td class="auto-style3">First Name:</td>
            <td>
                <asp:Label ID="Label1" runat="server" CssClass="auto-style4" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Last Name:</td>
            <td>
                <asp:Label ID="Label2" runat="server" CssClass="auto-style4" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Address:</td>
            <td>
                <asp:Label ID="Label3" runat="server" CssClass="auto-style4" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">City:</td>
            <td>
                <asp:Label ID="Label4" runat="server" CssClass="auto-style4" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">State:</td>
            <td>
                <asp:Label ID="Label5" runat="server" CssClass="auto-style4" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Zip Code:</td>
            <td>
                <asp:Label ID="Label6" runat="server" CssClass="auto-style4" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Phone:</td>
            <td>
                <asp:Label ID="Label7" runat="server" CssClass="auto-style4" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Email:</td>
            <td>
                <asp:Label ID="Label8" runat="server" CssClass="auto-style4" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style3"></td>
            <td>
                <asp:Button ID="DeleteVoluntFormButton" runat="server" Text="Delete" />
            </td>
        </tr>
    </table>
    </form>
</asp:Content>

<asp:Content ID="Content1" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style1 {
            width: 175px;
        }
        .auto-style2 {
            width: 105px;
            text-align: right;
        }
        .auto-style3 {
            width: 105px;
            font-size: small;
            text-align: right;
        }
        .auto-style4 {
            font-size: small;
        }
    </style>
</asp:Content>


