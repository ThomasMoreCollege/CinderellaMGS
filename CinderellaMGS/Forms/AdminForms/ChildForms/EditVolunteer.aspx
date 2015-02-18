<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EditVolunteer.aspx.cs" Inherits="Forms_AdminForms_ChildForms_EditVolunteer" %>

<asp:Content ID="HeaderTitle" ContentPlaceHolderID="HeaderTitle" Runat="Server">
    <h2>Edit Volunteer</h2>
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" Runat="Server">
    <form id="form1" runat="server">
        
        <table id="EditVolunTable" style="width:85%;">
            <tr>
                <th rowspan="9" class="auto-style5"><asp:ListBox ID="ListBox1" runat="server" Height="184px" Width="161px" style="font-size: small"></asp:ListBox></th>
                <th class="auto-style11"></th>
                <th class="auto-style4">Current Information:</th>
                <th class="auto-style3">New Information:</th>
            </tr>
            <tr>
                <td class="auto-style9">First Name:</td>
                <td class="auto-style4">
                    <asp:Label ID="Label1" runat="server" Text="Label" CssClass="auto-style2"></asp:Label>
                </td>
                <td class="auto-style7">
                    <asp:TextBox ID="TextBox9" runat="server" CssClass="auto-style2"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style9">Last Name:</td>
                <td class="auto-style4">
                    <asp:Label ID="Label2" runat="server" Text="Label" CssClass="auto-style2"></asp:Label>
                </td>
                <td class="auto-style7">
                    <asp:TextBox ID="TextBox8" runat="server" CssClass="auto-style2"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style9">Address: </td>
                <td class="auto-style4">
                    <asp:Label ID="Label3" runat="server" CssClass="auto-style3" Text="Label"></asp:Label>
                </td>
                <td class="auto-style7">
                    <asp:TextBox ID="TextBox7" runat="server" CssClass="auto-style2"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style10">City: </td>
                <td class="auto-style8">
                    <asp:Label ID="Label4" runat="server" CssClass="auto-style3" Text="Label"></asp:Label>
                </td>
                <td class="auto-style7">
                    <asp:TextBox ID="TextBox6" runat="server" CssClass="auto-style2"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style9">State: </td>
                <td class="auto-style6">
                    <asp:Label ID="Label5" runat="server" CssClass="auto-style3" Text="Label"></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="TextBox5" runat="server" CssClass="auto-style2"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style9">Zip Code: </td>
                <td class="auto-style4">
                    <asp:Label ID="Label6" runat="server" CssClass="auto-style3" Text="Label"></asp:Label>
                </td>
                <td class="auto-style7">
                    <asp:TextBox ID="TextBox4" runat="server" CssClass="auto-style2"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style9">Phone: </td>
                <td class="auto-style4">
                    <asp:Label ID="Label7" runat="server" CssClass="auto-style3" Text="Label"></asp:Label>
                </td>
                <td class="auto-style7">
                    <asp:TextBox ID="TextBox3" runat="server" CssClass="auto-style2"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style9">Email: </td>
                <td class="auto-style4">
                    <asp:Label ID="Label8" runat="server" style="font-size: small" Text="Label"></asp:Label>
                </td>
                <td class="auto-style7">
                    <asp:TextBox ID="TextBox2" runat="server" CssClass="auto-style2"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style9"></td>
                <td class="auto-style4">
                </td>
                <td class="auto-style7">
                    <asp:Button ID="EditVolunterFormButton" runat="server" Text="Edit" />
                </td>
            </tr>
        </table>
    </form>
</asp:Content>

<asp:Content ID="Content1" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style1 {
            height: 32px;
        }
        .auto-style2 {
            font-size: small;
        }
        .auto-style3 {
            font-size: small;
        }
        .auto-style4 {
            font-size: small;
            width: 176px;
        }
        .auto-style5 {
            height: 32px;
            width: 184px;
        }
        .auto-style6 {
            height: 32px;
            width: 176px;
        }
        .auto-style7 {
            height: 33px;
            font-size: small;
        }
        .auto-style8 {
            font-size: small;
            width: 176px;
            height: 33px;
        }
        .auto-style9 {
            font-size: small;
            text-align: right;
            width: 96px;
        }
        .auto-style10 {
            height: 33px;
            font-size: small;
            text-align: right;
            width: 96px;
        }
        .auto-style11 {
            font-size: small;
            width: 96px;
            height: 33px;
        }
    </style>
</asp:Content>


