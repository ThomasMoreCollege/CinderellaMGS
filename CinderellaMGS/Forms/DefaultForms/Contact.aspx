<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Forms_DefaultForms_Contact" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeaderTitle" Runat="Server">
    <h2>Contact Information</h2>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
    <p>
        Immanuel United Methodist Church
    </p>
    <p>
        <asp:Label ID="Label1" runat="server" Text="Label">2551 Dixie Hwy</asp:Label>
    </p>
    <p>
        <asp:Label ID="Label2" runat="server" Text="Label">Lakeside Park, KY 41017</asp:Label>
    </p>
    <p>
        (859) 341-5330
    </p>
    <p>
        <a href="http://contactus@cinderellasclosetnky.org">contactus@cinderellasclosetnky.org</a>
    </p>
    <p>
        Home Website: <a href="http://www.cinderellasclosetusa.org">www.cinderellasclosetusa.org</a>
    </p>

</asp:Content>