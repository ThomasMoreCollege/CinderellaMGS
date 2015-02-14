<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>


<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" Runat="Server">
    <br />
    <form runat="server"> 
    <table style="border: 1px solid black;">
        <tr>
            <td><asp:Label ID="Label1" runat="server" Text="Username"></asp:Label></td>
            <td><asp:TextBox ID="UsernameTextBox" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="UsernameTextBox" ErrorMessage="* Username Required" ForeColor="Red"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td><asp:Label ID="Label2" runat="server" Text="Password"></asp:Label></td>
            <td ><asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                ErrorMessage="* Password Required" ControlToValidate="PasswordTextBox" ForeColor="Red"></asp:RequiredFieldValidator></td>
        </tr>

        <tr>
            <td><asp:Button ID="LoginButton" runat="server" Text="Login" Width="120px" OnClick="LoginButton_Click" /> </td>
        </tr>
    </table>
    </form>
    <br />
</asp:Content>

