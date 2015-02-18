<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<%-- Links Page to Master page --%>
<%@ MasterType VirtualPath="~/MasterPage.master" %>

<%-- Specifies the type of othe object returned by the content page's Master property --%>


<asp:Content runat="server" ID="HeaderTitle" ContentPlaceHolderID="HeaderTitle">
    <h2>User/Admin Login</h2>
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" Runat="Server">
    <br />
    <form runat="server"> 
    <table style="border: 1px solid black; width:45%;"">
        <tr>
            <td style="padding: 10px 5px 5px 5px;"><asp:Label ID="Label1" runat="server" Text="Username"></asp:Label>:</td>
            <td style="padding: 10px 5px 5px 5px;"><asp:TextBox ID="UsernameTextBox" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td></td>
            <td><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="UsernameTextBox" ErrorMessage="* Username Required" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>:</td>
            <td ><asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password"></asp:TextBox></td>
        </tr>
        <tr>
            <td></td>
            <td><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                ErrorMessage="* Password Required" ControlToValidate="PasswordTextBox" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>

        <tr>
            <td colspan="2"><asp:Button ID="LoginButton" runat="server" Text="Login" Width="120px" OnClick="LoginButton_Click" /> </td>
        </tr>
    </table>
    </form>
    <br />
</asp:Content>

<asp:Content ID="Content1" runat="server" contentplaceholderid="head">
</asp:Content>


