<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<%-- Links Page to Master page --%>
<%@ MasterType VirtualPath="~/MasterPage.master" %>

<%-- Specifies the type of othe object returned by the content page's Master property --%>


<asp:Content runat="server" ID="HeaderTitle" ContentPlaceHolderID="HeaderTitle">
    <h2>User/Admin Login</h2>
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" Runat="Server">
    <br />
    <table id="LoginTable" style="border: 1px solid black; width:45%;">
        <tr>
            <td colspan="2" class="auto-style2">

                <asp:Label ID="LoginErrorLabel" runat="server" Enabled="False" ForeColor="Red" Text="Invalid user login." Visible="False"></asp:Label>

            </td>
        </tr>
        <tr>
            <td style="padding: 10px 5px 5px 5px;" class="auto-style3"><asp:Label ID="Label1" runat="server" Text="Username"></asp:Label>:</td>
            <td style="padding: 10px 5px 5px 5px;" class="auto-style4"><asp:TextBox ID="UsernameTextBox" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td></td>
            <td class="auto-style1"><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="UsernameTextBox" ErrorMessage="* Username Required" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style3"><asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>:</td>
            <td class="auto-style4" ><asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password"></asp:TextBox></td>
        </tr>
        <tr>
            <td></td>
            <td class="auto-style1"><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                ErrorMessage="* Password Required" ControlToValidate="PasswordTextBox" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>

        <tr>
            <td colspan="2" class="auto-style2"><asp:Button ID="LoginButton" runat="server" Text="Login" Width="120px" OnClick="LoginButton_Click" style="text-align: center" /> 
            </td>
        </tr>
        <tr>
            <td colspan="2"></td>
        </tr>
    </table>
</asp:Content>

<asp:Content ID="Content1" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style1
        {
            width: 201px;
        }
        .auto-style2
        {
            text-align: center;
        }
        .auto-style3
        {
            text-align: right;
        }
        .auto-style4
        {
            width: 201px;
            text-align: center;
        }
    </style>
</asp:Content>


