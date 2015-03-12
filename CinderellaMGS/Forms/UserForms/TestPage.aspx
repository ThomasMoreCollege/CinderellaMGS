<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TestPage.aspx.cs" Inherits="Forms_UserForms_TestPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeaderTitle" Runat="Server">
    <h2>Test Page</h2>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br />
    <asp:Button ID="Button1" runat="server" Text="Add" OnClick="Button1_Click1" /><asp:Button ID="Button2" runat="server" Text="Pop" /><br />
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>


</asp:Content>

